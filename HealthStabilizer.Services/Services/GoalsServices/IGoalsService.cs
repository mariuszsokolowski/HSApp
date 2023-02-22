using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.GoalsServices
{
    public interface IGoalsService
    {
        Task<IQueryable<Goals>> GetAsync();

        Task<Goals> GetAsync(string userId);
        Task<GoalsDTO> GetWithVitaminsAndMineralAsync(string userId);

        Task AddAsync(Goals model);

        Task UpdateAsync(Goals model);

        Task DeleteAsync(int id);
    }
}
