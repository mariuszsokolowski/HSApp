using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthStabilizer.Services.Services.BaseGoalsServices
{
    public class BaseGoalsService : IBaseGoalsService
    {
        readonly DBContext _context;
        public BaseGoalsService(DBContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<BaseGoal>> GetAsync()
        {
            var result = await _context.BaseGoal.Include(x => x.Vitamin).Include(x => x.Mineral).ToListAsync();
            return result.AsQueryable();
        }
        public async Task<IQueryable<BaseGoal>> GetAsync(Expression<Func<BaseGoal,bool>> expression)
        {
            var result = await _context.BaseGoal.Include(x => x.Vitamin).Include(x => x.Mineral).Where(expression).ToListAsync();
            return result.AsQueryable();
        }
    }
}
