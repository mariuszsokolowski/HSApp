using HealthStabilizer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthStabilizer.Data
{
    public class DBContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
     UserRole, IdentityUserLogin<string>,
     IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DBContext(DbContextOptions<DBContext> options)
       : base(options)
        { }

        public DbSet<Mineral> Mineral { get; set; }
        public DbSet<Vitamin> Vitamin { get; set; }
        public DbSet<Goals> Goals { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Diary> Diary { get; set; }

        public DbSet<BaseGoal> BaseGoal { get; set; }

    }
}
