using LodeNaVode.Data;
using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            if (_lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First().Active)
            {
                string? lobbyOwnerId = HttpContext.Session.GetString("playerid");

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
                    Lobby newLobby = new Lobby() { Owner = lobbyOwnerId, Players = players , Active = true , LodeHracu = new string[,] { } };

                    _lobbyDatabase.Lobbies.Add(newLobby);
                    _lobbyDatabase.SaveChanges();
                }

                return RedirectToAction("Lobby");
            }
            else
                return RedirectToAction("Home", "Index");
        }

        [HttpGet]
        public IActionResult Join(string lobbyId)
        {
            if (_lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First().Active)
            {
                if (lobbyId == null || lobbyId.Trim() == null)
                {
                    HttpContext.Session.SetString("from", "Lobby");
                    return Redirect("/Lobby/Index");
                }

                int id = 0;
                try
                {
                    id = Convert.ToInt32(lobbyId);
                }
                catch
                {
                    HttpContext.Session.SetString("from", "Lobby");
                    return Redirect("/Lobby/Index");
                }

                string playerCookie = HttpContext.Session.GetString("playerid");
                if (_lobbyDatabase.Lobbies.Any(l => l.LobbyId == id))
                {
                    if (!_lobbyDatabase.Lobbies.Where(l => l.LobbyId == id).First().Active)
                    {
                        HttpContext.Session.SetString("from", "Lobby");
                        return RedirectToAction("/Lobby/Index");
                    }
                    else
                    {
                        Player player = _lobbyDatabase.Players.Where(p => p.PlayerCookie == playerCookie).First();
                        var lobbies = _lobbyDatabase.Lobbies;
                        var correctLobbies = lobbies.Where(l => l.LobbyId == id);
                        var playersOfLobby = correctLobbies.First().Players;
                        playersOfLobby.Add(player);
                        _lobbyDatabase.SaveChanges();
                        return RedirectToAction("Lobby");
                    }
                }
                HttpContext.Session.SetString("from", "Lobby");
                return Redirect("/Lobby/Index");
            }
            else
                return RedirectToAction("Home", "Index");
        }

        public IActionResult Lobby()
        {
            if (_lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First().Active)
            {
                Player? playercheck = _lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).FirstOrDefault();
                Lobby currentLobby = _lobbyDatabase.Lobbies.Where(l => l.Players.Contains(playercheck)).First();
                ViewData["lobbyOwner"] = currentLobby.Owner;
                ViewData["currentUser"] = playercheck.PlayerCookie;
                ViewData["lobbyId"] = currentLobby.LobbyId;
                ViewData["currentUserName"] = playercheck.PlayerName;
                ViewData["vsichniHraciVLobby"] = currentLobby.Players.ToList();
                Lobby lobbyVeKteremJsme = _lobbyDatabase.Lobbies.Where(l => l.Players.Contains(playercheck)).First();
                ICollection<Player> hraciNasehoLobby = lobbyVeKteremJsme.Players;
                return View();
            }
            else
                return RedirectToAction("Home", "Index");
        }

        public IActionResult Index()
        {
            if (_lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First().Active)
            {
                string? from = HttpContext.Session.GetString("from");
                string? playerName = HttpContext.Session.GetString("playername");
                if (playerName != null && playerName.Trim() != "")
                {
                    if (!_lobbyDatabase.Players.Any(p => p.PlayerName == playerName))
                    {
                        string? playerCookie = HttpContext.Session.GetString("playerid");
                        Player player = new Player() { PlayerCookie = playerCookie, PlayerName = playerName, Active = true, ExpirationDate = DateTime.Now.AddMinutes(15)};
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
            else
                return RedirectToAction("Home", "Index");

        }

        public IActionResult Leave(string from)
        {
            if (_lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First().Active)
            {
                HttpContext.Session.SetString("from", from);
                Player? playercheck = _lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).FirstOrDefault();
                Lobby currentLobby = _lobbyDatabase.Lobbies.Where(l => l.Players.Contains(playercheck)).First();
                if (playercheck != null)
                {
                    Lobby lobbyWithPlayer = _lobbyDatabase.Lobbies.Where(l => l.Players.Contains(playercheck)).First();
                    lobbyWithPlayer.Players.Remove(playercheck);

                    if (playercheck.PlayerCookie == currentLobby.Owner) 
                    {
                        if (currentLobby.Players.IsNullOrEmpty()) 
                        {
                            currentLobby.Active = false;
                            currentLobby.Owner = null;
                            _lobbyDatabase.SaveChanges();
                        }
                        else 
                        {
                            currentLobby.Owner = currentLobby.Players.First().PlayerCookie;
                            _lobbyDatabase.SaveChanges();
                        }
                    } 
                    else
                        _lobbyDatabase.SaveChanges();

                    return RedirectToAction("Index", "Lobby");
                }
                else
                    throw new NotImplementedException();
            }
            else
                return RedirectToAction("Home", "Index");
        }
    }
}