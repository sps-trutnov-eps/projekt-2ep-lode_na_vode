using LodeNaVode.Data;
using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace LodeNaVode.Controllers
{
    public class LobbyController : Controller
    {
        private LobbyDbContext _lobbyDatabase;

        public LobbyController(LobbyDbContext dbContext) 
        {
            _lobbyDatabase = dbContext;
        }

        [HttpGet]
        public IActionResult Create(Lobby model)
        {
            string lobbyOwnerId = Request.Cookies["playerid"];
            
            var lobbyOwner = _lobbyDatabase.Players
                .Where(p => p.PlayerCookie == lobbyOwnerId)
                .FirstOrDefault();

            if (lobbyOwner == null)
            {
                RedirectToAction("Index");
            }
            else 
            {
                List<Player> players = new List<Player> { lobbyOwner};
            Lobby newLobby = new Lobby() { Gamemode = "normal", Owner = lobbyOwner, Players = players};

            _lobbyDatabase.Lobbies.Add(newLobby);
            _lobbyDatabase.SaveChanges(); 
            }
            

            return View("~/Views/Lobby/LobbyOwner.cshtml", model);
        }

        [HttpGet]
        public IActionResult Join(Lobby model)
        {
            return View("~/Views/Lobby/Lobby.cshtml", model);
        }
    }
}