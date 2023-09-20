using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LodeNaVode.Data;

namespace LodeNaVode.Controllers
{

    public class PripravaController : Controller
    {
        public static int tokeny = 100_000_000;
        //Malé
        public static int cenaLodiMetodej = 3_000_000;
        public static int pocetLodiMetodej = 0;
        public static int cenaLodiBorivoj = 6_000_000;
        public static int pocetLodiBorivoj = 0;
        public static int cenaLodiCyril = 4_000_000;
        public static int pocetLodiCyril = 0;
        //Střední
        public static int cenaLodiKrtecek = 10_000_000;
        public static int pocetLodiKrtecek = 0;
        public static int cenaLodiIlias = 12_000_000;
        public static int pocetLodiIlias = 0;
        public static int cenaLodiCapek = 9_000_000;
        public static int pocetLodiCapek = 0;
        public static int cenaLodiVaclavII = 14_000_000;
        public static int pocetLodiVaclavII = 0;
        public static int cenaLodiMacha = 13_000_000;
        public static int pocetLodiMacha = 0;
        public static int cenaLodiLibuse = 18_000_000;
        public static int pocetLodiLibuse = 0;
        public static int cenaLodiPalach = 10_000_000;
        public static int pocetLodiPalach = 0;
        public static int cenaLodiMasaryk = 13_000_000;
        public static int pocetLodiMasaryk = 0;
        public static int cenaLodiSvatopluk = 17_000_000;
        public static int pocetLodiSvatopluk = 0;
        public static int cenaLodiGott = 15_000_000;
        public static int pocetLodiGott = 0;
        //Velké
        public static int cenaLodiZatopek = 21_000_000;
        public static int pocetLodiZatopek = 0;
        public static int cenaLodiOdysea = 28_000_000;
        public static int pocetLodiOdysea = 0;
        public static int cenaLodiKarelIV = 26_000_000;
        public static int pocetLodiKarelIV = 0;
        public static int cenaLodiZizka = 24_000_000;
        public static int pocetLodiZizka = 0;
        public static int cenaLodiNemcova = 25_000_000;
        public static int pocetLodiNemcova = 0;

        private LobbyDbContext _lobbyDatabase;

        public PripravaController(LobbyDbContext lobbyDatabase)
        {
            _lobbyDatabase = lobbyDatabase;
        }

