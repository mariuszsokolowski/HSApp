using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.Goals;
using HealthStabilizer.Services.Services.BaseGoalsServices;
using Microsoft.EntityFrameworkCore;

namespace HealthStabilizer.Services.Services.GoalsServices
{
    public class GoalsService : IGoalsService
    {
        readonly DBContext _context;
        readonly IBaseGoalsService _baseGoalsService;

        public GoalsService(DBContext context, IBaseGoalsService baseGoalsService)
        {
            _context = context;
            _baseGoalsService = baseGoalsService;
        }
        public async Task<IQueryable<Goals>> GetAsync()
        {
            var result = await _context.Goals.AsNoTracking().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Goals> GetAsync(string userId)
        {
            return await _context.Goals.Where(x => x.ForUserId == userId).AsNoTracking().FirstOrDefaultAsync();

        }
        public async Task<GoalsDTO> GetWithVitaminsAndMineralAsync(string userId)
        {
            return new GoalsDTO()
            {
                Goals = await GetAsync(userId),
                Vitamin = (await _baseGoalsService.GetAsync()).FirstOrDefault().Vitamin,
                Mineral = (await _baseGoalsService.GetAsync()).FirstOrDefault().Mineral
            };
        }

        public async Task AddAsync(Goals model)
        {
            await _context.Goals.AddAsync(model);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Goals model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Goals.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
