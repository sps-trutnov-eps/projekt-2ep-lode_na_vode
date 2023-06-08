using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LodeNaVode.Lode;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public static int tokeny = 37_500_000;
        public static int cenaLodiKrtecek = 7_000_000;
        public static int pocetLodiKrtecek = 0;
        public static int cenaLodiMysicka = 10_000_000;
        public static int pocetLodiMysicka = 0;
        public static int cenaLodiVB = 4_000_000;
        public static int pocetLodiVB = 0;

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View(pocetLodiKrtecek);
        }

        [HttpGet]
        public IActionResult Rozmisteni()
        {
            List<int[]> L = RozmisteniClass.Rozmisti(pocetLodiKrtecek,pocetLodiMysicka,pocetLodiVB);

            return RedirectToAction("Zvolit");
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
        [HttpGet]
        public IActionResult KliknutiPlusMysicka()
        {
            if (tokeny >= cenaLodiMysicka)
            {
                pocetLodiMysicka++;
                tokeny -= cenaLodiMysicka;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMysicka()
        {
            if (pocetLodiMysicka > 0)
            {
                pocetLodiMysicka--; 
                tokeny += cenaLodiMysicka;
            }
            return RedirectToAction("Zvolit");
        }
        [HttpGet]
        public IActionResult KliknutiPlusVB()
        {
            if (tokeny >= cenaLodiVB)
            {
                pocetLodiVB++;
                tokeny -= cenaLodiVB;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusVB()
        {
            if (pocetLodiVB > 0)
            {
                pocetLodiVB--;
                tokeny += cenaLodiVB;
            }
            return RedirectToAction("Zvolit");
        }
    }
}
