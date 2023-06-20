using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace log_lib {
    public class Log {

        public List<string> entireLog;
        public DataHolder Data;
        public string message;

        //Cesta k souborům je z lokace, kde je aplikace spuštěna
        public Log(string cestaKLodim, string cestaKNalepkam) {
            entireLog = new List<string>();
            Data = new DataHolder(cestaKLodim,cestaKNalepkam);            
        }

        public string GetHitMessage(string jmenoHrace, string jmenoLodi) {
            string hit = Data.GetHlaska(jmenoLodi,true);
            message = jmenoHrace + ":" + hit;
            entireLog.Add(message);
            return message;
        }

        public List<string> GetEntireLog() {
            return entireLog;
        }

        public string GetLodMovement(string jmenoHrace, string jmenoLodi) {
            string miss = Data.GetHlaska(jmenoLodi, false);
            message = jmenoHrace + ":" + miss;
            entireLog.Add(message);
            return message;
        }

        public string GetDestructionMessage(string jmenoHracePotopitele, string jmenoPotopeneLodi) {
            message = string.Format("{0} násilně potopil loď {1}, jednotky mrtvých!!", jmenoHracePotopitele, jmenoPotopeneLodi);
            entireLog.Add(message);
            return message;
        }

        public string MissStreak(string jmenoHrace, ushort pocetMisu) {
            message = String.Format("{0} už {1}krát minul, ukažte si na něj!", jmenoHrace, pocetMisu);
            entireLog.Add(message);
            return message;
        }
        public string ActivateNalepka(string jmenoHrace, int nalepkaIndex){
            message = jmenoHrace + ":\n" + Data.nalepky[nalepkaIndex];
            entireLog.Add(message);
            return message;
        }
    }
}