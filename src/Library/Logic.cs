using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Logic
    {
        private Player p1;
        private Player p2;
        private Board b1;
        private Board b2;
        private Hit h1 = new Hit();
        private Hit h2 = new Hit();
        private PlaceBoat put1 = new PlaceBoat();
        private PlaceBoat put2 = new PlaceBoat();
        PrintBoard print1;
        PrintBoard print2;
        PrintHidden hidden;
        PrintRivalBoard printPlayer1;
        PrintRivalBoard printPlayer2;

        public int p;

        public Logic (Player p1_, Player p2_, Board b1_, Board b2_)
        {
            this.p1 = p1_;
            this.p2 = p2_;
            this.b1 = b1_;
            this.b2 = b2_;
        }

        public void LogGame()
        {
            while (!put1.AllBoatsReady && !put2.AllBoatsReady)
            {
                while (put1.Count < 4)
                {
                   
                }

                while (put2.Count <4)
                {

                }

            }
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