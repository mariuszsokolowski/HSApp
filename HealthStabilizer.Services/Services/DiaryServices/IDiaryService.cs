using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.Diary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.DiaryServices
{
    public interface IDiaryService
    {
        Task<Diary> GetAsync(int id);
        Task<IQueryable<Diary>> GetAsync(string userId, DateTime? toDate);

        Task<DiaryIntakeSumDTO> GetSumAsync(string userId, DateTime? date);

        Task AddAsync(List<DiaryFoodDTO> foods, string toUser, DateTime toDate);

        Task UpdateAsync(Diary model);
        Task UpdateQuantityAsync(int diaryId,DiaryFoodDTO model);


        Task DeleteAsync(int id);
    }
}
