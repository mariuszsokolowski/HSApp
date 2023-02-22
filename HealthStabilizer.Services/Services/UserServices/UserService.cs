using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStabilizer.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        readonly DBContext _context;
        public UserService(DBContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<User>> GetAsync()
        {
            var result = await _context.User.ToListAsync();
            return result.AsQueryable();
        }
        public async  Task<User> GetAsync(string id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<UserSeciurity> GetSeciurityAsync(string id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                throw new NotImplementedException("User not found");
            return new UserSeciurity { UserId=id, Mail = user.Email };
        }
        public async Task SetSeciurityAsync(UserSeciurity model)
        {
            var user = await _context.User.FindAsync(model.UserId);
            if (user is null)
                throw new NotImplementedException("User not found");
            user.Email = model.Mail;
            user.NormalizedEmail = model.Mail.ToUpper();
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile> GetProfileAsync(string id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                throw new NotImplementedException("User not found");
            return new UserProfile { UserId = id, FirstName=user.FirstName, LastName=user.LastName, Age=user.Age, Height=user.Height, Weight=user.Weight };
        }
        public async Task SetProfileAsync(UserProfile model)
        {
            var user = await _context.User.FindAsync(model.UserId);
            if (user is null)
                throw new NotImplementedException("User not found");
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Age = model.Age;
            user.Height = model.Height;
            user.Weight = model.Weight;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

        }




    }
}
