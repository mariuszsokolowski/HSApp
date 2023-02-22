using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.Diary;
using HealthStabilizer.Services.Services.GoalsServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.DiaryServices
{
    public class DiaryService : IDiaryService
    {
        readonly DBContext _context;
        readonly IGoalsService _goalsService;

        public DiaryService(DBContext context, IGoalsService goalsService)
        {
            _context = context;
            _goalsService = goalsService;
        }

        public async Task<IQueryable<Diary>> GetAsync(string userId, DateTime? toDate)
        {
            toDate = toDate == null ? DateTime.Now : toDate;

            var result = await _context.Diary.Where(x => x.UserId == userId && x.Date.ToShortDateString() == toDate.Value.ToShortDateString()).Include(x => x.Food).ThenInclude(x => x.Vitamin).Include(x => x.Food.Mineral).AsNoTracking().ToListAsync();
            foreach (var item in result)
            {
                item.Food.Calories = (float)Math.Round(item.Quantity * (item.Food.Calories / 100), 2);
                item.Food.Fat = (float)Math.Round(item.Quantity * (item.Food.Fat / 100), 2);
                item.Food.Protein = (float)Math.Round(item.Quantity * (item.Food.Protein / 100), 2);
                item.Food.Carbs = (float)Math.Round(item.Quantity * (item.Food.Carbs / 100), 2);
            }
            return result.AsQueryable();
        }

        public async Task<Diary> GetAsync(int id)
        {
            return await _context.Diary.Where(x => x.DiaryId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task AddAsync(List<DiaryFoodDTO> foods, string toUser, DateTime toDate)
        {
            try
            {
                var currentDateTime = DateTime.Now;
                foreach (var item in foods)
                {
                    var entity = new Diary
                    {
                        CreateDate = currentDateTime,
                        Date = toDate,
                        FoodId = item.FoodId,
                        UserId = toUser,
                        Quantity = item.Quantity
                    };
                    await _context.Diary.AddAsync(entity);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task UpdateAsync(Diary model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateQuantityAsync(int diaryId, DiaryFoodDTO model)
        {
            var entity = await _context.Diary.FindAsync(diaryId);
            if (entity is null) throw new ArgumentNullException($"No diary in DB with id {diaryId}");
            entity.Quantity = model.Quantity;
            await UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Diary.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DiaryIntakeSumDTO> GetSumAsync(string userId, DateTime? date)
        {
            var diary = await GetAsync(userId, date);
            var goals = await _goalsService.GetWithVitaminsAndMineralAsync(userId);

            DiaryIntakeSumDTO result = new DiaryIntakeSumDTO();
            foreach (var item in diary)
            {
                result.SumCalories += item.Food.Calories * (item.Quantity / 100);
                result.SumProtein += item.Food.Protein * (item.Quantity / 100);
                result.SumFat += item.Food.Fat * (item.Quantity / 100);
                result.SumCarbs += item.Food.Carbs * (item.Quantity / 100);

                #region Set Vitamins
                foreach (var prop in item.Food.Vitamin.GetType().GetProperties())
                {
                    if (prop.Name != "VitaminId")
                    {
                        object currentValue = result.SumVitamin.GetType().GetProperty(prop.Name).GetValue(result.SumVitamin);
                        var type = currentValue.GetType();
                        currentValue = (Convert.ToDouble(currentValue) + (item.Quantity / 100) * Convert.ToDouble(prop.GetValue(item.Food.Vitamin)));
                        prop.SetValue(result.SumVitamin, Convert.ChangeType(currentValue, type), null);
                    }
                }
                #endregion

                #region Set Minerals
                foreach (var prop in item.Food.Mineral.GetType().GetProperties())
                {
                    if (prop.Name != "MineralId")
                    {
                        object currentValue = result.SumMineral.GetType().GetProperty(prop.Name).GetValue(result.SumMineral);
                        var type = currentValue.GetType();
                        currentValue = (Convert.ToDouble(currentValue) + (item.Quantity / 100) * Convert.ToDouble(prop.GetValue(item.Food.Mineral)));
                        prop.SetValue(result.SumMineral, Convert.ChangeType(currentValue, type), null);
                    }
                }
                #endregion

            }
            result.SumCalories = Math.Round(result.SumCalories, 2);
            result.SumProtein = Math.Round(result.SumProtein, 2);
            result.SumFat = Math.Round(result.SumFat, 2);
            result.SumCarbs = Math.Round(result.SumCarbs, 2);

            result.GoalCalories = goals.Goals.Calories;
            result.GoalProtein = Math.Round(goals.Goals.Protein * goals.Goals.Calories / 400);
            result.GoalFat = Math.Round(goals.Goals.Fat * goals.Goals.Calories / 900);
            result.GoalCarbs = Math.Round(goals.Goals.Carbs * goals.Goals.Calories / 400);
            result.GoalMineral = goals.Mineral;
            result.GoalVitamin = goals.Vitamin;

            return result;
        }
    }
}
