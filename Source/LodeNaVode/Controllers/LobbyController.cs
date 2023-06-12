using LodeNaVode.Data;
using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

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
            string lobbyOwnerId = HttpContext.Session.GetString("playerid");

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
            string playerCookie = HttpContext.Session.GetString("playerid");
            if (_lobbyDatabase.Lobbies.Any(l => l.LobbyId == lobbyId))
            {
                Player player = _lobbyDatabase.Players.Where(p => p.PlayerCookie == playerCookie).First();
                var lobbies = _lobbyDatabase.Lobbies;
                var correctLobbies = lobbies.Where(l => l.LobbyId == lobbyId);
                var playersOfLobby = correctLobbies.First().Players;
                playersOfLobby.Add(player);
                _lobbyDatabase.SaveChanges();
                return RedirectToAction("Lobby");
            }
            return RedirectToAction("JoinLobby", "Home");
        }

        public IActionResult LobbyOwner()
        {
            return View();
        }

        public IActionResult Lobby()
        {
            return View();
        }

        public IActionResult Index()
        {
            string? from = HttpContext.Session.GetString("from");
            string? playerName = HttpContext.Session.GetString("playername");
            if (playerName != null && playerName.Trim() != "")
            {
                if (!_lobbyDatabase.Players.Any(p => p.PlayerName == playerName))
                {
                    string? playerCookie = HttpContext.Session.GetString("playerid");
                    Player player = new Player() { PlayerCookie = playerCookie, PlayerName = playerName };
                    _lobbyDatabase.Players.Add(player);
                    _lobbyDatabase.SaveChanges();
                    return View();
                }
                else 
                {
                    if (from == "Lobby")
                    {
                        HttpContext.Session.Remove("from");
                        return View();
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
                return RedirectToAction("Index", "Home");

        }

        public IActionResult Leave(string from)
        {
            HttpContext.Session.SetString("from", from);
            Player playercheck = _lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).FirstOrDefault();
            if (playercheck != null)
            {
                Lobby lobbyWithPlayer = _lobbyDatabase.Lobbies.Where(l => l.Players.Contains(playercheck)).First();
                lobbyWithPlayer.Players.Remove(playercheck);
                _lobbyDatabase.SaveChanges();
                return RedirectToAction("Index", "Lobby");
            }
            else
                throw new NotImplementedException();
        }
    }
}