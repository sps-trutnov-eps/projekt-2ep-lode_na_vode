using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public static int tokeny = 37_500_000;
        public static int cenaLodiKrtecek = 7_000_000;
        public static int pocetLodiKrtecek = 0;

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View(pocetLodiKrtecek);
        }

        [HttpGet]
        public IActionResult KliknutiPlusKrtecek()
        {
            if (tokeny >= cenaLodiKrtecek)
            {
                pocetLodiKrtecek++;
                tokeny -= cenaLodiKrtecek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusKrtecek()
        {
            if (pocetLodiKrtecek > 0)
            {
                pocetLodiKrtecek--;
                tokeny += cenaLodiKrtecek;
            }
            return RedirectToAction("Zvolit");
        }
    }
}
