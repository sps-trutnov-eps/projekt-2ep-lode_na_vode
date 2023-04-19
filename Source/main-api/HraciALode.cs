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
				public string Tym;

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
				public int MaxX;
				public int MaxY;

        public GeneratorLodi(int maxx, int maxy,string cesta) {
						MaxX = maxx               ;
										MaxY = maxy      ;
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
        public Lod NovaLod(int x, int y, string tvar , string hrac, string ucitel,string tym, List<Lod> vsechnyLodi) {
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
					Lod titanic = new Lod() {Typ = LodneHolrery[shipIndex].Typ, Ucitel = ucitel, Hrac = hrac, Tym = tym,
					 	CentralneBod = new int[] {x,y,1}, ZbytekBodu = LodneHolrery[shipIndex].ZbytekBodu.ToArray()};

					// otestovat, jestli je v limitach
					if (!JeLodVMape(titanic))
						throw new Exception("Ha! Tvoje Loď je úplně mimo herní plochu.");
					if (JeLodVLodi(titanic, vsechnyLodi))
						throw new Exception("Jaksi máš loď v lodi a více rozměrů ti sem programovat fakt nechci. Prosím, pořešte si to na vaší straně.");

					// vrátit
					Console.WriteLine(MaxX.ToString()+ " " + MaxY,ToString());
					 return titanic;
        }

				public bool JeLodVMape(Lod lodka){
					// centralne bod
					if (!(lodka.CentralneBod[0] >= 0 && lodka.CentralneBod[0] <= MaxX
					   && lodka.CentralneBod[1] >= 0 && lodka.CentralneBod[1] <= MaxY))
					      return false;

					// zbytek bodů
					foreach (int[] bod in lodka.ZbytekBodu)
						if (!(lodka.CentralneBod[0]+bod[0] >= 0 && lodka.CentralneBod[0]+bod[0] <= MaxX
						   && lodka.CentralneBod[1]+bod[1] >= 0 && lodka.CentralneBod[1]+bod[1] <= MaxY))
						      return false;

					// jinak
					return true;
				}

				public bool JeLodVLodi(Lod lodka, List<Lod> vsechnyLodi){
					// sestavím soupis pozic všech kusů lodi na mapě, nikoliv relativně k centru lodi
					List<int[]> LodneKusy = new List<int[]>(){lodka.CentralneBod};
					foreach (int[] i in lodka.ZbytekBodu)
						LodneKusy.Add(new int[]{i[0]+lodka.CentralneBod[0], i[1]+lodka.CentralneBod[1]});

					// projdu všemi lodmi
					foreach (Lod kandidat in vsechnyLodi){
						// přezkočím tu loď, se kterou porovnávám
						// předpokládám, že jeden hráč může mít jednoho učitele jen jednou
						if (kandidat.Hrac == lodka.Hrac && kandidat.Ucitel == lodka.Ucitel)
							continue;

						// jinak porovnám proti centrálním bodům
						foreach (int[] bodyLodky in LodneKusy){
							if (bodyLodky[0] == kandidat.CentralneBod[0]
							 && bodyLodky[1] == kandidat.CentralneBod[1])
								return true;

							// a pak i proti zbytku kandidata
							foreach (int[] kandidatneBod in kandidat.ZbytekBodu)
									if (bodyLodky[0] == kandidatneBod[0] + kandidat.CentralneBod[0]
									 && bodyLodky[1] == kandidatneBod[1] + kandidat.CentralneBod[1])
										return true;
						}

					}

					// kdiž žádná kolize
					return false;
				}
    }

}
