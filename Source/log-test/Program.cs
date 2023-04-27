using log_lib;

namespace log_test {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            Log log = new Log("hlasky.txt", "nalepky.txt");

            Hrac hrac1 = new Hrac();
            hrac1.jmeno = "hrac1";
            Lod lod1 = log.data.GetHlasky("lod1");

            string hitMessage = log.GetHitMessage(hrac1, lod1);
            string moveMessage = log.GetLodMovement(hrac1, lod1);
            string missStreakMessage = log.MissStreak(hrac1.jmeno, 50);

            Console.WriteLine(hitMessage);
            Console.WriteLine(moveMessage);
            Console.WriteLine(missStreakMessage);
            Console.WriteLine(log.data.nalepky[1]);
        }
    }
}