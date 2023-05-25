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
            Engine engine = new Engine(mojeStringy, 15, 11, "../../Data/textury/tvary-lodi.TEXT", "LodeNaVode/Lode/hlasky.txt", "LodeNaVode/Lode/nalepky.txt");

            engine.UmistitLod(2, 5, "L", "a", "d");

            Debug.WriteLine("hi");

            return engine;

        }
    }

    public class TahController : Controller
    {
        public IActionResult Policko(int id)
        {

            Engine engine = Engin.engine;

            TypPolicka[,] bojiste = new TypPolicka[15, 11];

            for(int y = 0; y < bojiste.GetLength(0); y++)
            {
                for(int x = 0; x < bojiste.GetLength(1); x++)
                {
                    bojiste[y, x] = TypPolicka.Mlha;
                }
            }

            for(int i = 0; i < engine.Lode.Count; i++)
            {
                var lod = engine.Lode[i];

                bojiste[lod.CentralneBod[1], lod.CentralneBod[0]] = TypPolicka.Lod;
            }

            bojiste[2, 6] = TypPolicka.NepratelskaLod;

            int cislo = 0;
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
                            Debug.WriteLine($"{engine.PohybLode(0, "sever")}");
                            //engine.PohybLode(0, "sever");
                        }

                        /*if (policko == TypPolicka.Mlha)
                        {
                            policko = TypPolicka.Voda;
                        }*/


                        //bojiste[y, x] ==
                    }
                }
            }

            for (int i = 0; i < engine.Lode.Count; i++)
            {
                var lod = engine.Lode[i];

                bojiste[lod.CentralneBod[1], lod.CentralneBod[0]] = TypPolicka.Lod;
            }

            Debug.WriteLine(id);

            return View(bojiste);
        }
    }
}
