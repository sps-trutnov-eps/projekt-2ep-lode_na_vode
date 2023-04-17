using log_lib;

namespace main_api {
    public class Engine {

        private Log GetLog;
        public List<Hrac> Hraci;
        public List<Lod> Lode;
        private GeneratorLodi LodneGenerator;

        /// <summary>
        /// Tady v tomhle budete mít tu hru.
        /// </summary>
        /// <param name="hraci">pole polí stringů, [jmeno, tym]</param>
        /// <param name="cestaKHlaskamLodi">cesta k jmenum a hlaskam lodi</param>
        ///  <param name="cestaKLodim">jo</param>
        /// <param name="cestaKNalepkam">cesta k hlaskam hracu</param>
        public Engine(string[][] hraci,string cestaKLodim , string cestaKHlaskamLodi,string cestaKNalepkam) {
            // načíst Log objekt
            GetLog = new Log(cestaKHlaskamLodi,cestaKNalepkam);

            // inicializovat lode
            Lode = new List<Lod>();
            LodneGenerator = new GeneratorLodi(cestaKLodim);

            // načíst jednotlive hrace jako structy
            Hraci = new List<Hrac>();
            foreach (string[] hrac in hraci) {
                Hraci.Add(new Hrac() { Jmeno = hrac[0], Tym = hrac[1] });
            }
        }

        public void Strelba(int x, int y) { 
            throw new NotImplementedException();
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
            Lode.Add(LodneGenerator.NovaLod(x, y, tvar ,hrac, ucitel));
        }

        public void PohybLode() {
            throw new NotImplementedException();
        }

        public void DalseHrac() {
            throw new NotImplementedException();
        }
        






    }
}
