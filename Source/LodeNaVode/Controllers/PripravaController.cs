using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LodeNaVode.Lode;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public static int tokeny = 37_500_000;
        public static int cenaLodiMetodej = 7_000_000;
        public static int pocetLodiMetodej = 0;
        public static int cenaLodiBorivoj = 10_000_000;
        public static int pocetLodiBorivoj = 0;
        public static int cenaLodiCyril = 4_000_000;
        public static int pocetLodiCyril = 0;

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View(pocetLodiMetodej);
        }

        [HttpGet]
        public IActionResult Rozmisteni()
        {
            List<int[]> L = RozmisteniClass.Rozmisti(pocetLodiMetodej,pocetLodiBorivoj,pocetLodiCyril);

            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMetodej()
        {
            if (tokeny >= cenaLodiMetodej)
            {
                pocetLodiMetodej++;
                tokeny -= cenaLodiMetodej;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMetodej()
        {
            if (pocetLodiMetodej > 0)
            {
                pocetLodiMetodej--;
                tokeny += cenaLodiMetodej;
            }
            return RedirectToAction("Zvolit");
        }
        [HttpGet]
        public IActionResult KliknutiPlusBorivoj()
        {
            if (tokeny >= cenaLodiBorivoj)
            {
                pocetLodiBorivoj++;
                tokeny -= cenaLodiBorivoj;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusBorivoj()
        {
            if (pocetLodiBorivoj > 0)
            {
                pocetLodiBorivoj--; 
                tokeny += cenaLodiBorivoj;
            }
            return RedirectToAction("Zvolit");
        }
        [HttpGet]
        public IActionResult KliknutiPlusCyril()
        {
            if (tokeny >= cenaLodiCyril)
            {
                pocetLodiCyril++;
                tokeny -= cenaLodiCyril;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusCyril()
        {
            if (pocetLodiCyril > 0)
            {
                pocetLodiCyril--;
                tokeny += cenaLodiCyril;
            }
            return RedirectToAction("Zvolit");
        }
    }
}
