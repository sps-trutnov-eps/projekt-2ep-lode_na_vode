﻿using System.Diagnostics;

namespace LodeNaVode
{

    struct LodProRozmistovani
    {
        public int x = 0;
        public int y = 0;
        public int[][] body; // y,x

        public LodProRozmistovani(int[][] b)
        {
            body = b;
        }
    }
    public class RozmisteniClass
    {
        static List<int[]> poleLodi = new List<int[]>(); // x,y
        static Random random = new Random();
        public static List<int[]> /* x,y */ Rozmisti(int pocetLodiMetodej, int pocetLodiBorivoj, int pocetLodiCyril, int pocetLodiKrtecek, int pocetLodiIlias, int pocetLodiCapek, int pocetLodiVaclavII, int pocetLodiMacha, int pocetLodiLibuse, int pocetLodiPalach, int pocetLodiMasaryk, int pocetLodiSvatopluk, int pocetLodiGott, int pocetLodiZatopek, int pocetLodiOdysea, int pocetLodiKarelIV, int pocetLodiZizka, int pocetLodiNemcova)
        {

            // sepíšu tvary lodí
            List<LodProRozmistovani> lodnica = new List<LodProRozmistovani>();

            //Malé
            for (int i = 0; i < pocetLodiMetodej; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { }));
            }

            for (int i = 0; i < pocetLodiBorivoj; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } }));
            }

            for (int i = 0; i < pocetLodiCyril; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 } }));
            }

            //Střední
            for (int i = 0; i < pocetLodiKrtecek; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 } }));
            }

            for (int i = 0; i < pocetLodiIlias; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 } }));
            }

            for (int i = 0; i < pocetLodiCapek; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, 2 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 0, -1 }, new int[] { 1, -1 }, new int[] { 0, -2 } }));
            }

            for (int i = 0; i < pocetLodiVaclavII; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, 2 }, new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 0, -2 } }));
            }

            for (int i = 0; i < pocetLodiMacha; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } }));
            }

            for (int i = 0; i < pocetLodiLibuse; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, 2 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 2, 0 } }));
            }

            for (int i = 0; i < pocetLodiPalach; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 1, 2 }, new int[] { 0, 2 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 0, -2 } }));
            }

            for (int i = 0; i < pocetLodiMasaryk; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, 1 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 } }));
            }

            for (int i = 0; i < pocetLodiSvatopluk; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 1, 2 }, new int[] { 0, 2 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 }, new int[] { 1, -2 }, new int[] { 0, -2 } }));
            }

            for (int i = 0; i < pocetLodiGott; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { -1, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 1, -1 } }));
            }

            //Velké
            for (int i = 0; i < pocetLodiZatopek; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 }, new int[] { -1, -2 }, new int[] { 1, -2 }, new int[] { -1, 2 }, new int[] { 1, 2 } }));
            }

            for (int i = 0; i < pocetLodiOdysea; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { -1, 2 }, new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { -1, -2 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 }, new int[] { 1, -2 } }));
            }

            for (int i = 0; i < pocetLodiKarelIV; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 2, 1 }, new int[] { -1, 1 }, new int[] { -2, 1 }, new int[] { 0, -1 }, new int[] { 1 - 1 }, new int[] { 2, -1 }, new int[] { -1, -1 }, new int[] { -2, -1 } }));
            }

            for (int i = 0; i < pocetLodiZizka; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 1, -1 }, new int[] { 0, -1 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 0, -2 }, new int[] { 1, -2 } }));
            }

            for (int i = 0; i < pocetLodiNemcova; i++)
            {
                lodnica.Add(new LodProRozmistovani(new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 1 }, new int[] { 1, 1 }, new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 2 }, new int[] { 1, 2 }, new int[] { 1, -2 }, new int[] { -1, -2 } }));
            }





            // opakuju, dokud nenajdu kombinaci
            while (true)
            {
                // pročistim
                poleLodi.Clear();

                // randomizuji pořadí lodi
                lodnica = lodnica.OrderBy(_ => random.Next()).ToList();

                // tohle
                if (RozmisteniRealne(lodnica))
                    return poleLodi; // x,y
            }
        }

        static bool RozmisteniRealne(List<LodProRozmistovani> LodeniceAsi)
        {
            int poleX = 10;
            int poleY = 10;
            int counterer = 100;
            bool[,] fokinPole = new bool[poleY, poleX];

            int x, y;
            bool problemFound;

            foreach (LodProRozmistovani l in LodeniceAsi)
            {
                while (true)
                {
                    // aktualizuji promene
                    --counterer;
                    problemFound = false;
                    x = random.Next(poleX);
                    y = random.Next(poleY);

                    if (fokinPole[y, x] == false)
                    {
                        foreach (int[] i in l.body)
                        {
                            if (y + i[0] < 0 || y + i[0] >= poleY || x + i[1] < 0 || x + i[1] >= poleX || fokinPole[y + i[0], x + i[1]] == true)
                            {
                                problemFound = true;
                                break;
                            }
                        }

                        if (!problemFound)
                        {
                            // zapíšu aktuální loď do mapy
                            fokinPole[y, x] = true;
                            foreach (int[] i in l.body)
                                fokinPole[y + i[0], x + i[1]] = true;
                            poleLodi.Add(new int[] { x, y });
                            break;
                        }
                    }

                    if (counterer == 0)
                        return false;
                }
            }

            //for(int Y = 0; Y < poleY; Y++)
            //{
            //    for(int X = 0; X < poleX; X++)
            //    {
            //        if (fokinPole[Y,X])
            //            Debug.Write("#");
            //        else
            //            Debug.Write("-");
            //    }
            //    Debug.Write("\n");
            //}

            return true;
        }
    }
}
