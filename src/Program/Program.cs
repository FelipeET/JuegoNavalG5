
namespace PII_Batalla_Naval
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Player p1 = new Player("joaco");
            Player p2 = new Player("tareaP2");
            Game g1 = new Game(p1, p2);
            Logic log1 =  new Logic(g1);*/
            Board b1 = new Board();
            b1.BuildBoard();
            b1.AddBoat(b1, 5, 1, Orientation.Horizontal, new Carrier());
            b1.AddBoat(b1, 0, 0, Orientation.Horizontal, new Destructor());
            b1.Shoot(b1, 1, 1);
            b1.Shoot(b1, 5, 2);
            PrintBoard print = new PrintBoard(b1, b1.Length, b1.Length);
            print.PrintInScreen();
        }
    }
}
