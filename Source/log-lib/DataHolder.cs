using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_lib {
    public struct Lod {
        string jmeno;
        string[] hlasky;
    }

    public struct Hrac {
        public string jmeno;
        public string barva;
    }

    internal class DataHolder {

        List<Lod> Lode;
        List<Hrac> Hraci;
        List<string> nalepky;

        public DataHolder(string cestakLodim,string cestaKNalepkam){
            Lode = new List<Lod>();
            Hraci = new List<Hrac>();
        }
        public string[] GetHlasky(string jmenoLodi) {

        }

        public string GetHracBarva(string jmenoHrace) {

        }

    }
}
