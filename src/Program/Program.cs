using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Felipe");
            Console.WriteLine(p1.Id);
            Console.WriteLine(p1.Name);
            Console.WriteLine(p1.VP);

            Board tablerop1 = new Board();
            tablerop1.BuildBoard();

            PlaceBoat poner = new PlaceBoat();
            poner.AddBoat(tablerop1, 1 , 1,Orientation.Horizontal, new Submarin());

            Hit hit1= new Hit();
            hit1.Shoot(tablerop1, 0 , 4);
            hit1.Shoot(tablerop1, 4 , 4);
        
            PrintBoard imp1 = new PrintBoard(tablerop1, tablerop1.Tamano);
            
            imp1.PrintInScreen();



        }
    }
}
