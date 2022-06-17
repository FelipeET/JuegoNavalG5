using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Player
    {
        private string name;

        private string id;

        private int vp = 0;

        public string Name
        {
            get {

                return this.name;
            }   
        }

        public string Id
        {
            get {
                
                return id;
            }
        }

        public int VP
        {
            get {
                
                return vp;
            }
        }

        public Player(string _name, string _id)
        {
            this.name = _name;
            string randomChain = string.Empty;
            randomChain = Guid.NewGuid().ToString();
            this.id = _id;
        }

        public void AddVp (int vpToAdd)
        {
            this.vp += vpToAdd;
        }
    }
}
