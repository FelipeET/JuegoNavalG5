using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Hit
    {
        public void Disparar(Tablero tab, int y, int x)
        {
            if(tab.GetBoard()[x,y] == 0)
                    {
                      tab.GetBoard()[x,y] = 6; 
                    }
            if(tab.GetBoard()[x,y] == 1)
                    {
                      tab.GetBoard()[x,y] = 5; 
                    }
            if(tab.GetBoard()[x,y] == 2)
                    {
                      tab.GetBoard()[x,y] = 5; 
                    }
            if(tab.GetBoard()[x,y] == 3)
                    {
                      tab.GetBoard()[x,y] = 5; 
                    }
            if(tab.GetBoard()[x,y] == 4)
                    {
                      tab.GetBoard()[x,y] = 5; 
                    }        
        }
    }
}