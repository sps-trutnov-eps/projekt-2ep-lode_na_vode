﻿using main_api;

namespace main_api_test {
    class Program {
        static void Main(string[] args) {

            string[][] hraci = new string[4][];
            hraci[0] = new string[] { "Ty", "F" };
            hraci[1] = new string[] {"Sigmar Stefinsson","O"};
            hraci[2] = new string[] {"Kája","O"};
            hraci[3] = new string[] {"TenOravnyKidZeŠtvrtéTriddy","F"};

            Engine engine = new Engine(hraci,37,18,"tvary-lodi.TEXT","fddf","dgfg");

            Console.WriteLine(engine.Hraci.Count.ToString(),"ff");
            foreach (Hrac h in engine.Hraci) {
                Console.WriteLine(h.Jmeno+" "+h.Tym);
            }

						engine.UmistitLod(10,10,"L","TenOravnyKidZeŠtvrtéTriddy","Jan Ámos Komendský");

						Console.WriteLine(engine.StrelbaNaLod(-37,-37));
						Console.WriteLine(engine.StrelbaNaLod(10,10));
						Console.WriteLine(engine.StrelbaNaLod(11,11));
						Console.WriteLine(engine.StrelbaNaLod(13,12));

						Lod L = engine.Lode[0];
						Console.WriteLine(L.Typ+" "+L.Ucitel+" "+L.Hrac);
						Console.WriteLine(L.CentralneBod[0].ToString()+" "+L.CentralneBod[1].ToString()+" "+L.CentralneBod[2].ToString());
						foreach (int[] þ in L.ZbytekBodu){
						Console.WriteLine(þ[0].ToString()+" "+þ[1].ToString()+" "+þ[2].ToString());

						Console.WriteLine();

						Console.WriteLine(engine.DejMiAktualnehoHrace().Jmeno);
						engine.DalseHrac();
						Console.WriteLine(engine.DejMiAktualnehoHrace().Jmeno);
						engine.DalseHrac();
						Console.WriteLine(engine.DejMiAktualnehoHrace().Jmeno);
						engine.DalseHrac();
						Console.WriteLine(engine.DejMiAktualnehoHrace().Jmeno);
						engine.DalseHrac();
						Console.WriteLine(engine.DejMiAktualnehoHrace().Jmeno);
						}
        }
    }
}
