/*using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Batalla_Naval
{
    public class PosValida 
    {
        public bool DentroDeLimites(Tablero tab, int x, int y)
        {
            if (x <= tab.Largo && y <= tab.Largo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NoOcupada(Tablero tab, int x, int y)
        {
            if (tab.Board[x,y] == 0)
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