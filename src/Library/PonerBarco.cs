using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class PonerBarco
    {
        public void AgregarBraco (Tablero tab, int x, int y)
        {
            tab.GetBoard()[x,y] = 1; 
        }
    }
}