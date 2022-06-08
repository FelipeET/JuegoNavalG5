using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    public class ImpTab 
    {
        private Tablero B; //var que representa el tablero
        private int Width; //var que representa el ancho del tablero
        private int Height; //var que representa altura del tablero
        //public string[] alfabeto = {"0", "1", "2", "3", "4", "5"};
        public string[] numeros = {"0", "1", "2", "3", "4", "5"};
        public StringBuilder s = new StringBuilder();
        public ImpTab (Tablero b, int width, int height)
        {
            this.B = b;
            this.Width = width;
            this.Height = height;
        }
        
        public void ImpEnPnatalla()
        {
            //Console.Clear();
            //StringBuilder s = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                s.Append(numeros[y]);
                for (int x = 0; x < Width; x++)
                {
                    if(this.B.GetBoard()[x,y] == 0)
                    {
                        s.Append("|O|");
                        s.Append(" ");
                    }
                    if(this.B.GetBoard()[x,y] == 6)
                    {
                        s.Append("|O|");
                        s.Append(" ");
                    }
                    if(this.B.GetBoard()[x,y] == 1)
                    {
                        s.Append("|1|");
                        s.Append(" ");
                    }
                    if (this.B.GetBoard()[x,y] == 2)
                    {
                        s.Append("|2|");
                        s.Append(" "); 
                    }
                    if (this.B.GetBoard()[x,y] == 3)
                    {
                        s.Append("|3|");
                        s.Append(" "); 
                    }
                    if (this.B.GetBoard()[x,y] == 4)
                    {
                        s.Append("|4|");
                        s.Append(" ");
                    }
                    if (this.B.GetBoard()[x,y] == 5)
                    {
                        s.Append("|X|");
                        s.Append(" ");
                    }
                }
                s.Append("\n");
            }
            for (int z = 0; z<numeros.Length; z++)
            {
                s.Append("  ");
                s.Append(numeros[z]);
                s.Append(" ");
            }
            Console.WriteLine(s.ToString());
        }
    }
}


