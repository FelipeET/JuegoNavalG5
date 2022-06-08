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
            /*Player p1 = new Player("pepe");
            Console.WriteLine(p1.Id);
            Console.WriteLine(p1.VP);*/
            Tablero tablero = new Tablero();
            Tablero tablero2 = new Tablero();
            tablero.ArmarTablero();
            tablero2.ArmarTablero();
            //PosValida valpos = new PosValida();
            //Console.WriteLine(valpos.DentroDeLimites(tablero, 1, 1));
            //Console.WriteLine(valpos.NoOcupada(tablero,1,1));
            PonerBarco poner = new PonerBarco();
            PonerBarco poner2 = new PonerBarco();

            poner.AgregarBraco(tablero, 0, 0, Orientacion.Horizontal, new Submarino());
            poner.AgregarBraco(tablero, 0, 4, Orientacion.Vertical, new PortaAviones());
            poner.AgregarBraco(tablero, 2, 3, Orientacion.Vertical, new Destructor());
            poner.AgregarBraco(tablero, 0, 5, Orientacion.Horizontal, new Buque());

            poner2.AgregarBraco(tablero2, 0, 0, Orientacion.Horizontal, new Submarino());
            poner2.AgregarBraco(tablero2, 0, 4, Orientacion.Vertical, new PortaAviones());
            poner2.AgregarBraco(tablero2, 2, 3, Orientacion.Vertical, new Destructor());
            poner2.AgregarBraco(tablero2, 0, 5, Orientacion.Horizontal, new Buque());

            Hit hit = new Hit();
            hit.Disparar(tablero, 0, 4);
            hit.Disparar(tablero, 5, 0);
            hit.Disparar(tablero2, 0, 4);
            hit.Disparar(tablero2, 5, 0);
            ImpTab imp1 = new ImpTab(tablero, tablero.Largo, tablero.Largo);
            ImpTabRival imp2 = new ImpTabRival(tablero, 6, 6);
            imp2.ImpEnPnatalla();
            Console.WriteLine("-------------------------");
            //imp1.ImpEnPnatalla();
            imp2.ImpActualizado();
            //Console.WriteLine(rut1.Content);
            //Console.WriteLine(rut1.ContentLines[0]);
        }
    }
}
