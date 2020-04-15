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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("E-CommerceContext")));
            services.AddScoped<IGenericContext<Product>, ProductContext>();
            services.AddScoped<IGenericContext<Brand>, BrandContext>();
            services.AddScoped<IGenericContext<Category>, CategoryContext>();
            services.AddScoped<IProductServiceOperations, ProductService>();
            services.AddScoped<IBrandServiceOperations, BrandService>();
            services.AddScoped<ICategoryServiceOperations, CategoryService>();
            services.AddControllersWithViews();
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
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
                    pattern: "{controller=Home}/{action=Index}/{keyword?}");
            });
        }
    }
}