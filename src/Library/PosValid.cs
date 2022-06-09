/*using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    public class PosValid
    {
        public bool InLimits(Board board, int x, int y)
        {
            if (x <= board.Length && y <= board.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NotOcuppied(Board board, int x, int y)
        {
            if (board.Board[x,y] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}*/