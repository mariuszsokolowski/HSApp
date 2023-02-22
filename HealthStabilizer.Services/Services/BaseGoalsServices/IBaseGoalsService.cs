using HealthStabilizer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.BaseGoalsServices
{
    public interface IBaseGoalsService
    {
        Task<IQueryable<BaseGoal>> GetAsync();
        Task<IQueryable<BaseGoal>> GetAsync(Expression<Func<BaseGoal,bool>> expression);

    }
}
