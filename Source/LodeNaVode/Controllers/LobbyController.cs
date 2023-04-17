using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace LodeNaVode.Controllers
{
    public class LobbyController : Controller
    {
        [HttpGet]
        public IActionResult Create(Lobby model)
        {
            return View("~/Views/Lobby/LobbyOwner.cshtml", model);
        }

        [HttpGet]
        public IActionResult Join(Lobby model)
        {
            if (model.ID != null)
                return View("~/Views/Lobby/Lobby.cshtml", model);

            return View("~/Views/Lobby/Lobby.cshtml", model);
        }
    }
}