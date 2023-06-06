using LodeNaVode.Data;
using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Linq;
using System.Diagnostics;

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
                List<Player> players = new List<Player> { lobbyOwner };
                Lobby newLobby = new Lobby() { Gamemode = "normal", Owner = lobbyOwnerId, Players = players };

                _lobbyDatabase.Lobbies.Add(newLobby);
                _lobbyDatabase.SaveChanges();
            }


            return RedirectToAction("LobbyOwner");
        }

        [HttpGet]
        public IActionResult Join(int lobbyId)
        {
            string playerCookie = Request.Cookies["playerid"].ToString();
            if (_lobbyDatabase.Lobbies.Any(l => l.LobbyId == lobbyId))
            {
                Player player = _lobbyDatabase.Players.Where(p => p.PlayerCookie == playerCookie).First();
                var lobbies = _lobbyDatabase.Lobbies;
                Debug.WriteLine("Všechna lobby:");
                foreach (Lobby l in lobbies)
                {
                    Debug.WriteLine(l.Owner);
                    Debug.WriteLine(l.LobbyId);
                }
                var correctLobbies = lobbies.Where(l => l.LobbyId == lobbyId);
                var playersOfLobby = correctLobbies.First().Players;
                Debug.WriteLine("Moje lobby:");
                Debug.WriteLine(correctLobbies.First().LobbyId);
                Debug.WriteLine("Hráči v lobby:");
                foreach (Player p in playersOfLobby) 
                {
                    Debug.WriteLine(p);
                }
                    playersOfLobby.Add(player);
                return RedirectToAction("Lobby");
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult LobbyOwner()
        {
            return View();
        }

        public IActionResult Lobby()
        {
            return View();
        }
    }
}