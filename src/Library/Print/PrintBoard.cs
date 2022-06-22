using System;
using System.Text;

//clase que implementa IPrint

namespace PII_Batalla_Naval
{
    public class PrintBoard : IPrint
    {
        private Board B; //var que representa el tablero
        private int Width; //var que representa el ancho del tablero
        private int Height; //var que representa altura del tablero
        public string[] numbers = {"0", "1", "2", "3", "4", "5"};

        //public StringBuilder s = new StringBuilder();
        public PrintBoard (Board b, int width, int height)
        {
            this.B = b;
            this.Width = width;
            this.Height = height;
        }
        /*
        método que nos permitirá imprimri en pantalla nuestro tablero a lo largo de una partida. Para esto examina cada entrada del tablero B (matriz de enteros) y en base al número de las mismas agregará un símbolo correspondiente al StringBuilder “s”. 
        Si el número es:
            - 0 o 6 agrega “|O|” (en esa casilla del tablero hay “Agua”)
            -1 agrega “|1|” (en esa casilla del tablero se encuentra ubicado un Buque).
            -2 agrega “|2|” (en esa casilla del tablero se encuentra ubicado una parte del Submarino).
            -3 agrega “|3|” (en esa casilla del tablero se encuentra ubicado una parte del Destructor).
            -4 agrega “|4|” (en esa casilla del tablero se encuentra ubicado una parte del Porta Aviones).
            -5 agrega “|X|” (en esa casilla del tablero el enemigo a golpeado exitosamente una parte de tus barco).
        */
        public void PrintInScreen()
        {
            StringBuilder s = new StringBuilder();
            
            for (int y = 0; y < Height; y++)
            {
                s.Append(numbers[y]);
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
            for (int z = 0; z<numbers.Length; z++)
            {
                s.Append("  ");
                s.Append(numbers[z]);
                s.Append(" ");
            }
            Console.WriteLine(s.ToString());
        }
    }
}


