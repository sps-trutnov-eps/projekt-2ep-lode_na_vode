using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_lib {
    public struct Lod { 
        string jmeno;
        string[] hitHlasky;
        string[] moveHlasky;
        public Lod(string jmeno, string[] hit, string[] move)
        {
            this.jmeno = jmeno;
            hitHlasky = hit;
            moveHlasky = move;
        }
    }
    public struct Hrac {
        public string jmeno;
        public string barva;
    }

    internal class DataHolder {

        List<Lod> Lode;
        List<Hrac> Hraci;
        List<string> nalepky;

        StreamReader hlaskySR;
        StreamReader nalepkySR;

        public DataHolder(string cestakLodim,string cestaKNalepkam){
            Lode = new List<Lod>();
            Hraci = new List<Hrac>();
            StreamReader hlaskySR = new StreamReader(cestakLodim);
            StreamReader nalepkySR = new StreamReader(cestaKNalepkam);

        }
        public Lod GetHlasky(string jmenoLodi) {
            string jmeno = jmenoLodi;
            string[] hitHlasky = new string[10];
            string[] moveHlasky = new string[10];
            while (hlaskySR.ReadLine() != null) {
                if (hlaskySR.ReadLine() == jmenoLodi)
                {
                    hitHlasky = hlaskySR.ReadLine().Split(";");
                    moveHlasky = hlaskySR.ReadLine().Split(";");
                }
            }
            Lod lod = new Lod(jmenoLodi, hitHlasky, moveHlasky);
            return lod;
        }
        public string GetHracBarva(string jmenoHrace) {

        }

    }
}
