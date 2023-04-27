using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LodeNaVode.Controllers
{
    public enum TypPolicka
    {
        Lod,
        Voda,
        ZasahMimo,
        ZasahLod,
        LodPotopena,
        Mlha,
    }
    public class TahController : Controller
    {


        public IActionResult Policko(int id)
        {
            TypPolicka[,] bojiste = new TypPolicka[15, 11];

            for(int y = 0; y < bojiste.GetLength(0); y++)
            {
                for(int x = 0; x < bojiste.GetLength(1); x++)
                {
                    bojiste[y, x] = TypPolicka.Mlha;
                }
            }
            bojiste[6, 10] = TypPolicka.Lod;
            bojiste[4, 6] = TypPolicka.LodPotopena;
            bojiste[0, 10] = TypPolicka.ZasahMimo;
            bojiste[14, 1] = TypPolicka.ZasahLod;

            int cislo = 0;
            for(int y = 0; y < bojiste.GetLength(0); y++)
            {
                for (int x = 0; x < bojiste.GetLength(1); x++, cislo++)
                {
                    if (id == cislo)
                    {
                        // mechanika sem, např: pokud klikne na mlhu tak vystřel
                        
                        //bojiste[y, x] ==
                    }
                }
            }

            Debug.WriteLine(id);

            return View(bojiste);
        }
    }
}
