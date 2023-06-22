using LodeNaVode.Data;
using LodeNaVode.Models;
using System.Diagnostics;

namespace LodeNaVode
{
    public class WatchDogWare
    {
        private readonly RequestDelegate _next;

        public WatchDogWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                LobbyDbContext dbContext = scope.ServiceProvider.GetRequiredService<LobbyDbContext>();

                if (httpContext.Session.GetString("playerid") != null)
                {
                    DateTime now = DateTime.Now;

                    Player? user = dbContext.Players
                        .Where(p => p.PlayerCookie == httpContext.Session.GetString("playerid"))
                        .FirstOrDefault();

                    if (user != null)
                    {
                        user.ExpirationDate = now.AddMinutes(15);
                        if (user.ExpirationDate < now)
                        {
                            user.Active = false;
                        }
                        dbContext.SaveChanges();
                    }
                }

                await _next(httpContext);
            }
        }
    }
}
