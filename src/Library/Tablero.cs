using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Tablero
    {
        private int largo = 6;
        private int ancho = 6;
        private int [,] board; 
        private int cantBarcos = 4;
        
        public Tablero ()
        {
            int[,] tablero = new int [largo, ancho];
            this.board = tablero;
        }

        public void ArmarTablero()
        {  
            for (int y=0; y < largo; y++)
            {
                for (int x=0; x < ancho; x++)
                {
                    board[x,y] = 0;
                }
            }   
        }

        public int [,] Board
        {
            get{
                return board;
            }
        }

        public int CantBarcos{
            get {
                return cantBarcos;
            }
        }
    }
}
