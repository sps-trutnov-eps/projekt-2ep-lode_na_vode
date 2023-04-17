using main_api;

namespace main_api_test {
    class Program {
        static void Main(string[] args) {

            string[][] hraci = new string[3][];
            hraci[0] = new string[] { "Ty", "F" };
            hraci[1] = new string[] {"Sigmar Stefinsson","O"};
            hraci[2] = new string[] {"Kája","O"};

            Console.WriteLine("rffdf");
            Engine engine = new Engine(hraci,"fddf","dgfg");

            Console.WriteLine(engine.Hraci.Count.ToString(),"ff");
            foreach (Hrac h in engine.Hraci) {
                Console.WriteLine(h.Jmeno+" "+h.Tym);
            }
        }
    }
}