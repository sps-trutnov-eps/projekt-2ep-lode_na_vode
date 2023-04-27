using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace log_lib {
    public struct Lod { 
        public string jmeno;
        public string[] hitHlasky;
        public string[] moveHlasky;
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

    public class DataHolder {

        List<Lod> Lode;
        List<Hrac> Hraci;
        List<string> nalepky;

        StreamReader hlaskySR;
        StreamReader nalepkySR;

        public DataHolder(string cestakLodim,string cestaKNalepkam){
            Lode = new List<Lod>();
            Hraci = new List<Hrac>();
            hlaskySR = new StreamReader(Path.GetFullPath(cestakLodim));
            nalepkySR = new StreamReader(Path.GetFullPath(cestaKNalepkam));
        }
        public Lod GetHlasky(string jmenoLodi) {
            bool read = true;
            string[] hitHlasky = new string[10];
            string[] moveHlasky = new string[10];
            while (read) {
                string line = hlaskySR.ReadLine();              
                if (line == jmenoLodi)
                {
                    hitHlasky = hlaskySR.ReadLine().Split(";");
                    moveHlasky = hlaskySR.ReadLine().Split(";");
                    read = false;             
                }
           }
           Lod jmenolodi = new Lod(jmenoLodi, hitHlasky, moveHlasky);
           return jmenolodi;
        }
        public string GetHracBarva(string jmenoHrace) {
            return "a";
        }

    }
}
