using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    public class ImpTab 
    {
        private bool[,] B; //var que representa el tablero
        private int Width; //var que representa el ancho del tablero
        private int Height; //var que representa altura del tablero

        public Logica Log;

        public ImpTab (bool[,] b, int width, int height, Logica log)
        {
            this.B = b;
            this.Width = width;
            this.Height = height;
            this.Log = log;

        }
        
        public void ImpEnPnatalla()
        {
            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if(this.B[x,y])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());
                this.B = Log.SigGen();
                Thread.Sleep(300);
            }
        }
        //Console.WriteLine(s.ToString());
        //=================================================
        //Invocar método para calcular siguiente generación
        //=================================================
        //Thread.Sleep(300);
    }
}

