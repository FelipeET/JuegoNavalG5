using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Game
    {
        private Player p1;
        private Player p2;
        public int Turns = 1;
        public string winner;

        public Game (Player p1_, Player p2_)
        {
            this.p1 = p1_;
            this.p2 = p2_;
        }

        public Player P1
        {
            get 
            {
                return p1;
            }
        }

        public Player P2
        {
            get
            {
                return p2;
            }
        }

        public string Winner
        {
            get
            {
                return winner;
            }
        }
    }
}