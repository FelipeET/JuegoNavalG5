using System;
using System.IO;
using System.Collections.Generic;

namespace PII_Batalla_Naval
{
    public class Board
    {
        private int onBoardBoats = 4;
        private int lenght = 6;
        private int [,] board;
        private int hitCounter = 0; 
        private bool flag;
        private int count = 0;
        private int boatsReady = 0;
        public int VesselOnBoard = 0;
        public int SubmarieOnBoard = 0;
        public int DestructorOnBoard = 0;
        public int CarrierOnBoard = 0;
        public int x;
        public int y;
        public int EachChecker=36;
        
        public Board ()
        {
            int[,] board = new int [lenght,lenght];
            this.board = board;
        }

        public void BuildBoard()
        {  
            for (y=0; y < lenght; y++)
            {
                for (x=0; x < lenght; x++)
                {
                    this.board[x,y] = 0; 
                }
            }  
            BoardChecker(); 
        }

        public void BoardChecker()
        {    
            for (y=0; y < 6; y++)
            {
                for (x=0; x < 6; x++)
                {
                    while (EachChecker>=0)
                    {
                        if (this.board[x,y]!=0)
                        {
                            throw new BuildBoardCheckerException("Build Board error: Not all positions were Water while building the board.");
                        }
                        else
                        {
                            EachChecker--;
                        }
                    }
                }
            }
        }

        public bool InLimits(int x, int y)
        {
            if (x <= this.lenght && y <= this.lenght && x >= 0 && y >= 0)
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
            
            if (board.InLimits(x, y) && board.GetBoard()[x,y] != 5 && board.GetBoard()[x,y] != 6)
            {
                if(board.GetBoard()[x,y] == 0)
                {
                    board.GetBoard()[x,y] = 6;
                    Console.WriteLine("Agua!");
                }

                if(board.GetBoard()[x,y] >= 1 && board.GetBoard()[x,y] <= 4)
                {
                    board.CountSunkens(board, y, x);
                    board.GetBoard()[x,y] = 5;
                    board.hitCounter++;
                    board.IsSunken(board);
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
                if (board.InLimits(x,y))
                {
                    if (board.NotOcuppied(x,y))
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
                      Console.WriteLine($"Posicion ya ocupada, no se puede agregar {boat.Name}, intente nuevamete");  
                    }
                }
                else
                {
                    Console.WriteLine("Posicion fuera de los limites del tablero, intente nuevamete");
                }
            } 
        }

        public void CountSunkens(Board board, int x, int y)
        {
            if (board.GetBoard()[x,y] == 1)
            {
                board.VesselOnBoard++;
            }
            if (board.GetBoard()[x,y] == 2)
            {
                board.SubmarieOnBoard++;
            }
            if (board.GetBoard()[x,y] == 3)
            {
                board.DestructorOnBoard++;
            }
            if (board.GetBoard()[x,y] == 4)
            {
                board.CarrierOnBoard++;
            }
        }

        public void IsSunken(Board board)
        {
            if (board.VesselOnBoard == 1)
            {
                Console.WriteLine("Buque undido!");
            }
            else if (board.SubmarieOnBoard == 2)
                {
                    Console.WriteLine("Submarino undido!");
                }
                else if (board.DestructorOnBoard == 3)
                    {
                        Console.WriteLine("Destructor undido!");
                    }
                    else if (board.CarrierOnBoard == 4)
                        {
                            Console.WriteLine("Porta Aviones undido!");
                        }
                        else
                        {
                            Console.WriteLine("Tocado!");
                        }   
        }
        
        public void ResetBoard()
        {
            this.hitCounter = 0;
            this.count = 0;
            this.boatsReady = 0;
            this.VesselOnBoard = 0;
            this.SubmarieOnBoard = 0;
            this.DestructorOnBoard = 0;
            this.CarrierOnBoard = 0;
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
