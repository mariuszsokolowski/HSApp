using HealthStabilizer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.FoodServices
{
    public interface IFoodService
    {
        Task<IQueryable<Food>> GetAsync(string UserId);

        Task<Food> GetAsync(int id);

        Task AddAsync(Food model);

        Task UpdateAsync(Food model);

        Task DeleteAsync(int id);

    }
}
