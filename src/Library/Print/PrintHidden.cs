using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    public class PrintHidden : IPrint
    {
        private Board B; //var que representa el tablero
        private int Width; //var que representa el ancho del tablero
        private int Height; //var que representa altura del tablero
        public string[] numbers = {"0", "1", "2", "3", "4", "5"};

        //public StringBuilder s = new StringBuilder();
        public PrintHidden (Board b, int width, int height)
        {
            this.B = b;
            this.Width = width;
            this.Height = height;
        }
        public void PrintInScreen()
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