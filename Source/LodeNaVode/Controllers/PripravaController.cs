using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LodeNaVode.Data;

namespace LodeNaVode.Controllers
{
    public struct Neco
    {
        public string? hrac;

        public int pocetLodiMetodej = 0;
        public int pocetLodiBorivoj = 0;
        public int pocetLodiCyril = 0;
        public int pocetLodiKrtecek = 0;
        public int pocetLodiIlias = 0;
        public int pocetLodiCapek = 0;
        public int pocetLodiVaclavII = 0;
        public int pocetLodiMacha = 0;
        public int pocetLodiLibuse = 0;
        public int pocetLodiPalach = 0;
        public int pocetLodiMasaryk = 0;
        public int pocetLodiSvatopluk = 0;
        public int pocetLodiGott = 0;
        public int pocetLodiZatopek = 0;
        public int pocetLodiOdysea = 0;
        public int pocetLodiKarelIV = 0;
        public int pocetLodiZizka = 0;
        public int pocetLodiNemcova = 0;

        public Neco ()
        {
            hrac = "";
            pocetLodiMetodej = 0;
            pocetLodiBorivoj = 0;
            pocetLodiCyril = 0;
            pocetLodiKrtecek = 0;
            pocetLodiIlias = 0;
            pocetLodiCapek = 0;
            pocetLodiVaclavII = 0;
            pocetLodiMacha = 0;
            pocetLodiLibuse = 0;
            pocetLodiPalach = 0;
            pocetLodiMasaryk = 0;
            pocetLodiSvatopluk = 0;
            pocetLodiGott = 0;
            pocetLodiZatopek = 0;
            pocetLodiOdysea = 0;
            pocetLodiKarelIV = 0;
            pocetLodiZizka = 0;
            pocetLodiNemcova = 0;
        }
    }

    public class PripravaController : Controller
    {
        public static int tokeny = 100_000_000;
        //Malé
        public static int cenaLodiMetodej = 3_000_000;
        //public static int pocetLodiMetodej = 0;
        public static int cenaLodiBorivoj = 6_000_000;
        //public static int pocetLodiBorivoj = 0;
        public static int cenaLodiCyril = 4_000_000;
        //public static int pocetLodiCyril = 0;
        //Střední
        public static int cenaLodiKrtecek = 10_000_000;
        //public static int pocetLodiKrtecek = 0;
        public static int cenaLodiIlias = 12_000_000;
        //public static int pocetLodiIlias = 0;
        public static int cenaLodiCapek = 9_000_000;
        //public static int pocetLodiCapek = 0;
        public static int cenaLodiVaclavII = 14_000_000;
        //public static int pocetLodiVaclavII = 0;
        public static int cenaLodiMacha = 13_000_000;
        //public static int pocetLodiMacha = 0;
        public static int cenaLodiLibuse = 18_000_000;
        //public static int pocetLodiLibuse = 0;
        public static int cenaLodiPalach = 10_000_000;
        //public static int pocetLodiPalach = 0;
        public static int cenaLodiMasaryk = 13_000_000;
        //public static int pocetLodiMasaryk = 0;
        public static int cenaLodiSvatopluk = 17_000_000;
        //public static int pocetLodiSvatopluk = 0;
        public static int cenaLodiGott = 15_000_000;
        //public static int pocetLodiGott = 0;
        //Velké
        public static int cenaLodiZatopek = 21_000_000;
        //public static int pocetLodiZatopek = 0;
        public static int cenaLodiOdysea = 28_000_000;
        //public static int pocetLodiOdysea = 0;
        public static int cenaLodiKarelIV = 26_000_000;
        //public static int pocetLodiKarelIV = 0;
        public static int cenaLodiZizka = 24_000_000;
        //public static int pocetLodiZizka = 0;
        public static int cenaLodiNemcova = 25_000_000;
        //public static int pocetLodiNemcova = 0;

        public static Neco neco;

        private LobbyDbContext _lobbyDatabase;

        public PripravaController(LobbyDbContext lobbyDatabase)
        {
            _lobbyDatabase = lobbyDatabase;
            neco = new Neco();
        }

