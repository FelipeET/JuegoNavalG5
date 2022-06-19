using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Board
    {
        private int onBoardBoats = 4;
        private int lenght = 6;
        private int [,] board;
        private int hitCounter = 0; 
        //private bool effectedShot;
        private bool flag;
        private int count = 0;
        private int boatsReady = 0;
        
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

        public void Shoot(Board board, int y, int x)
        {
            //effectedShot = false;
            
            if (board.InLimits(x, y) && board.GetBoard()[x,y] != 5 && board.GetBoard()[x,y] != 6)
            {
                if(board.GetBoard()[x,y] == 0)
                {
                    board.GetBoard()[x,y] = 6;
                    //effectedShot = true; 
                }
                if(board.GetBoard()[x,y] >= 1 && board.GetBoard()[x,y] <= 4)
                {
                    board.GetBoard()[x,y] = 5;
                    this.hitCounter++;
                    //effectedShot = true; 
                }
            }
            else 
            {
                if (!board.InLimits(x, y))
                {
                Console.WriteLine("Posicion invalida, intente nuevamente");
                }
                else
                {
                Console.WriteLine("Ya disparatse anteriormente a esta posicion, intenta con otra");
                }
            }
        }

        public void AddBoat (Board board, int y, int x, Orientation ori, IBoat boat)
        {
            this.flag = false;

            if (count < board.OnBoardBoats)
            {
                if (board.InLimits(x,y) && board.NotOcuppied(x,y))
                {
                    if (ori == Orientation.Vertical)
                    {
                        for(int i = 0; i < boat.BoatLength; i++)
                        {
                            if (board.InLimits(x, y + i) && board.NotOcuppied(x, y + i))
                            {
                                this.flag = true;
                            }
                        }
                        if (this.flag) 
                        {
                            for (int j = 0; j < boat.BoatLength; j++)
                            {
                                board.GetBoard()[x, y + j] = boat.ID;
                            }
                            this.count++;
                            this.boatsReady++;
                        }
                        else 
                        {
                            Console.WriteLine("El barco no puede ser posicionado en este lugar, intente nuevamete");
                        }
                    }
                    if (ori == Orientation.Horizontal)
                    {
                        for(int i = 0; i < boat.BoatLength; i++)
                        {
                            if (board.InLimits(x + i, y) && board.NotOcuppied(x + i, y))
                            {
                                this.flag = true;
                            }
                        }
                        if (this.flag) 
                        {
                            for (int j = 0; j < boat.BoatLength; j++)
                            {
                                board.GetBoard()[x + j, y] = boat.ID;
                            }
                            this.count++;
                            this.boatsReady++;
                        }
                        else 
                        {
                            Console.WriteLine("El barco no puede ser posicionado en este lugar, intente nuevamete");
                        }

                    }
                }
                else
                {
                    if (!board.InLimits(x,y))
                    {
                        Console.WriteLine("Posicion fuera de los limites del tablero, intente nuevamete");
                    }
                    if (!board.NotOcuppied(x, y))
                    {
                         Console.WriteLine($"Posicion ya ocupada, no se puede agregar {boat.Name}, intente nuevamete");
                    }
                }
            } 
        }
        
        public void ResetBoard()
        {
            this.hitCounter = 0;
            this.count = 0;
            this.boatsReady = 0;
            BuildBoard();
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

        public int HitCounter
        {
            get 
            {
                return hitCounter;
            }
        }

        /*public bool EffectedShot
        {
            get
            {
                return effectedShot;
            }
        }*/

        public int Count
        {
            get 
            {
                return count;
            }
        }

        public int BoatsReady
        {
            get 
            {
                return boatsReady;
            }
        }
    }
}
