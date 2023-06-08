namespace LodeNaVode.Lode
{

    struct Lod{
        int x, y;
        int[][] body; 
    }
    public class Rozmisteni
    {
        static List<int[]> pole;
        public static List<int[]> Rozmisti(int pocetLodiKrtecek, int pocetLodiMysicka, int pocetLodiVB)
        {
            while (true)
            {
                if (RozmisteniRealne())
                    return pole;
            }
        }

        static bool RozmisteniRealne(Lod[] LodeniceAsi)
        {
            int poleX = 37;
            int poleY = 37;
            int counterer = 0;
            int[,] FokinPole = new int[poleY,poleX];

            foreach (Lod l in LodeniceAsi)
            {
                break;
            }
        }
    }
}
