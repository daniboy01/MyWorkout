using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWorkout.Bll.Services;
using MyWorkout.Bll.Settings;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;
using MyWorkout.Dal.SeedInterfaces;
using MyWorkout.Dal.SeedService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkout.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyWorkoutDbContext>(o =>
                {
                    o.UseSqlServer(Configuration.GetConnectionString(nameof(MyWorkoutDbContext)));
                    o.EnableSensitiveDataLogging(true);
                }); 

            services.AddRazorPages();


            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<MyWorkoutDbContext>()
                .AddDefaultTokenProviders();


            services.AddDistributedMemoryCache();
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            services.AddScoped<IRoleSeedService, RoleSeedService>();
            services.AddScoped<IUserSeedService, UserSeedService>();

            services.AddScoped<WorkoutPlanService>()
                    .AddScoped<CommentService>()
                    .AddScoped<CategoryService>()
                    .AddScoped<ExerciseService>();


            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
