using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Board
    {
        private int onBoardBoats = 4;
        private int lenght = 6;
        private int [,] board; 
        
        public Board ()
        {
            int[,] board = new int [lenght,lenght];
            this.board = board;
        }
      public void BuildBoard()
        {  
            for (int y=0; y < lenght; y++)
            {
                for (int x=0; x < lenght; x++)
                {
                    this.board[x,y] = 0; 
                }
            }   
        }

        public bool InLimits(int x, int y)
        {
            if (x <= this.lenght && y <= this.lenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NotOcuppied(int x, int y)
        {
            if (this.board[x,y] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int OnBoardBoats{
            get {
                return this.onBoardBoats;
            }
        }

        public int Length{
            get {
                return this.lenght;
            }
        }

        public int [,] GetBoard() 
        {
            return this.board;
        }
    }
}
