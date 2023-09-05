using LodeNaVode.Data;
using LodeNaVode.Models;
using Microsoft.AspNetCore.Identity;
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

                Player? user = dbContext.Players.Where(p => p.PlayerCookie == httpContext.Session.GetString("playerid")).FirstOrDefault();
                if (user != null)
                {
                    if (user.ExpirationDate < DateTime.Now)
                    {
                        user.Active = false;
                        dbContext.SaveChanges();
                    }
                    else 
                    {
                        user.ExpirationDate = DateTime.Now.AddMinutes(15);
                    }
                }

                await _next(httpContext);
            }
        }
    }
}
