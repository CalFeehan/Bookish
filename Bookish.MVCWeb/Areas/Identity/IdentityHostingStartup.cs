using System;
using Bookish.MVCWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Bookish.MVCWeb.Areas.Identity.IdentityHostingStartup))]
namespace Bookish.MVCWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
           /* builder.ConfigureServices((context, services) => {
                services.AddDbContext<BookishMVCWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BookishMVCWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BookishMVCWebContext>();
            });*/
        }
    }
}