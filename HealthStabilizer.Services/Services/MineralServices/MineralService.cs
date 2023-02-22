using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthStabilizer.Services.Services.MineralServices
{
    public class MineralService : IMineralService
    {
        readonly DBContext _context;
        public MineralService(DBContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Mineral>> GetAsync()
        {
            var result = await _context.Mineral.AsNoTracking().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Mineral> GetAsync(int id)
        {
            return await _context.Mineral.Where(x => x.MineralId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task AddAsync(Mineral model)
        {
            await _context.Mineral.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mineral model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Mineral.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }


    }
}
