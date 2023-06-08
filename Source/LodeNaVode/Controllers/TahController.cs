﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using main_api;
using Microsoft.AspNetCore.Mvc.Formatters;

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

            engine.UmistitLod(2, 5, "L", "a", "d");
            engine.UmistitLod(5, 5, "L", "a", "d");

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
                    {
                        bojiste[y, x] = TypPolicka.Voda;
                        Debug.WriteLine("test1");
                    }
                    else
                        bojiste[y, x] = TypPolicka.Mlha;
                    //Debug.WriteLine("test");
                }
            }

            for (int i = 0; i < engine.Lode.Count; i++)
            {
                var lod = engine.Lode[i];

                bojiste[lod.CentralneBod[1], lod.CentralneBod[0]] = TypPolicka.Lod;
                if (lod.Smer == "sever")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot0";
                else if (lod.Smer == "zapad")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot90";
                else if (lod.Smer == "jih")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot180";
                else if (lod.Smer == "vychod")
                    config[lod.CentralneBod[1], lod.CentralneBod[0]] = "rot270";
            }
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
                            Debug.WriteLine("Výstřel do prázdna");
                            Debug.WriteLine($"{policko}");
                            policko = TypPolicka.Voda;
                            Debug.WriteLine($"{policko}");
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
                        Debug.WriteLine($"{policko}");
                    }
                }
            }

            Redraw(ref bojisteTuple, ref engine);
            Debug.WriteLine($"{bojiste[0, 0]}");

            return View(bojisteTuple);
        }
    }
}
