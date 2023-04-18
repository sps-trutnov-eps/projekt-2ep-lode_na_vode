using log_lib;

namespace main_api {
    public class Engine {

        private Log GetLog;
        public List<Hrac> Hraci {get;}
        public List<Lod> Lode {get;}
        private GeneratorLodi LodneGenerator;
				private int IndexHraceAktualneHrajiciho = 0;

        /// <summary>
        /// Tady v tomhle budete mít tu hru.
        /// </summary>
        /// <param name="hraci">pole polí stringů, [jmeno, tym]</param>
        /// <param name="maxX">maximální hodnota X, které lze dosáhnout</param>
        /// <param name="maxY">maximální hodnota Y, které lze dosáhnout</param>
        /// <param name="cestaKHlaskamLodi">cesta k jmenum a hlaskam lodi</param>
        ///  <param name="cestaKLodim">jo</param>
        /// <param name="cestaKNalepkam">cesta k hlaskam hracu</param>
        public Engine(string[][] hraci, int maxX, int maxY, string cestaKLodim, string cestaKHlaskamLodi, string cestaKNalepkam) {
            // načíst Log objekt
            GetLog = new Log(cestaKHlaskamLodi,cestaKNalepkam);

            // inicializovat lode
            Lode = new List<Lod>();
            LodneGenerator = new GeneratorLodi(maxX,maxY,cestaKLodim);

            // načíst jednotlive hrace jako structy
            Hraci = new List<Hrac>();
            foreach (string[] hrac in hraci) {
                Hraci.Add(new Hrac() { Jmeno = hrac[0], Tym = hrac[1] });
            }
        }

        /// <summary>
        /// prida lod ty magor
        /// </summary>
        /// <param name="x">hádej</param>
        /// <param name="y">hádej znova</param>
        /// <param name="tvar">podiskutuj s honzou</param>
        /// <param name="hrac">kdomji vlastni</param>
        /// <param name="ucitel">kdo na ni jede</param>
        /// <exception cref="NotImplementedException"></exception>
        public void UmistitLod(int x, int y, string tvar , string hrac, string ucitel) {
						Console.WriteLine(x.ToString()+" "+y.ToString()+" "+tvar+" "+hrac+" "+ucitel);
            Lode.Add(LodneGenerator.NovaLod(x, y, tvar ,hrac, ucitel,ZiskatTymZHraceStringu(hrac)));
        }

				public bool StrelbaNaLod(int x, int y) {
					// projdu lodi a zkontroluju, zda není hit
					for (int i = 0; i < Lode.Count; i++){

						// zkusím centrálné bod
						if (Lode[i].CentralneBod[0] == x && Lode[i].CentralneBod[1] == y){
							// když již zničen
							if (Lode[i].CentralneBod[2] == 0)
								return false;
							// jinak zničit
							else{
								Lode[i].CentralneBod[2] = 0;
								ZkusitZnicitLod(i);
								return true;
							}
						}

						// zkusím vedlejší body
						for (int j = 0; j < Lode[i].ZbytekBodu.Length; j++){
							if (Lode[i].ZbytekBodu[j][0]+Lode[i].CentralneBod[0] == x
									&& Lode[i].ZbytekBodu[j][1]+Lode[i].CentralneBod[1] == y){
								// když zničeno
								if (Lode[i].ZbytekBodu[j][2] == 0)
									return false;
								// když nezničeno
								else {
									Lode[i].ZbytekBodu[j][2] = 0;
									ZkusitZnicitLod(i);
									return true;
								}
							}
						}
					}

					// když netrefilo žádnou loď
					return false;
				}

				// toto tu je protože z důvodů neznámích vědě se M**rosoft rozhodl
				// neimplementovat možnost samostatných funkcí
				private void ZkusitZnicitLod(int indexLode){
					if (Lode[indexLode].CentralneBod[2] == 0){

						foreach (int[] þþ in Lode[indexLode].ZbytekBodu)
							if (þþ[2] != 0)
								return;

						Lode.RemoveAt(indexLode);
					}
				}

				public void DalseHrac(){
					IndexHraceAktualneHrajiciho++;
					if (IndexHraceAktualneHrajiciho > Hraci.Count-1)
						IndexHraceAktualneHrajiciho = 0;
				}

				public Hrac DejMiAktualnehoHrace(){
					return Hraci[IndexHraceAktualneHrajiciho];
				}

				public bool VyhralNekdo(){
					string? firstTeam = null;
					// projdu lodě
					foreach (Lod bot in Lode){
						// když první loďka, zapiš tým
						if (firstTeam == null)
							firstTeam = bot.Tym;
						// jinak když je jiný tým, tak ještě nikdo nevyhrál
						else if (firstTeam != bot.Tym)
							return false;
					}

					// Pokud se našal jen jeden tým, pak ale někdo vyhrál (nejspíš ten tým)
					return true;
				}

				public string ZiskatVytezneTym(){
					return Lode[0].Tym;
				}

				public string[] ZiskatVytezneHrace(){
					string tym = ZiskatVytezneTym();
					List<string> navratka = new List<string>();

					// projdu hrace a pridam ty se schodným týmem
					foreach (Hrac H in Hraci)
						if (H.Tym == tym)
							navratka.Add(H.Jmeno);

					// a navrátit návratku
					return navratka.ToArray();
				}

				private string ZiskatTymZHraceStringu(string hrac){
					foreach (Hrac H in Hraci){
						if (H.Jmeno == hrac)
							return H.Tym;
					}

					throw new Exception("Hráč nepůsobí zrovna validně...");
				}

        public bool PohybLode(int index, string smer) { // sever/vychod/jih/zapad
					switch (smer){
						case "sever":
							Lode[index].CentralneBod[1]--;
							if (!LodneGenerator.JeLodVMape(Lode[index])){
								Lode[index].CentralneBod[1]++;
								return false;
							}
							return true;

						case "vychod":
							Lode[index].CentralneBod[0]++;
							if (!LodneGenerator.JeLodVMape(Lode[index])){
								Lode[index].CentralneBod[0]--;
								return false;
							}
							return true;

						case "jih":
							Lode[index].CentralneBod[1]++;
							if (!LodneGenerator.JeLodVMape(Lode[index])){
								Lode[index].CentralneBod[1]--;
								return false;
							}
							return true;

						case "zapad":
							Lode[index].CentralneBod[0]--;
							if (!LodneGenerator.JeLodVMape(Lode[index])){
								Lode[index].CentralneBod[0]++;
								return false;
							}
							return true;

						default:
							throw new Exception("Špatná svetová strana šohajku!");
					}
        }




    }
}
