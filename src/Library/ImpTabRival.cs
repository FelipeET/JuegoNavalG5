using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    public class ImpTabRival 
    {
        private Tablero B; //var que representa el tablero
        private int Width; //var que representa el ancho del tablero
        private int Height; //var que representa altura del tablero
        public string[] numeros = {"0", "1", "2", "3", "4", "5"};
        public ImpTabRival (Tablero b, int width, int height)
        {
            this.B = b;
            this.Width = width;
            this.Height = height;
        }
        
        public void ImpEnPnatalla()
        {
            //Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < Height ; y++)
            {
                s.Append(numeros[y]);
                for (int x = 0; x < Width; x++)
                {
                        s.Append("| |");
                        s.Append(" ");
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

        public void ImpActualizado()
        {
            //Console.Clear();
            StringBuilder l = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                l.Append(numeros[y]);
                for (int x = 0; x < Width; x++)
                {
                    if(this.B.GetBoard()[x,y] == 0)
                    {
                        l.Append("| |");
                        l.Append(" ");
                    }
                    if(this.B.GetBoard()[x,y] == 6)
                    {
                        l.Append("|O|");
                        l.Append(" ");
                    }
                    if (this.B.GetBoard()[x,y] == 5)
                    {
                        l.Append("|X|");
                        l.Append(" ");
                    }
                    if(this.B.GetBoard()[x,y] == 1)
                    {
                        l.Append("| |");
                        l.Append(" ");
                    }
                    if (this.B.GetBoard()[x,y] == 2)
                    {
                        l.Append("| |");
                        l.Append(" "); 
                    }
                    if (this.B.GetBoard()[x,y] == 3)
                    {
                        l.Append("| |");
                        l.Append(" "); 
                    }
                    if (this.B.GetBoard()[x,y] == 4)
                    {
                        l.Append("| |");
                        l.Append(" ");
                    }
                }
                l.Append("\n");
            }
            for (int z = 0; z<numeros.Length; z++)
            {
                l.Append("  ");
                l.Append(numeros[z]);
                l.Append(" ");
            }
            Console.WriteLine(l.ToString());
        }


    }
}