        [HttpGet]
        public IActionResult Zvolit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Rozmisteni()
        {
            // give player some name
            neco.hrac = HttpContext.Session.GetString("playername");

            // rozmisteni lodi probiha v pomocne tride
            //List<int[]> L = RozmisteniClass.Rozmisti(pocetLodiMetodej, pocetLodiBorivoj, pocetLodiCyril, pocetLodiKrtecek, pocetLodiIlias, pocetLodiCapek, pocetLodiVaclavII, pocetLodiMacha, pocetLodiLibuse, pocetLodiPalach, pocetLodiMasaryk, pocetLodiSvatopluk, pocetLodiGott, pocetLodiZatopek, pocetLodiOdysea, pocetLodiKarelIV, pocetLodiZizka, pocetLodiNemcova);
            Lobby currentLobby = _lobbyDatabase.Lobbies.Where(l => l.Owner == HttpContext.Session.GetString("playerid")).First();
            currentLobby.PlayersBoats = new List<string[]>();
            foreach (Player p in currentLobby.Players)
            {
                int index = 0;
                int amountOfBoats = neco.pocetLodiMetodej + neco.pocetLodiBorivoj + neco.pocetLodiCyril + neco.pocetLodiKrtecek + neco.pocetLodiIlias + neco.pocetLodiCapek + neco.pocetLodiVaclavII + neco.pocetLodiMacha + neco.pocetLodiLibuse + neco.pocetLodiPalach + neco.pocetLodiMasaryk +neco. pocetLodiSvatopluk + neco.pocetLodiGott + neco.pocetLodiZatopek + neco.pocetLodiOdysea + neco.pocetLodiKarelIV + neco.pocetLodiZizka + neco.pocetLodiNemcova + 1;
                string[] playerCookieAr = new string[] { p.PlayerCookie };
                string[] playerBoatAmounts = new string[] { neco.pocetLodiMetodej.ToString(), neco.pocetLodiBorivoj.ToString(), neco.pocetLodiCyril.ToString(), neco.pocetLodiKrtecek.ToString(), neco.pocetLodiIlias.ToString(), neco.pocetLodiCapek.ToString(), neco.pocetLodiVaclavII.ToString(), neco.pocetLodiMacha.ToString(), neco.pocetLodiLibuse.ToString(), neco.pocetLodiPalach.ToString(), neco.pocetLodiMasaryk.ToString(), neco.pocetLodiSvatopluk.ToString(), neco.pocetLodiGott.ToString(), neco.pocetLodiZatopek.ToString(), neco.pocetLodiOdysea.ToString(), neco.pocetLodiKarelIV.ToString(), neco.pocetLodiZizka.ToString(), neco.pocetLodiNemcova.ToString() };
                int totalArLenght = playerCookieAr.Length + playerBoatAmounts.Length;
                string[] playerBoats = new string[totalArLenght];
                Array.Copy(playerCookieAr, 0, playerBoats, 0, playerCookieAr.Length);
                Array.Copy(playerBoatAmounts, 0, playerBoats, playerCookieAr.Length, playerBoatAmounts.Length);
                
                currentLobby.PlayersBoats.Add(playerBoats);
            }

            _lobbyDatabase.SaveChanges();

            // automaticky pokracujeme na dalsi obrazovku
            return Redirect("/Tah/Policko/-1");
        }
        
