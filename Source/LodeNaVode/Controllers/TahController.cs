using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using main_api;

namespace LodeNaVode.Controllers
{
    public enum TypLode
    {
        Center,
        Left,
    }
    public enum TypPolicka
    {
        Lod,
        VedlejsiLod,
        NepratelskaLod,
        Voda,
        ZasahLod,
        LodPotopena,
        Mlha,
    }

    public class Engin{

        public static Engine engine = GetIT();
        private static Engine GetIT()
        {
            string[][] mojeStringy = new string[][] {
                new string[] { "a", "b" },
                new string[] { "c", "d" }
            };
            Engine engine = new Engine(mojeStringy, 10, 15, "../../Data/textury/tvary-lodi.TEXT", "LodeNaVode/Lode/hlasky.txt", "LodeNaVode/Lode/nalepky.txt");

            engine.UmistitLod(2, 5, "L", "a", "d");

            Debug.WriteLine("hi");

            return engine;

        }
    }

    public static class Pamet
    {
        public static int lodId = -1;
        public static bool oznacenaLod = false;
    }

    public class TahController : Controller
    {
        public void Redraw(ref TypPolicka[,] bojiste, ref Engine engine)
        {
            for (int y = 0; y < bojiste.GetLength(0); y++)
            {
                for (int x = 0; x < bojiste.GetLength(1); x++)
                {
                    bojiste[y, x] = TypPolicka.Mlha;
                }
            }

            for (int i = 0; i < engine.Lode.Count; i++)
            {
                var lod = engine.Lode[i];

                bojiste[lod.CentralneBod[1], lod.CentralneBod[0]] = TypPolicka.Lod;
            }
        }

        public IActionResult Policko(int id)
        {

            Debug.WriteLine(id);

            Engine engine = Engin.engine;
            ref int lodId = ref Pamet.lodId;
            ref bool oznacenaLod = ref Pamet.oznacenaLod;

            TypPolicka[,] bojiste = new TypPolicka[15, 10];

            Redraw(ref bojiste, ref engine);

            bojiste[2, 6] = TypPolicka.NepratelskaLod;

            int cislo = 0;
            

            // Pohyb lodě
            // Negativní id se používá jako ovládání
            // -1 == null
            // -2 otočit levá
            // -3 hore
            // -4 otočit pravá
            // -5 levá
            // -6 dolů
            // -7 pravá
            if(oznacenaLod) {
                oznacenaLod = false;
                switch(id)
                {
                    case -2:
                        engine.OtoceniVlevo(lodId);
                        break;

                    case -3:
                        engine.OtoceniVpravo(lodId);
                        break;

                    case -4:
                        engine.PohybLode(lodId, "sever");
                        break;

                    case -5:
                        engine.PohybLode(lodId, "jih");
                        break;
                }
            }

            // Procházení bojištěm
            for (int y = 0; y < bojiste.GetLength(0); y++)
            {
                for (int x = 0; x < bojiste.GetLength(1); x++, cislo++)
                {
                    if (id == cislo && bojiste[y, x] != null)
                    {
                        ref TypPolicka policko = ref bojiste[y, x];

                        if (policko == TypPolicka.NepratelskaLod)
                        {
                            policko = TypPolicka.ZasahLod;
                        }

                        if (policko == TypPolicka.Lod)
                        {
                            for (int i = 0; i < engine.Lode.Count; i++)
                            {
                                var lod = engine.Lode[i];

                                if (lod.CentralneBod[0] == x && lod.CentralneBod[1] == y)
                                {
                                    lodId = i;
                                    oznacenaLod = true;
                                }
                            }
                            Debug.WriteLine("LodID: " + lodId);
                            //engine.PohybLode(0, "jih");
                        }
                        else
                        {
                            oznacenaLod = false;
                        }

                        /*if (policko == TypPolicka.Mlha)
                        {
                            policko = TypPolicka.Voda;
                        }*/


                        //bojiste[y, x] ==
                    }
                }
            }

            Redraw(ref bojiste, ref engine);

            return View(bojiste);
        }
    }
}
