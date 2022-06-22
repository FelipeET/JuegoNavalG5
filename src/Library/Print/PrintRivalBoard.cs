using System;
using System.Text;

//clase que implementa IPrint y tiene los mismos atributos que PrintBoard, 
//solo que B ahora hace referencia al tablero del enemigo de un jugador.

namespace PII_Batalla_Naval
{
    public class PrintRivalBoard : IPrint
    {
        private Board B; //var que representa el tablero del enemigo
        private int Width; //var que representa el ancho del tablero
        private int Height; //var que representa altura del tablero
        public string[] numbers = {"0", "1", "2", "3", "4", "5"};

        //StringBuilder s = new StringBuilder();
        public PrintRivalBoard (Board b, int width, int height)
        {
            this.B = b;
            this.Width = width;
            this.Height = height;
        }

        /*
        método que nos permitirá imprimri en pantalla el tablero del rival a medida que este se actualiza 
        a lo largo de una partida. Para esto examina cada entrada del tablero B (matriz de enteros) y 
        en base al número de las mismas agregará un símbolo correspondiente al StringBuilder “s”.
        Si el número es:
            - entre 0 y 4 agrega “| |” (esa casilla del tablero permanece oculta/aun no se realizo un ataque a la misma)
            -6 agrega “|O|” (en esa casilla del tablero hay “Agua”).
            -5 agrega “|X|” (en esa casilla del tablero se a golpeado exitosamente una de las partes de un barco enemigo).
        */
        public void PrintInScreen()
        {
            StringBuilder s = new StringBuilder();
            
            for (int y = 0; y < Height; y++)
            {
                s.Append(numbers[y]);
                for (int x = 0; x < Width; x++)
                {
                    if(this.B.GetBoard()[x,y] >= 0 && this.B.GetBoard()[x,y] <=4 )
                    {
                        s.Append("| |");
                        s.Append(" ");
                    }
                    if(this.B.GetBoard()[x,y] == 6)
                    {
                        s.Append("|O|");
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
            for (int z = 0; z < numbers.Length; z++)
            {
                s.Append("  ");
                s.Append(numbers[z]);
                s.Append(" ");
            }
            Console.WriteLine(s.ToString());
        }

        //método que imprime el tablero del rival con todas las casillas ocultas (se usa únicamente en el primer turno de 
        //ambos jugadores pues en teoría estos aún no realizaron ningún ataque contra su rival).
        public void PrintHidden()
        {
            StringBuilder s = new StringBuilder();
            
            for (int y = 0; y < Height ; y++)
            {
                s.Append(numbers[y]);
                for (int x = 0; x < Width; x++)
                {
                    s.Append("| |");
                    s.Append(" ");
                }
                s.Append("\n");
            }
            for (int z = 0; z < numbers.Length; z++)
                {
                    s.Append("  ");
                    s.Append(numbers[z]);
                    s.Append(" ");
                }
            Console.WriteLine(s.ToString());
        }


    }
}


