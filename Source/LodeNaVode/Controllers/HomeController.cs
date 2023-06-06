using LodeNaVode.Data;
using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (Request.Cookies["playerid"] == null)
            {
                var dice = new Random();
                int diceresult = dice.Next(1000000000, 2000000000);
                string newplayeridhashed = BCrypt.Net.BCrypt.HashPassword(diceresult.ToString());
                Response.Cookies.Append("playerid", newplayeridhashed);
                Player player = new Player() { PlayerCookie = newplayeridhashed.ToString() };
                _lobbyDatabase.Players.Add(player);
                _lobbyDatabase.SaveChanges();
                //string playerId = Request.Cookies["playerid"].ToString();
            }
            return View();
        }
    }
}