        [HttpGet]
        public IActionResult Vyber()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Rozmisteni()
        {
            // zjistime, za koho hrajeme
            Player currentPlayer = _lobbyDatabase.Players
                .Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid"))
                .First();

            // pripravime si prazdnou flotilu
            currentPlayer.Ships = new List<Ship>();

            // podle udaju z View flotilu naplnime lodemi
            for (int i = 0; i < pocetLodiMetodej; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Metodej });
            for (int i = 0; i < pocetLodiBorivoj; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Borivoj });
            for (int i = 0; i < pocetLodiCyril; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Cyril });
            for (int i = 0; i < pocetLodiKrtecek; i++)

                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Krtecek });
            for (int i = 0; i < pocetLodiIlias; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Ilias });
            for (int i = 0; i < pocetLodiCapek; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Capek });
            for (int i = 0; i < pocetLodiVaclavII; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.VaclavII });
            for (int i = 0; i < pocetLodiMacha; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Macha });
            for (int i = 0; i < pocetLodiLibuse; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Libuse });
            for (int i = 0; i < pocetLodiPalach; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Palach });
            for (int i = 0; i < pocetLodiMasaryk; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Masaryk });
            for (int i = 0; i < pocetLodiSvatopluk; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Svatopluk });
            for (int i = 0; i < pocetLodiGott; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Gott });

            for (int i = 0; i < pocetLodiZatopek; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Zatopek });
            for (int i = 0; i < pocetLodiOdysea; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Odysea });
            for (int i = 0; i < pocetLodiKarelIV; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.KarelIV });
            for (int i = 0; i < pocetLodiZizka; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Zizka });
            for (int i = 0; i < pocetLodiNemcova; i++)
                currentPlayer.Ships.Add(new Ship { ShipClass = JmenoLode.Nemcova });

            // ulozime lode do databaze
            _lobbyDatabase.SaveChanges();

            // rozmistime lode (TO DO - dela engine)
            // List<int[]> L = RozmisteniClass.Rozmisti(pocetLodiMetodej, pocetLodiBorivoj, pocetLodiCyril, pocetLodiKrtecek, pocetLodiIlias, pocetLodiCapek, pocetLodiVaclavII, pocetLodiMacha, pocetLodiLibuse, pocetLodiPalach, pocetLodiMasaryk, pocetLodiSvatopluk, pocetLodiGott, pocetLodiZatopek, pocetLodiOdysea, pocetLodiKarelIV, pocetLodiZizka, pocetLodiNemcova);

            // automaticky pokracujeme na dalsi obrazovku
            return Redirect("/Priprava/Cekani");
        }

        [HttpGet]
        public IActionResult Cekani()
        {
            // kdo jsem
            Player? currentPlayer = _lobbyDatabase.Players
                .Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid"))
                .FirstOrDefault();
            // kde jsem
            Lobby currentLobby = _lobbyDatabase.Lobbies
                .Where(l => l.Players.Contains(currentPlayer))
                .First();

            // kontrolujeme, jestli vsichni hraci v lobby uz maji sve lode
            foreach (Player p in currentLobby.Players)
                if (p.Ships.Count == 0)
                    return View(); // vsichni jeste nejsou pripraveni

            // hraci jsou vsichni pripraveni, jdeme do hry
            return Redirect("/Tah/Policko");
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
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMetodej()
        {
            if (pocetLodiMetodej > 0)
            {
                pocetLodiMetodej--;
                tokeny += cenaLodiMetodej;
            }
            return RedirectToAction("Vyber");
        }
        [HttpGet]
        public IActionResult KliknutiPlusBorivoj()
        {
            if (tokeny >= cenaLodiBorivoj)
            {
                pocetLodiBorivoj++;
                tokeny -= cenaLodiBorivoj;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusBorivoj()
        {
            if (pocetLodiBorivoj > 0)
            {
                pocetLodiBorivoj--;
                tokeny += cenaLodiBorivoj;
            }
            return RedirectToAction("Vyber");
        }
        [HttpGet]
        public IActionResult KliknutiPlusCyril()
        {
            if (tokeny >= cenaLodiCyril)
            {
                pocetLodiCyril++;
                tokeny -= cenaLodiCyril;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusCyril()
        {
            if (pocetLodiCyril > 0)
            {
                pocetLodiCyril--;
                tokeny += cenaLodiCyril;
            }
            return RedirectToAction("Vyber");
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
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusKrtecek()
        {
            if (pocetLodiKrtecek > 0)
            {
                pocetLodiKrtecek--;
                tokeny += cenaLodiKrtecek;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusIlias()
        {
            if (tokeny >= cenaLodiIlias)
            {
                pocetLodiIlias++;
                tokeny -= cenaLodiIlias;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusIlias()
        {
            if (pocetLodiIlias > 0)
            {
                pocetLodiIlias--;
                tokeny += cenaLodiIlias;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusCapek()
        {
            if (tokeny >= cenaLodiCapek)
            {
                pocetLodiCapek++;
                tokeny -= cenaLodiCapek;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusCapek()
        {
            if (pocetLodiCapek > 0)
            {
                pocetLodiCapek--;
                tokeny += cenaLodiCapek;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusVaclavII()
        {
            if (tokeny >= cenaLodiVaclavII)
            {
                pocetLodiVaclavII++;
                tokeny -= cenaLodiVaclavII;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusVaclavII()
        {
            if (pocetLodiVaclavII > 0)
            {
                pocetLodiVaclavII--;
                tokeny += cenaLodiVaclavII;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMacha()
        {
            if (tokeny >= cenaLodiMacha)
            {
                pocetLodiMacha++;
                tokeny -= cenaLodiMacha;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMacha()
        {
            if (pocetLodiMacha > 0)
            {
                pocetLodiMacha--;
                tokeny += cenaLodiMacha;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusLibuse()
        {
            if (tokeny >= cenaLodiLibuse)
            {
                pocetLodiLibuse++;
                tokeny -= cenaLodiLibuse;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusLibuse()
        {
            if (pocetLodiLibuse > 0)
            {
                pocetLodiLibuse--;
                tokeny += cenaLodiLibuse;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusPalach()
        {
            if (tokeny >= cenaLodiPalach)
            {
                pocetLodiPalach++;
                tokeny -= cenaLodiPalach;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusPalach()
        {
            if (pocetLodiPalach > 0)
            {
                pocetLodiPalach--;
                tokeny += cenaLodiPalach;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusMasaryk()
        {
            if (tokeny >= cenaLodiMasaryk)
            {
                pocetLodiMasaryk++;
                tokeny -= cenaLodiMasaryk;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusMasaryk()
        {
            if (pocetLodiMasaryk > 0)
            {
                pocetLodiMasaryk--;
                tokeny += cenaLodiMasaryk;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusSvatopluk()
        {
            if (tokeny >= cenaLodiSvatopluk)
            {
                pocetLodiSvatopluk++;
                tokeny -= cenaLodiSvatopluk;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusSvatopluk()
        {
            if (pocetLodiSvatopluk > 0)
            {
                pocetLodiSvatopluk--;
                tokeny += cenaLodiSvatopluk;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusGott()
        {
            if (tokeny >= cenaLodiGott)
            {
                pocetLodiGott++;
                tokeny -= cenaLodiGott;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusGott()
        {
            if (pocetLodiGott > 0)
            {
                pocetLodiGott--;
                tokeny += cenaLodiGott;
            }
            return RedirectToAction("Vyber");
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
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusZatopek()
        {
            if (pocetLodiZatopek > 0)
            {
                pocetLodiZatopek--;
                tokeny += cenaLodiZatopek;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusOdysea()
        {
            if (tokeny >= cenaLodiOdysea)
            {
                pocetLodiOdysea++;
                tokeny -= cenaLodiOdysea;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusOdysea()
        {
            if (pocetLodiOdysea > 0)
            {
                pocetLodiOdysea--;
                tokeny += cenaLodiOdysea;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusKarelIV()
        {
            if (tokeny >= cenaLodiKarelIV)
            {
                pocetLodiKarelIV++;
                tokeny -= cenaLodiKarelIV;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusKarelIV()
        {
            if (pocetLodiKarelIV > 0)
            {
                pocetLodiKarelIV--;
                tokeny += cenaLodiKarelIV;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusZizka()
        {
            if (tokeny >= cenaLodiZizka)
            {
                pocetLodiZizka++;
                tokeny -= cenaLodiZizka;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusZizka()
        {
            if (pocetLodiZizka > 0)
            {
                pocetLodiZizka--;
                tokeny += cenaLodiZizka;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiPlusNemcova()
        {
            if (tokeny >= cenaLodiNemcova)
            {
                pocetLodiNemcova++;
                tokeny -= cenaLodiNemcova;
            }
            return RedirectToAction("Vyber");
        }

        [HttpGet]
        public IActionResult KliknutiMinusNemcova()
        {
            if (pocetLodiNemcova > 0)
            {
                pocetLodiNemcova--;
                tokeny += cenaLodiNemcova;
            }
            return RedirectToAction("Vyber");
        }
    }
}
