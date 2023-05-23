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
        Voda,
        ZasahLod,
        LodPotopena,
        Mlha,
    }
    public class TahController : Controller
    {
        public IActionResult Policko(int id)
        {
            string[][] mojeStringy = new string[][] {
                new string[] { "a", "b" },
                new string[] { "c", "d" } 
            };
            Engine engine = new Engine(string);

            engine

            TypPolicka[,] bojiste = new TypPolicka[15, 11];

            for(int y = 0; y < bojiste.GetLength(0); y++)
            {
                for(int x = 0; x < bojiste.GetLength(1); x++)
                {
                    bojiste[y, x] = TypPolicka.Mlha;
                }
            }

            bojiste[6, 10] = TypPolicka.Lod;

            int cislo = 0;
            for(int y = 0; y < bojiste.GetLength(0); y++)
            {
                for (int x = 0; x < bojiste.GetLength(1); x++, cislo++)
                {
                    if (id == cislo && bojiste[y, x] != null)
                    {
                        ref TypPolicka policko = ref bojiste[y, x];

                        // mechanika sem, např: pokud klikne na mlhu tak vystřel

                        if (policko == TypPolicka.Lod)
                        {
                            policko = TypPolicka.ZasahLod;
                        }

                        if (policko == TypPolicka.Mlha)
                        {
                            policko = TypPolicka.Voda;
                        }
                        

                        //bojiste[y, x] ==
                    }
                }
            }

            Debug.WriteLine(id);

            return View(bojiste);
        }
    }
}
