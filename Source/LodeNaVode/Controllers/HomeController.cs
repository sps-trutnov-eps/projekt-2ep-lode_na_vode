using LodeNaVode.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LobbyDbContext _lobbyDatabase;

        public HomeController(ILogger<HomeController> logger, LobbyDbContext dbContext)
        {
            _logger = logger;
            _lobbyDatabase = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JoinLobby(string playerName) 
        {
            if (playerName == null || playerName.Trim().Length == 0)
                return Redirect("/Home/Index");

            if (HttpContext.Session.GetString("playerid") == null)
            {
                var dice = new Random();
                int diceresult = dice.Next(1000000000, 2000000000);
                string newplayeridhashed = BCrypt.Net.BCrypt.HashPassword(diceresult.ToString());
                HttpContext.Session.SetString("playerid", newplayeridhashed);
            }
            HttpContext.Session.SetString("playername", playerName);
            HttpContext.Session.CommitAsync();
            return RedirectToAction("Index","Lobby");
        }
    }
}