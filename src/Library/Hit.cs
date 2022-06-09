using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Hit
    {
        public void Shoot(Board board, int y, int x)
        {
            if(board.GetBoard()[x,y] == 0)
                    {
                      board.GetBoard()[x,y] = 6; 
                    }
            if(board.GetBoard()[x,y] == 1)
                    {
                      board.GetBoard()[x,y] = 5; 
                    }
            if(board.GetBoard()[x,y] == 2)
                    {
                      board.GetBoard()[x,y] = 5; 
                    }
            if(board.GetBoard()[x,y] == 3)
                    {
                      board.GetBoard()[x,y] = 5; 
                    }
            if(board.GetBoard()[x,y] == 4)
                    {
                      board.GetBoard()[x,y] = 5; 
                    }        
        }
    }
}