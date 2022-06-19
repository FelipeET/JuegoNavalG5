using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Player
    {
        private string name;

        private int vp = 0;

        private Board playerBoard;

        private Status playerStatus;

        public Player(string _name)
        {
            this.name = _name;
            this.playerBoard = new Board();
            this.playerBoard.BuildBoard();
        }

        public string Name
        {
            get {

                return this.name;
            }   
        }

        public int VP
        {
            get {
                
                return vp;
            }
        }

        public Board PlayerBoard
        {
            get {
                
                return playerBoard;
            }
        }

         public Status PlayerStatus
        {
            get {
                
                return playerStatus;
            }
        }

        public void StatusOnTurn()
        {
            playerStatus = Status.OnTurn;
        }

        public void StatusWaiting()
        {
            playerStatus = Status.Waiting;
        }

        public void AddVp (int vpToAdd)
        {
            this.vp += vpToAdd;
        }
    }
}
