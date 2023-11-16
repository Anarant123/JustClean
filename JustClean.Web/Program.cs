using JustClean.Web.Models.db;
using JustClean.Web.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace JustClean.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<JustcleanContext>();

            builder.Services.AddScoped<Repository.Repository>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<CookieService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}