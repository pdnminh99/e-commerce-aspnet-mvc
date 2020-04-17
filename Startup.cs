using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EcommerceApp2259.Contexts;
using EcommerceApp2259.Models;
using EcommerceApp2259.Services;
using Microsoft.EntityFrameworkCore;

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
            // Setup DB Contexts.
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("E-CommerceContext")));

            // Setup Dependencies.
            services.AddScoped<IGenericContext<Product, Guid>, ProductContext>();
            services.AddScoped<IGenericContext<Brand, int>, BrandContext>();
            services.AddScoped<IGenericContext<Category, int>, CategoryContext>();
            services.AddScoped<IProductServiceOperations, ProductService>();
            services.AddScoped<IBrandServiceOperations, BrandService>();
            services.AddScoped<ICategoryServiceOperations, CategoryService>();

            services.AddControllersWithViews();
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
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}