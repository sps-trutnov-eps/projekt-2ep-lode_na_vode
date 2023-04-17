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
    }
    public class TahController : Controller
    {


        public IActionResult Policko(int id)
        {
            TypPolicka[,] bojiste = new TypPolicka[15, 15];

            for(int y = 0; y < bojiste.GetLength(0); y++)
            {
                for(int x = 0; x < bojiste.GetLength(1); x++)
                {
                    bojiste[y, x] = TypPolicka.Voda;
                }
            }
            bojiste[6, 10] = TypPolicka.Lod;
            bojiste[4, 6] = TypPolicka.LodPotopena;
            bojiste[0, 14] = TypPolicka.ZasahMimo;
            bojiste[14, 1] = TypPolicka.ZasahLod;


            Debug.WriteLine(id);

            return View(bojiste);
        }
    }
}
