using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthStabilizer.Services.Services.VitaminServices
{
    public class VitaminService : IVitaminService
    {
        readonly DBContext _context;
        public VitaminService(DBContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Vitamin>> GetAsync()
        {
            var result = await _context.Vitamin.AsNoTracking().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Vitamin> GetAsync(int id)
        {
            return await _context.Vitamin.Where(x => x.VitaminId == id).AsNoTracking().FirstOrDefaultAsync();

        }
        public async Task AddAsync(Vitamin model)
        {
            await _context.Vitamin.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vitamin model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Vitamin.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }



    }
}
