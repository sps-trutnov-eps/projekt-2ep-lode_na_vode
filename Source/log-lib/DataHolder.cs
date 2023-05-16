using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace log_lib {
    public class DataHolder {
        public List<string> nalepky;

        StreamReader hlaskySR;
        StreamReader nalepkySR;
        private Random Rnd;

        public DataHolder(string cestakLodim,string cestaKNalepkam){
            hlaskySR = new StreamReader(Path.GetFullPath(cestakLodim));
            nalepkySR = new StreamReader(Path.GetFullPath(cestaKNalepkam));
            Rnd = new Random();

            nalepky = getNalepky();
        }

        public string GetHlaska(string jmenoLodi, bool hitHlaska) {
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

                    //pro resetování readlinu na začátek souboru
                    hlaskySR.BaseStream.Seek(0, SeekOrigin.Begin); 
                    hlaskySR.DiscardBufferedData();
                }
           }
           }
           if (hitHlaska)
            return hitHlasky[Rnd.Next(0,hitHlasky.Length)];
           else
            return moveHlasky[Rnd.Next(0, moveHlasky.Length)];
        
        }
        public string GetHracBarva(string jmenoHrace) {
            return "a";
        }


        //vrátí seznam všech nálepek
        public List<string> getNalepky(){
            List<string> nalepky = new List<string>();
            string nalepka = "";
            
            while(true){
                string line = nalepkySR.ReadLine();

                if (line == null)
                    break;
                else if (line != ";")
                    nalepka += line + "\n";
                else
                {
                    nalepky.Add(nalepka);
                    nalepka = "";
                }                               
            }
            return nalepky;
        }
    }
}
