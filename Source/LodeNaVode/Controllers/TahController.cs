using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using main_api;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing.Constraints;
using log_lib;
using LodeNaVode.Data;
using LodeNaVode.Models;

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
        public static int pocetLodi; // jen pro log
        private static Engine GetIT()
        {
            string hrac = "ahoj5";
            string hrac2 = "1ahoj";

            string[][] mojeStringy = new string[][] {
                new string[] { hrac, "b" },
                new string[] { hrac2, "d" }
            };
            Engine engine = new Engine(mojeStringy, 14, 9, "../../Data/textury/tvary-lodi.TEXT", "LodeNaVode/Lode/hlasky.txt", "LodeNaVode/Lode/nalepky.txt");

            engine.UmistitLod(2, 5, "L", hrac, "kotek");
            engine.UmistitLod(10, 5, "P", hrac, "kotek");
            //engine.UmistitLod(5, 5, "L", "a", "c");
            engine.UmistitLod(0, 1, "L", hrac2, "kotek");

            //Debug.WriteLine("hi");

            pocetLodi = engine.Lode.Count();
            return engine;

        }
    }

    public static class Pamet
    {
        public static List<Tuple<int, int, TypPolicka>> odhalenePolicka = new List<Tuple<int, int, TypPolicka>>();
        public static int velikostX = 10;
        public static int velikostY = 15;
        public static int lodId = -1;
        public static bool oznacenaLod = false;
    }

    public class TahController : Controller
    {
        private Engine engine;

        public TahController()
        {
            // pri kazdem pozadavku na controller vyzvedneme ID prislusneho lobby
            string? lobbyId = HttpContext.Session.GetString("lobbyid");

            // pripravime si promennou, abychom meli pristup k enginu
            engine = Program.KolekceEnginu["${lobbyId}"];
            // ze by ID neexistovalo, neresime
        }

        public void Redraw(ref Tuple<TypPolicka[,], string[,]> bojisteTuple, ref Engine engine)
        {
            _lobbyDatabase = dbContext;
        }

        public void Redraw(ref Tuple<TypPolicka[,], string[,]> bojisteTuple, ref Engine engine, ref List<Tuple<int, int, TypPolicka>> odhalenaPolicka)
        {
            Player nasHrac = _lobbyDatabase.Players.Where(p => p.PlayerCookie == HttpContext.Session.GetString("playerid")).First();
            Lobby naseLobby = _lobbyDatabase.Lobbies.Where(l => l.Players.Contains(nasHrac)).First();

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

            // Jen nakresli políčka kam jsi klikal
            if (odhalenaPolicka != null)
            {
                for (int i = 0; i < odhalenaPolicka.Count; i++)
                {
                    Tuple<int, int, TypPolicka> odhalenePolicko = odhalenaPolicka[i];

                    bojiste[odhalenePolicko.Item2, odhalenePolicko.Item1] = odhalenePolicko.Item3;
                }   
            }
            // Nakresli lodě (přátelské)
            for (int i = 0; i < engine.Lode.Count; i++)
            {
                var lod = engine.Lode[i];


                if (lod.Hrac != nasHrac.PlayerName)
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
                    // proč b? nemyslels d, jakožto delta?
                    int bx = 0;
                    int by = 0;
                    int bz = 0; // lodě jsou pouze dvojrozměrné
                    
                    for (int y = 0; y < lod.ZbytekBodu[x].Length; y++)
                    {
                        //Debug.WriteLine($"{x};{y}     {lod.ZbytekBodu[x][y]}");

                        if (y == 0)
                            bx = lod.ZbytekBodu[x][y];
                        if (y == 1)
                            by = lod.ZbytekBodu[x][y];

                        //Debug.WriteLine($"{lod.ZbytekBodu[x][y]}    {lod.CentralneBod[1] + y};{lod.CentralneBod[0] + x}") ;
                    }

                    //Debug.WriteLine("-------------");
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
            //Debug.WriteLine($"RedrawCompleted");
        }

        public IActionResult NalepkySiVyberTyMagor() {
            return View();
        }
        public IActionResult Policko(int id = -1) {
            Engine engine = Engin.engine;

            // ze session zjistime ID naseho lobby
            int lobbyId = Convert.ToInt32(HttpContext.Session.GetString("lobbyid"));
            // nacteme si prislusny engine
            Engine engine = Program.KolekceEnginu[lobbyId.ToString()];

            ref int lodId = ref Pamet.lodId;
            ref bool oznacenaLod = ref Pamet.oznacenaLod;
            ref List<Tuple<int, int, TypPolicka>> odhalenePolicka = ref Pamet.odhalenePolicka;

            Tuple<TypPolicka[,], string[,]> bojisteTuple = new Tuple<TypPolicka[,], string[,]>
                (new TypPolicka[Pamet.velikostX, Pamet.velikostY],
                new string[Pamet.velikostX, Pamet.velikostY]);

            Redraw(ref bojisteTuple, ref engine, ref odhalenePolicka);

            TypPolicka[,] bojiste = bojisteTuple.Item1;
            string[,] config = bojisteTuple.Item2;

            int cislo = 0;
            

            if (id < -100) {
                engine.GetLog.ActivateNalepka(engine.DejMiAktualnehoHrace().Jmeno,-(id+100));

                return View(bojisteTuple);
            }

            // Pohyb lodě
            // Negativní id se používá jako ovládání
            // -1 == null
            // -2 otočit levá
            // -3 otočit pravá
            // -4 hore
            // -5 dolů

            // -100 a nižší nalepky
            if(oznacenaLod) {
                Lod l = engine.Lode[lodId];
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
                        engine.GetLog.GetLodMovement(l.Hrac,l.Ucitel);
                        break;

                    case -5:
                        engine.Kuzadu(lodId);
                        engine.GetLog.GetLodMovement(l.Hrac,l.Ucitel);
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
                            if (engine.StrelbaNaLod(x, y)) {
                                // log
                                if (engine.Lode.Count() < Engin.pocetLodi) {
                                    Engin.pocetLodi = engine.Lode.Count();
                                    Lod l = engine.NaposledyTrefenaLod;
                                    engine.GetLog.GetDestructionMessage(engine.DejMiAktualnehoHrace().Jmeno,l.Ucitel);
                                }
                                else {
                                    Lod l = engine.NaposledyTrefenaLod;
                                    engine.GetLog.GetHitMessage(l.Hrac,l.Ucitel);
                                }
                                for (int i = 0; i < engine.Lode.Count; i++)
                                {
                                    var lod = engine.Lode[i];
                                    policko = TypPolicka.ZasahLodZbytekBod;

                                    Lod l = engine.Lode[i];
                                    engine.GetLog.GetHitMessage(l.Hrac, l.Ucitel);

                                    odhalenePolicka.Add(new Tuple<int, int, TypPolicka>(x, y, TypPolicka.ZasahLodZbytekBod));
                                    if (lod.CentralneBod[0] == x && lod.CentralneBod[1] == y)
                                    {
                                        policko = TypPolicka.ZasahLodCentalniBod;
                                        odhalenePolicka.Add(new Tuple<int, int, TypPolicka>(x, y, TypPolicka.ZasahLodCentalniBod));
                                    }

                                }
                            }
                            else
                            {
                                policko = TypPolicka.Voda;
                                odhalenePolicka.Add(new Tuple<int, int, TypPolicka>(x, y, TypPolicka.Voda));
                            }
                            //Debug.WriteLine("Výstřel do prázdna");
                            //Debug.WriteLine($"{policko}");
                            //Debug.WriteLine($"{policko}");
                        }

                        if (policko == TypPolicka.Lod) {
                            for (int i = 0; i < engine.Lode.Count; i++) {
                                var lod = engine.Lode[i];

                                if (lod.CentralneBod[0] == x && lod.CentralneBod[1] == y) {
                                    lodId = i;
                                    oznacenaLod = true;
                                    break;
                                }
                                for (int X = 0; X < lod.ZbytekBodu.Length; X++)
                                // ano, jen jsem to zkopíroval
                                // pokud se ti to nelíbí, tak si to přepiš
                                {
                                    int bx = 0;
                                    int by = 0;

                                    for (int Y = 0; Y < lod.ZbytekBodu[X].Length; Y++) {

                                        if (Y == 0)
                                            bx = lod.ZbytekBodu[X][Y];
                                        if (Y == 1)
                                            by = lod.ZbytekBodu[X][Y];

                                    }
                                    if (lod.CentralneBod[1] + by == y && lod.CentralneBod[0] + bx == x) {
                                        lodId = i;
                                        oznacenaLod = true;
                                        break;
                                    }
                                }
                                if (oznacenaLod)
                                    break;
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

            Redraw(ref bojisteTuple, ref engine, ref odhalenePolicka);

            return View(bojisteTuple);
        }
    }
}
