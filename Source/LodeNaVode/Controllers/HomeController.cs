﻿using LodeNaVode.Data;
using LodeNaVode.Models;
using main_api;
using Microsoft.AspNetCore.Http;
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
            bool vPocitaciNeexistujeHrac = HttpContext.Session.GetString("playerid") == null;
            Player? hracTohotoJmenaVDatabazi = _lobbyDatabase.Players
                    .Where(p => p.PlayerName == playerName)
                    .FirstOrDefault();

            if (vPocitaciNeexistujeHrac && (hracTohotoJmenaVDatabazi == null || !hracTohotoJmenaVDatabazi.Active))
            {
                var dice = new Random();
                int diceresult = dice.Next(1000000000, 2000000000);
                string newplayeridhashed = BCrypt.Net.BCrypt.HashPassword(diceresult.ToString());
                HttpContext.Session.SetString("playerid", newplayeridhashed);
            }
            HttpContext.Session.SetString("playername", playerName);
            HttpContext.Session.CommitAsync();
            return RedirectToAction("Index", "Lobby");
        }
    }
}