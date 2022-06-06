using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Tablero
    {
        private int cantBarcosTotal = 4;
        private int cantBuquesPerm = 1;
        private int cantSubPerm = 1;
        private int cantDesPerm = 1;
        private int cantPortAvPerm = 1;
        private int largo = 6;
        private int [,] board; 
        
        public Tablero ()
        {
            int[,] board = new int [largo,largo];
            this.board = board;
        }
      public void ArmarTablero()
        {  
            for (int y=0; y < largo; y++)
            {
                for (int x=0; x < largo; x++)
                {
                    this.board[x,y] = 0; 
                }
            }   
        }

        public int [,] Board
        {
            get{
                return board;
            }
        }

        public int CantBarcosTotal{
            get {
                return cantBarcosTotal;
            }
        }

        public int CantBuquesPerm{
            get {
                return cantBuquesPerm;
            }
        }

        public int CantSubPerm{
            get {
                return cantSubPerm;
            }
        }

        public int CantDestPerm{
            get {
                return cantDesPerm;
            }
        }

        public int CantPortAvPerm{
            get {
                return cantPortAvPerm;
            }
        }

        public int Largo{
            get {
                return largo;
            }
        }

        public int [,] GetBoard() 
        {
            return this.board;
        }
    }
}
