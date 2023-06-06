using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public float pocetLodi = 0;

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View(pocetLodi);
        }

        public IActionResult KliknutiPlus()
        {
            pocetLodi++;
            return View("Zvolit", pocetLodi);
        }

        public IActionResult KliknutiMinus()
        {
            pocetLodi--;
            return View("Zvolit", pocetLodi);
        }

    }

}
