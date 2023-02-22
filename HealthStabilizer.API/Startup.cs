using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Services.BaseGoalsServices;
using HealthStabilizer.Services.Services.DiaryServices;
using HealthStabilizer.Services.Services.FoodServices;
using HealthStabilizer.Services.Services.GoalsServices;
using HealthStabilizer.Services.Services.MineralServices;
using HealthStabilizer.Services.Services.VitaminServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;

namespace HealthStabilizer.API
{
    public class Startup
    {
        #region Cors
        readonly string AllowCors = "AllowCors";
        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Cors
            services.AddCors(options => options.AddPolicy(AllowCors,
       builder =>
       {
           builder.AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowCredentials();
       }));
            #endregion
            services.AddDbContext<DBContext>(options =>
                options.UseMySql(
                Configuration.GetConnectionString("MySqlConnection")));

            services.AddIdentity<User, Role>()
                        .AddDefaultUI()
                        .AddRoles<Role>()
                        .AddRoleManager<RoleManager<Role>>()
                        .AddDefaultTokenProviders()
                        .AddEntityFrameworkStores<DBContext>();

            //TODO: Change microsoft DI to Autofac
            //TODO: Add NLoger to DI
            #region Add Jwt Authentication
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); 
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
            #endregion

            
            #region DependencyIncjection
            services.AddTransient<IGoalsService, GoalsService>();
            services.AddTransient<IFoodService, FoodService>();
            services.AddTransient<IMineralService, MineralService>();
            services.AddTransient<IVitaminService, VitaminService>();
            services.AddTransient<IDiaryService, DiaryService>();
            services.AddTransient<IBaseGoalsService, BaseGoalsService>();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(AllowCors);
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
