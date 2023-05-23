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
            int testplayerid = 1;
            List<int> players = new List<int> { testplayerid};
            Lobby newLobby = new Lobby() { Gamemode = "normal", Owner = "userId", Players = players};

            _lobbyDatabase.Add(newLobby);
            _lobbyDatabase.SaveChanges();

            return View("~/Views/Lobby/LobbyOwner.cshtml", model);
        }

        [HttpGet]
        public IActionResult Join(Lobby model)
        {
            return View("~/Views/Lobby/Lobby.cshtml", model);
        }
    }
}