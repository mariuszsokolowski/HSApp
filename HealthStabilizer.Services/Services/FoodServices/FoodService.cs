using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.FoodServices
{

    public class FoodService : IFoodService
    {
        readonly DBContext _context;

        public FoodService(DBContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Food>> GetAsync(string UserId)
        {


            var list = _context.Diary.Where(x => x.UserId == UserId).OrderByDescending(x => x.CreateDate).Select(x => x.FoodId);
            var idList = new HashSet<int>(list).ToList();
            var result = (from id in idList
                          join item in _context.Food.Include(x => x.Mineral).Include(x => x.Vitamin).AsNoTracking()
                          on id equals item.FoodId
                          select item).AsQueryable();

            //Get another food
            var anotherFoodList = await _context.Food
    .Where(x => !idList.Any(plp => x.FoodId == plp)).Include(x => x.Mineral).Include(x => x.Vitamin).AsNoTracking().ToListAsync();

            //Concat Food from diary and another food
            result.ToList().AddRange(anotherFoodList);

            return result.AsQueryable();
        }

        public async Task<Food> GetAsync(int id)
        {
            return await _context.Food.Include(x => x.Mineral).Include(x => x.Vitamin).Where(x => x.FoodId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task AddAsync(Food model)
        {
            await _context.Food.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Food model)
        {
            if (model.FoodId <= 0)
                throw new ArgumentNullException("FoodId is <=0");

            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Food.FindAsync(id);
            _context.Food.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
