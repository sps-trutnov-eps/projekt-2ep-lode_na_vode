using log_lib;

namespace main_api {
    public class Engine {

        Log GetLog;
        public List<Hrac> Hraci;
        /// <summary>
        /// Tady v tomhle budete mít tu hru.
        /// </summary>
        /// <param name="hraci">pole polí stringů, [jmeno, tym]</param>
        /// <param name="cestaKHlaskamLodi">cesta k jmenum a hlaskam lodi</param>
        /// <param name="cestaKNalepkam">cesta k hlaskam hracu</param>
        public Engine(string[][] hraci, string cestaKHlaskamLodi,string cestaKNalepkam) {
            // nečíst Log objekt
            GetLog = new Log(cestaKHlaskamLodi,cestaKNalepkam);

            // načíst jednotlive hrace jako structy
            Hraci = new List<Hrac>();
            foreach (string[] hrac in hraci) {
                Hraci.Add(new Hrac() { Jmeno = hrac[0], Tym = hrac[1] });
            }
        }

        public void Strelba(int x, int y) { 
            throw new NotImplementedException();
        }

        public void UmistitLod(int x, int y) { 
            throw new NotImplementedException();
        }

        public void PohybLode() {
            throw new NotImplementedException();
        }

        public void DalseHrac() {
            throw new NotImplementedException();
        }
        






    }
}