        //Malé lodě
        [HttpGet]
        public IActionResult KliknutiPlusMetodej()
        {
            if (tokeny >= cenaLodiMetodej)
            {
                neco.pocetLodiMetodej++;
                tokeny -= cenaLodiMetodej;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMetodej()
        {
            if (neco.pocetLodiMetodej > 0)
            {
                neco.pocetLodiMetodej--;
                tokeny += cenaLodiMetodej;
            }
            return RedirectToAction("Zvolit");
        }
        [HttpGet]
        public IActionResult KliknutiPlusBorivoj()
        {
            if (tokeny >= cenaLodiBorivoj)
            {
                neco.pocetLodiBorivoj++;
                tokeny -= cenaLodiBorivoj;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusBorivoj()
        {
            if (neco.pocetLodiBorivoj > 0)
            {
                neco.pocetLodiBorivoj--; 
                tokeny += cenaLodiBorivoj;
            }
            return RedirectToAction("Zvolit");
        }
        [HttpGet]
        public IActionResult KliknutiPlusCyril()
        {
            if (tokeny >= cenaLodiCyril)
            {
                neco.pocetLodiCyril++;
                tokeny -= cenaLodiCyril;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusCyril()
        {
            if (neco.pocetLodiCyril > 0)
            {
                neco.pocetLodiCyril--;
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
                neco.pocetLodiKrtecek++;
                tokeny -= cenaLodiKrtecek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusKrtecek()
        {
            if (neco.pocetLodiKrtecek > 0)
            {
                neco.pocetLodiKrtecek--;
                tokeny += cenaLodiKrtecek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusIlias()
        {
            if (tokeny >= cenaLodiIlias)
            {
                neco.pocetLodiIlias++;
                tokeny -= cenaLodiIlias;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusIlias()
        {
            if (neco.pocetLodiIlias > 0)
            {
                neco.pocetLodiIlias--;
                tokeny += cenaLodiIlias;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusCapek()
        {
            if (tokeny >= cenaLodiCapek)
            {
                neco.pocetLodiCapek++;
                tokeny -= cenaLodiCapek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusCapek()
        {
            if (neco.pocetLodiCapek > 0)
            {
                neco.pocetLodiCapek--;
                tokeny += cenaLodiCapek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusVaclavII()
        {
            if (tokeny >= cenaLodiVaclavII)
            {
                neco.pocetLodiVaclavII++;
                tokeny -= cenaLodiVaclavII;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusVaclavII()
        {
            if (neco.pocetLodiVaclavII > 0)
            {
                neco.pocetLodiVaclavII--;
                tokeny += cenaLodiVaclavII;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMacha()
        {
            if (tokeny >= cenaLodiMacha)
            {
                neco.pocetLodiMacha++;
                tokeny -= cenaLodiMacha;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMacha()
        {
            if (neco.pocetLodiMacha > 0)
            {
                neco.pocetLodiMacha--;
                tokeny += cenaLodiMacha;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusLibuse()
        {
            if (tokeny >= cenaLodiLibuse)
            {
                neco.pocetLodiLibuse++;
                tokeny -= cenaLodiLibuse;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusLibuse()
        {
            if (neco.pocetLodiLibuse > 0)
            {
                neco.pocetLodiLibuse--;
                tokeny += cenaLodiLibuse;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusPalach()
        {
            if (tokeny >= cenaLodiPalach)
            {
                neco.pocetLodiPalach++;
                tokeny -= cenaLodiPalach;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusPalach()
        {
            if (neco.pocetLodiPalach > 0)
            {
                neco.pocetLodiPalach--;
                tokeny += cenaLodiPalach;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMasaryk()
        {
            if (tokeny >= cenaLodiMasaryk)
            {
                neco.pocetLodiMasaryk++;
                tokeny -= cenaLodiMasaryk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMasaryk()
        {
            if (neco.pocetLodiMasaryk > 0)
            {
                neco.pocetLodiMasaryk--;
                tokeny += cenaLodiMasaryk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusSvatopluk()
        {
            if (tokeny >= cenaLodiSvatopluk)
            {
                neco.pocetLodiSvatopluk++;
                tokeny -= cenaLodiSvatopluk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusSvatopluk()
        {
            if (neco.pocetLodiSvatopluk > 0)
            {
                neco.pocetLodiSvatopluk--;
                tokeny += cenaLodiSvatopluk;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusGott()
        {
            if (tokeny >= cenaLodiGott)
            {
                neco.pocetLodiGott++;
                tokeny -= cenaLodiGott;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusGott()
        {
            if (neco.pocetLodiGott > 0)
            {
                neco.pocetLodiGott--;
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
                neco.pocetLodiZatopek++;
                tokeny -= cenaLodiZatopek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusZatopek()
        {
            if (neco.pocetLodiZatopek > 0)
            {
                neco.pocetLodiZatopek--;
                tokeny += cenaLodiZatopek;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusOdysea()
        {
            if (tokeny >= cenaLodiOdysea)
            {
                neco.pocetLodiOdysea++;
                tokeny -= cenaLodiOdysea;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusOdysea()
        {
            if (neco.pocetLodiOdysea > 0)
            {
                neco.pocetLodiOdysea--;
                tokeny += cenaLodiOdysea;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusKarelIV()
        {
            if (tokeny >= cenaLodiKarelIV)
            {
                neco.pocetLodiKarelIV++;
                tokeny -= cenaLodiKarelIV;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusKarelIV()
        {
            if (neco.pocetLodiKarelIV > 0)
            {
                neco.pocetLodiKarelIV--;
                tokeny += cenaLodiKarelIV;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusZizka()
        {
            if (tokeny >= cenaLodiZizka)
            {
                neco.pocetLodiZizka++;
                tokeny -= cenaLodiZizka;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusZizka()
        {
            if (neco.pocetLodiZizka > 0)
            {
                neco.pocetLodiZizka--;
                tokeny += cenaLodiZizka;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiPlusNemcova()
        {
            if (tokeny >= cenaLodiNemcova)
            {
                neco.pocetLodiNemcova++;
                tokeny -= cenaLodiNemcova;
            }
            return RedirectToAction("Zvolit");
        }

        [HttpGet]
        public IActionResult KliknutiMinusNemcova()
        {
            if (neco.pocetLodiNemcova > 0)
            {
                neco.pocetLodiNemcova--;
                tokeny += cenaLodiNemcova;
            }
            return RedirectToAction("Zvolit");
        }
    }
}
