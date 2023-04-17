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
        public string Ucitel;
        public string Hrac;

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
							// skip empty line
								if (line.Trim() == "")
									continue;

								// jinak  si kldně pokračuj
                LodHolder lodka = new LodHolder();
								lodka.ZbytekBodu = new List<int[]>();
                string[] splitLine = line.Split(":");
                string[] hlavicka = splitLine[0].Split(",");
                lodka.Jmeno = hlavicka[0].Trim();
                lodka.Typ = hlavicka[1].Trim();

                // ziskat body
                foreach (string bod in splitLine[1].Split(";")) {
									// když prázdno, skipni
									if (bod.Trim() == "")
										continue;

									string[] XY = bod.Split(",");
									// try adding int[x,y,funcno]
									try{
										lodka.ZbytekBodu.Add(new int[] {Int32.Parse(XY[0].Trim()),Int32.Parse(XY[1].Trim()),1});
									}
									catch{
										throw new Exception("Chybné souřadnice, prosím opravte");
									}

                }
								LodneHolrery.Add(lodka);
            }

            // když jsem nic nenačet, error
            if (LodneHolrery.Count ==0 )
                throw new Exception("Chybné file! Prosím o opravu.");
        }

				//////////////////
				// get nova lod //
				//////////////////
        public Lod NovaLod(int x, int y, string tvar , string hrac, string ucitel) {
					// check for ship in shipyard || something
					int shipIndex = -1;
					for (int i = 0; i < LodneHolrery.Count; i++)
						if (LodneHolrery[i].Jmeno == tvar){
							shipIndex = i;
							break;
						}
					// když tam není
					if (shipIndex == -1)
						throw new Exception("Ha-Ha Loď v loděnici nieje. Užijte si debugování!!!");

					// postavit loďku dle plánu
					Lod aaaa = new Lod() {Typ = LodneHolrery[shipIndex].Typ, Ucitel = ucitel, Hrac = hrac,
					 	CentralneBod = new int[] {x,y,1}, ZbytekBodu = LodneHolrery[shipIndex].ZbytekBodu.ToArray()};
					 return aaaa;
        }
    }

}
