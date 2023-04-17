using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace main_api {
    // Hrac //
    public struct Hrac {
        public string Jmeno;
        public string Tym;
    }
    // Lode //
    public struct Lod {
        public string Typ;
        public string ucitel;
        public string hrac;

        public int[] CentralneBod; // X,Y,funkčno (1/0)
        public int[][] ZbytekBodu;
    }

    public struct LodHolder {
        public string Typ;
        public string Jmeno;
        public List<int[]> ZbytekBodu;
    }

    public class GeneratorLodi {
        private List<LodHolder> LodneHolrery;
        public GeneratorLodi(string cesta) {
            // pokusím se načíst něco
            string[] file;
            try {
                file = File.ReadAllLines(cesta);
            // jinak se na to vy****
            } catch {
                throw new Exception("Chybné file! Prosím o opravu.");
            }
            // trimnu aby se nic nepokazilo
            for (int i = 0; i < file.Length; i++) {
                file[i] = file[i].Trim();
            }

            LodneHolrery = new List<LodHolder>();
            // projdu a poberu, co se dá
            foreach (string line in file) {
                LodHolder lodka = new LodHolder();
                string[] splitLine = line.Split(":");
                string[] hlavicka = splitLine[0].Split(",");
                lodka.Jmeno = hlavicka[0].Trim();
                lodka.Typ = hlavicka[1].Trim();

                // ziskat body
                foreach (string bod in splitLine[1].Split(";")) {


                }
                
            }

            // když jsem nic nenačet, error
            if (LodneHolrery.Count ==0 )
                throw new Exception("Chybné file! Prosím o opravu.");

        }

        public Lod NovaLod() {
            throw new NotImplementedException();
        }
    }

}
