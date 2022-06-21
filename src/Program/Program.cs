using System;

namespace PII_Batalla_Naval
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Player p1 = new Player("joaco");
            Player p2 = new Player("tareaP2");
            Game g1 = new Game(p1, p2);
            Logic log1 =  new Logic(g1);
            log1.LogGame();
            Console.Clear();
            log1.LetsPlay();
            Console.WriteLine(p1.PlayerBoard);*/

            BotInConsole.Instance.StartCommunication();
        }
    }
}
