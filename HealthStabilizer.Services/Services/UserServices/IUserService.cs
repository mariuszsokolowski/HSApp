using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.UserServices
{
    public interface IUserService
    {
        Task<IQueryable<User>> GetAsync();
        Task<User> GetAsync(string id);
        Task<UserSeciurity> GetSeciurityAsync(string id);
        Task SetSeciurityAsync(UserSeciurity model);
        Task<UserProfile> GetProfileAsync(string id);
        Task SetProfileAsync(UserProfile model);
    }
}
