using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MijnMaaltijdenHerkansing.Areas.Identity.Data;
using MijnMaaltijdenHerkansing.Data;

[assembly: HostingStartup(typeof(MijnMaaltijdenHerkansing.Areas.Identity.IdentityHostingStartup))]
namespace MijnMaaltijdenHerkansing.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MijnMaaltijdenHerkansingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MijnMaaltijdenHerkansingContextConnection")));

                services.AddDefaultIdentity<Gebruiker>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MijnMaaltijdenHerkansingContext>();
            });
        }
    }
}