using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LodeNaVode.Lode;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public static int tokeny = 37_500_000;
        //Malé
        public static int cenaLodiMetodej = 7_000_000;
        public static int pocetLodiMetodej = 0;
        public static int cenaLodiBorivoj = 10_000_000;
        public static int pocetLodiBorivoj = 0;
        public static int cenaLodiCyril = 4_000_000;
        public static int pocetLodiCyril = 0;
        //Střední
        public static int cenaLodiKrtecek = 0;
        public static int pocetLodiKrtecek = 0;
        public static int cenaLodiIlias = 0;
        public static int pocetLodiIlias = 0;
        public static int cenaLodiCapek = 0;
        public static int pocetLodiCapek = 0;
        public static int cenaLodiVaclavII = 0;
        public static int pocetLodiVaclavII = 0;
        public static int cenaLodiMacha = 0;
        public static int pocetLodiMacha = 0;
        public static int cenaLodiLibuse = 0;
        public static int pocetLodiLibuse = 0;
        public static int cenaLodiPalach = 0;
        public static int pocetLodiPalach = 0;
        public static int cenaLodiMasaryk = 0;
        public static int pocetLodiMasaryk = 0;
        public static int cenaLodiSvatopluk = 0;
        public static int pocetLodiSvatopluk = 0;
        public static int cenaLodiGott = 0;
        public static int pocetLodiGott = 0;
        //Velké
        public static int cenaLodiZatopek = 0;
        public static int pocetLodiZatopek = 0;
        public static int cenaLodiOdysea = 0;
        public static int pocetLodiOdysea = 0;
        public static int cenaLodiKarelIV = 0;
        public static int pocetLodiKarelIV = 0;
        public static int cenaLodiZizka = 0;
        public static int pocetLodiZizka = 0;
        public static int cenaLodiNemcova = 0;
        public static int pocetLodiNemcova = 0;


        [HttpGet]
        public IActionResult Zvolit()
        {
            return View(pocetLodiMetodej);
        }

        [HttpGet]
        public IActionResult Rozmisteni()
        {
            List<int[]> L = RozmisteniClass.Rozmisti(pocetLodiMetodej, pocetLodiBorivoj, pocetLodiCyril, pocetLodiKrtecek, pocetLodiIlias, pocetLodiCapek, pocetLodiVaclavII, pocetLodiMacha, pocetLodiLibuse, pocetLodiPalach, pocetLodiMasaryk, pocetLodiSvatopluk, pocetLodiGott);

            return RedirectToAction("Zvolit");
        }
        
        //Malé lodě
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

        //Střední lodě
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
        public IActionResult KliknutiPlusIlias()
        {
            if (tokeny >= cenaLodiIlias)
            {
                pocetLodiIlias++;
                tokeny -= cenaLodiIlias;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusIlias()
        {
            if (pocetLodiIlias > 0)
            {
                pocetLodiIlias--;
                tokeny += cenaLodiIlias;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusCapek()
        {
            if (tokeny >= cenaLodiCapek)
            {
                pocetLodiCapek++;
                tokeny -= cenaLodiCapek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusCapek()
        {
            if (pocetLodiCapek > 0)
            {
                pocetLodiCapek--;
                tokeny += cenaLodiCapek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusVaclavII()
        {
            if (tokeny >= cenaLodiVaclavII)
            {
                pocetLodiVaclavII++;
                tokeny -= cenaLodiVaclavII;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusVaclavII()
        {
            if (pocetLodiVaclavII > 0)
            {
                pocetLodiVaclavII--;
                tokeny += cenaLodiVaclavII;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMacha()
        {
            if (tokeny >= cenaLodiMacha)
            {
                pocetLodiMacha++;
                tokeny -= cenaLodiMacha;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMacha()
        {
            if (pocetLodiMacha > 0)
            {
                pocetLodiMacha--;
                tokeny += cenaLodiMacha;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusLibuse()
        {
            if (tokeny >= cenaLodiLibuse)
            {
                pocetLodiLibuse++;
                tokeny -= cenaLodiLibuse;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusLibuse()
        {
            if (pocetLodiLibuse > 0)
            {
                pocetLodiLibuse--;
                tokeny += cenaLodiLibuse;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusPalach()
        {
            if (tokeny >= cenaLodiPalach)
            {
                pocetLodiPalach++;
                tokeny -= cenaLodiPalach;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusPalach()
        {
            if (pocetLodiPalach > 0)
            {
                pocetLodiPalach--;
                tokeny += cenaLodiPalach;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMasaryk()
        {
            if (tokeny >= cenaLodiMasaryk)
            {
                pocetLodiMasaryk++;
                tokeny -= cenaLodiMasaryk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMasaryk()
        {
            if (pocetLodiMasaryk > 0)
            {
                pocetLodiMasaryk--;
                tokeny += cenaLodiMasaryk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusSvatopluk()
        {
            if (tokeny >= cenaLodiSvatopluk)
            {
                pocetLodiSvatopluk++;
                tokeny -= cenaLodiSvatopluk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusSvatopluk()
        {
            if (pocetLodiSvatopluk > 0)
            {
                pocetLodiSvatopluk--;
                tokeny += cenaLodiSvatopluk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusGott()
        {
            if (tokeny >= cenaLodiGott)
            {
                pocetLodiGott++;
                tokeny -= cenaLodiGott;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusGott()
        {
            if (pocetLodiGott > 0)
            {
                pocetLodiGott--;
                tokeny += cenaLodiGott;
            }
            return RedirectToAction("Zvolit");
        }

        //Velké
        [HttpGet]
        public IActionResult KliknutiPlusZatopek()
        {
            if (tokeny >= cenaLodiZatopek)
            {
                pocetLodiZatopek++;
                tokeny -= cenaLodiZatopek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusZatopek()
        {
            if (pocetLodiZatopek > 0)
            {
                pocetLodiZatopek--;
                tokeny += cenaLodiZatopek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusOdysea()
        {
            if (tokeny >= cenaLodiOdysea)
            {
                pocetLodiOdysea++;
                tokeny -= cenaLodiOdysea;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusOdysea()
        {
            if (pocetLodiOdysea > 0)
            {
                pocetLodiOdysea--;
                tokeny += cenaLodiOdysea;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusKarelIV()
        {
            if (tokeny >= cenaLodiKarelIV)
            {
                pocetLodiKarelIV++;
                tokeny -= cenaLodiKarelIV;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusKarelIV()
        {
            if (pocetLodiKarelIV > 0)
            {
                pocetLodiKarelIV--;
                tokeny += cenaLodiKarelIV;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusZizka()
        {
            if (tokeny >= cenaLodiZizka)
            {
                pocetLodiZizka++;
                tokeny -= cenaLodiZizka;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusZizka()
        {
            if (pocetLodiZizka > 0)
            {
                pocetLodiZizka--;
                tokeny += cenaLodiZizka;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusNemcova()
        {
            if (tokeny >= cenaLodiNemcova)
            {
                pocetLodiNemcova++;
                tokeny -= cenaLodiNemcova;
            }
            return RedirectToAction("Zvolit");
        }
    }
}
