using indigo.DAL;
using indigo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace indigo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddDbContext<AppDbContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}