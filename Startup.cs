using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EcommerceApp2259.Models;
using EcommerceApp2259.Contexts;
using Microsoft.AspNetCore.Identity;
using System;

using Microsoft.EntityFrameworkCore;

// [assembly: HostingStartup(typeof(EcommerceApp2259.Startup))]
namespace EcommerceApp2259
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApplicationContext>(options =>
            //     options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("E-CommerceContext")));

            // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            // .AddEntityFrameworkStores<EcommerceApp2259IdentityDbContext>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();


            services.AddDbContext<EcommerceApp2259IdentityDbContext>(options =>
                    options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("EcommerceApp2259IdentityDbContextConnection")));

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<EcommerceApp2259IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1);

                options.LoginPath = "/Customer/Authentication";
                // options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "{*url}",
                    new { controller = "Home", action = "PageNotFound" });
            });

        }
    }
}