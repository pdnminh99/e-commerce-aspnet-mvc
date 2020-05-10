using EcommerceApp2259.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EcommerceApp2259.Areas.Identity.IdentityHostingStartup))]
namespace EcommerceApp2259.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EcommerceApp2259IdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EcommerceApp2259IdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<EcommerceApp2259IdentityDbContext>();
            });
        }
    }
}