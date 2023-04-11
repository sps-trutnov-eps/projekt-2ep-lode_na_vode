using System.Runtime.CompilerServices;

namespace log_lib {
    public class Log {

        private List<string> EntireLog;
        private DataHolder Lode;


        public Log(string cestaKLodim, string cestaKNalepkam) {
            EntireLog = new List<string>();
            Lode = new DataHolder(cestaKLodim,cestaKNalepkam);

        }

        public string GetHitMessage(string jmenoHrace, string jmenoLodi) {

        }

        public string[] GetEntireLog() {

        }

        public string GetLodMovement(string jmenoHrace, string jmenoLodi) {

        }

        public string MissStreak(string jmenoHrace, ushort pocetMisu) {

        }

        public string[] GetNalepky() {

        }

        public string ActivateNalepka(string jmenoHrace, string Nalepka) {

        }

    }
}