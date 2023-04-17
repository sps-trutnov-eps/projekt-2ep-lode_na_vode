using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace log_lib {
    public class Log {

        private List<string> EntireLog;
        public DataHolder Lode;
        private Random rnd;

        public Log(string cestaKLodim, string cestaKNalepkam) {
            EntireLog = new List<string>();
            Lode = new DataHolder(cestaKLodim,cestaKNalepkam);
            rnd = new Random();
        }

        public string GetHitMessage(Hrac hrac, Lod lod) {
            string message;
            string hit = lod.hitHlasky[rnd.Next(0, lod.hitHlasky.Length)];
            message = hrac.jmeno + ":" + hit;
            EntireLog.Add(message);
            return message;
        }

        public List<string> GetEntireLog() {
            return EntireLog;
        }

        public string GetLodMovement(Hrac hrac, Lod lod) {
            string message;
            string miss = lod.hitHlasky[rnd.Next(0, lod.hitHlasky.Length)];
            message = hrac.jmeno + ":" + miss;
            EntireLog.Add(message);
            return message;
        }

        public string MissStreak(string jmenoHrace, ushort pocetMisu) {
            return "missstreak";
        }

        public string[] GetNalepky() {
            string[] a = new string[5];
            return a;
        }

        public string ActivateNalepka(string jmenoHrace, string Nalepka) {
            return "a";
        }

    }
}