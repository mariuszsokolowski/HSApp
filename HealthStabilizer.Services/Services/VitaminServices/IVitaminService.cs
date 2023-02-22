using HealthStabilizer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.VitaminServices
{
    public interface IVitaminService
    {
        Task<IQueryable<Vitamin>> GetAsync();

        Task<Vitamin> GetAsync(int id);

        Task AddAsync(Vitamin model);

        Task UpdateAsync(Vitamin model);

        Task DeleteAsync(int id);
    }
}
