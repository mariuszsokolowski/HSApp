using HealthStabilizer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.MineralServices
{
    public interface IMineralService
    {
        Task<IQueryable<Mineral>> GetAsync();

        Task<Mineral> GetAsync(int id);

        Task AddAsync(Mineral model);

        Task UpdateAsync(Mineral model);

        Task DeleteAsync(int id);
    }
}
