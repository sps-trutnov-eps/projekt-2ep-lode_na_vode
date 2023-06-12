using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using main_api;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing.Constraints;
using log_lib;

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
        ZasahLodCentalniBod,
        ZasahLodZbytekBod,
        LodPotopena,
        Mlha,
    }



    ////////////////////////
    // !!!!!NEKOUKAT!!!!! //
    ////////////////////////
    // Please I beg you ! //
    ////////////////////////


    public class Engin{

        public static Engine engine = GetIT();
        private static Engine GetIT()
        {
            string[][] mojeStringy = new string[][] {
                new string[] { "a", "b" },
                new string[] { "c", "d" }
            };
            Engine engine = new Engine(mojeStringy, 10, 15, "../../Data/textury/tvary-lodi.TEXT", "LodeNaVode/Lode/hlasky.txt", "LodeNaVode/Lode/nalepky.txt");

            engine.UmistitLod(2, 5, "L", "a", "c");
            engine.UmistitLod(10, 5, "P", "a", "c");
            //engine.UmistitLod(5, 5, "L", "a", "c");
            engine.UmistitLod(0, 1, "L", "c", "c");

            Debug.WriteLine("hi");

            return engine;

        }
    }

    public static class Pamet
    {
        public static int velikostX = 10;
        public static int velikostY = 15;
        public static int lodId = -1;
        public static bool oznacenaLod = false;
    }

    public class TahController : Controller
    {
        public void Redraw(ref Tuple<TypPolicka[,], string[,]> bojisteTuple, ref Engine engine)
        {
            if (bojisteTuple.Item1 == null) throw new Exception();

            TypPolicka[,] bojiste = bojisteTuple.Item1;
            string[,] config = bojisteTuple.Item2;

            for (int y = 0; y < bojiste.GetLength(0); y++)
            {
                for (int x = 0; x < bojiste.GetLength(1); x++)
                {
                    if (bojiste[y, x] == TypPolicka.Voda)
                        continue;
                    if (bojiste[y, x] == TypPolicka.ZasahLodCentalniBod)
                        continue;
                    if (bojiste[y, x] == TypPolicka.ZasahLodZbytekBod)
                        continue;
                    else
                        bojiste[y, x] = TypPolicka.Mlha;
                    //Debug.WriteLine("test");
                }
            }

            for (int i = 0; i < engine.Lode.Count; i++)
            {
                var lod = engine.Lode[i];

                if (lod.Hrac != "a")
                    continue;

                bojiste[lod.CentralneBod[1], lod.CentralneBod[0]] = TypPolicka.Lod;
                if (lod.Smer == "sever")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot0";
                else if (lod.Smer == "zapad")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot90";
                else if (lod.Smer == "jih")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot180";
                else if (lod.Smer == "vychod")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot270";

                for (int x = 0; x < lod.ZbytekBodu.Length; x++)
                {
                    int bx = 0;
                    int by = 0;
                    int bz = 0;
                    
                    for (int y = 0; y < lod.ZbytekBodu[x].Length; y++)
                    {
                        Debug.WriteLine($"{x};{y}     {lod.ZbytekBodu[x][y]}");

                        if (y == 0)
                            bx = lod.ZbytekBodu[x][y];
                        if (y == 1)
                            by = lod.ZbytekBodu[x][y];

                        //Debug.WriteLine($"{lod.ZbytekBodu[x][y]}    {lod.CentralneBod[1] + y};{lod.CentralneBod[0] + x}") ;
                    }

                    Debug.WriteLine("-------------");
                    //Debug.WriteLine($"{lod.CentralneBod[0]};{lod.CentralneBod[1]}   {lod.CentralneBod[0] + bx}({bx});{lod.CentralneBod[1] + by}({by})");
                    bojiste[lod.CentralneBod[1] + by, lod.CentralneBod[0] + bx] = TypPolicka.Lod;
                    if (lod.Smer == "sever")
                        config[lod.CentralneBod[1] + by, lod.CentralneBod[0] + bx] = "rot0";
                    else if (lod.Smer == "zapad")
                        config[lod.CentralneBod[1] + by, lod.CentralneBod[0] + bx] = "rot90";
                    else if (lod.Smer == "jih")
                        config[lod.CentralneBod[1] + by, lod.CentralneBod[0] + bx] = "rot180";
                    else if (lod.Smer == "vychod")
                        config[lod.CentralneBod[1] + by, lod.CentralneBod[0] + bx] = "rot270";
                }
            }
            Debug.WriteLine($"RedrawCompleted");
        }
        public IActionResult Policko(int id = -1)
        {
            Debug.WriteLine(id);

            Engine engine = Engin.engine;
            ref int lodId = ref Pamet.lodId;
            ref bool oznacenaLod = ref Pamet.oznacenaLod;

            Tuple<TypPolicka[,], string[,]> bojisteTuple = new Tuple<TypPolicka[,], string[,]>(new TypPolicka[Pamet.velikostX, Pamet.velikostY], new string[Pamet.velikostX, Pamet.velikostY]);

            Redraw(ref bojisteTuple, ref engine);

            TypPolicka[,] bojiste = bojisteTuple.Item1;
            string[,] config = bojisteTuple.Item2;

            int cislo = 0;
            

            // Pohyb lodě
            // Negativní id se používá jako ovládání
            // -1 == null
            // -2 otočit levá
            // -3 otočit pravá
            // -4 hore
            // -5 dolů
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
                        engine.Kupredu(lodId);
                        break;

                    case -5:
                        engine.Kuzadu(lodId);
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

                        if (policko == TypPolicka.Mlha)
                        {
                            if (engine.StrelbaNaLod(x, y))
                            {
                                for (int i = 0; i < engine.Lode.Count; i++)
                                {
                                    var lod = engine.Lode[i];

                                    if (lod.CentralneBod[0] == x && lod.CentralneBod[1] == y)
                                    {
                                        policko = TypPolicka.ZasahLodCentalniBod;
                                        break;
                                    }
                                    else
                                    {
                                        policko = TypPolicka.ZasahLodZbytekBod;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                policko = TypPolicka.Voda;                            
                            }
                            //Debug.WriteLine("Výstřel do prázdna");
                            //Debug.WriteLine($"{policko}");
                            //Debug.WriteLine($"{policko}");
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

            Redraw(ref bojisteTuple, ref engine);

            return View(bojisteTuple);
        }
    }
}
