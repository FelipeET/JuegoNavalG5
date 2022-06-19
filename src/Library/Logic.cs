using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Logic
    {
       
        PrintBoard print1;
        PrintBoard print2;
        PrintHidden hidden;
        PrintRivalBoard printPlayer1;
        PrintRivalBoard printPlayer2;

        public int p;

        public Logic (HandlerSetGame game)
        {
            this.Game = game;
        }

        public void LogGame()
        {
          
             while (!Game.p1.b1.Count <= 3)
            {
                Caso contador = 0 //submarino
                caso contador = 1 //buque
            }

            while (!Game.p2.b2.AllBoatsReady)
        }



        public void StartGame()
        {
            while (h1.HitCounter < 10 || h2.HitCounter <10)
            {
                while (!h1.EffectedShot)
                {

                }

                while (!h2.EffectedShot)
                {

                }
            }
        }

        public Orientation GetOri(string ori)
        {

            if (ori == "horizontal")
            {
                return Orientation.Horizontal;
            }
            else
            {
                return Orientation.Vertical;
            }
        }
    }  
}