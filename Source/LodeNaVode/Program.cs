using LodeNaVode.Data;
using Microsoft.EntityFrameworkCore;

namespace LodeNaVode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LobbyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LobbyConnection")));
            builder.Services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            builder.Services.Configure<CookiePolicyOptions>(options =>
                options.CheckConsentNeeded = context => false);
            var app = builder.Build();

            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Priprava}/{action=Zvolit}/{id?}");

            app.Run();
        }
    }
}