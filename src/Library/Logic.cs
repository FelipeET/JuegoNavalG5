/*using System;

namespace PII_Batalla_Naval
{
    public class Logic
    {
        public bool[,] GameBoard;
         int BoardWidth;
         int BoardHeight;

        public Logic (bool[,] gameBoard)
        {
            this.GameBoard = gameBoard;
            this.BoardHeight = GameBoard.GetLength(1);
            this.BoardWidth = GameBoard.GetLength(0);
        }

        public void LogGame()
        {
            bool[,] cloneboard = new bool[BoardWidth, BoardHeight];
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<BoardWidth && j>=0 && j < BoardHeight && GameBoard[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(GameBoard[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (GameBoard[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (GameBoard[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!GameBoard[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x,y] = GameBoard[x,y];
                    }
                }
            }
            GameBoard = cloneboard;
            cloneboard = new bool[BoardWidth, BoardHeight];
        }
         public bool[,] NextGen()
        {
            this.LogGame();
            return GameBoard;
        }
    }
}   */