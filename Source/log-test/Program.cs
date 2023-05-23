using log_lib;

namespace log_test {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            Log log = new Log("../../../data/hlasky.txt", "../../../data/nalepky.txt");
            
            string hitMessage = log.GetHitMessage("hrac1", "lod1");
            Console.WriteLine(hitMessage);

            string moveMessage = log.GetLodMovement("hrac1", "lod1");
            Console.WriteLine(moveMessage);

            string missStreakMessage = log.MissStreak("hrac1", 50);
            Console.WriteLine(missStreakMessage);

            string nalepka = log.ActivateNalepka("hrac1", 0);
            Console.WriteLine(nalepka);

            List<string> entireLog = log.GetEntireLog();
            foreach (string entry in entireLog)
                Console.WriteLine(entry);
        }
    }
}