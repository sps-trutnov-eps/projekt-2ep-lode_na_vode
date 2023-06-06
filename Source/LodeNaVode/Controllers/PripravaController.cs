using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        static int pocetLodi = 0;

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View(pocetLodi);
        }

        [HttpGet]
        public IActionResult KliknutiPlus()
        {
            pocetLodi++;
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinus()
        {
            if (pocetLodi > 0)
                pocetLodi--;
            return RedirectToAction("Zvolit");
        }
    }
}
