using LodeNaVode.Data;
using LodeNaVode.Models;
using main_api;
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
            DateTime now = DateTime.Now;
            Player user = _lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First();
            user.ExpirationDate = now.AddMinutes(15);
            if (user.ExpirationDate < DateTime.Now) 
            {
                user.Active = false;
            }
            _lobbyDatabase.SaveChanges();
        }

        [HttpGet]
        public IActionResult Create(Lobby model)
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
                // seznam hracu v novem lobby
                List<Player> players = new List<Player> { lobbyOwner };
                // nove lobby
                Lobby newLobby = new Lobby() { Gamemode = "normal", Owner = lobbyOwnerId, Players = players, Active = true };

                // kopie hracu pro engine
                string[][] hraci = new string[players.Count][];

                for (int i = 0; i < hraci.GetLength(0); i++)
                {
                    hraci[i] = new string[2];

                    // polozky [0] a [1] odpovidaji jmenu hrace a jmenu tymu - zjednodusujeme oboji na jmeno hrace (Debian style)
                    hraci[i][0] = hraci[i][1] = players[i].PlayerName;
                }

                // vytvoreni instance enginu pro nove lobby
                Program.KolekceEnginu.Add(newLobby.LobbyId.ToString(), new Engine(hraci, Pamet.velikostX, Pamet.velikostY));

                // ze session ziskame skutecne jmeno hrace
                string jmeno = HttpContext.Session.GetString("playername");

                // cvicne lode dane hry
                Program.KolekceEnginu[newLobby.LobbyId.ToString()].UmistitLod(2, 5, "L", jmeno, jmeno);
                Program.KolekceEnginu[newLobby.LobbyId.ToString()].UmistitLod(9, 5, "P", jmeno, jmeno);
                Program.KolekceEnginu[newLobby.LobbyId.ToString()].UmistitLod(5, 5, "L", jmeno, jmeno);
                Program.KolekceEnginu[newLobby.LobbyId.ToString()].UmistitLod(0, 1, "L", jmeno, jmeno);

                // ulozeni aktualniho lobby do session
                HttpContext.Session.SetString("lobbyid", newLobby.LobbyId.ToString());

                // ulozeni noveho lobby do databaze
                _lobbyDatabase.Lobbies.Add(newLobby);
                _lobbyDatabase.SaveChanges();
            }

            return RedirectToAction("Lobby");
        }

        [HttpGet]
        public IActionResult Join(string lobbyId)
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

        public IActionResult Lobby()
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

        public IActionResult Index()
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

        public IActionResult Leave(string from)
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
    }
}