/*using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class GameTestViejo
    {
        private Player p1= new Player("A");
        private Player p2= new Player("B");
        /// <summary>
        ///  Test de return de las clases player.
        /// </summary>
        [Test]
        public void Player1Test()
        { 
            Game g1 = new Game(p1, p2); 
            Player expected= p1;
            Assert.AreEqual(p1, g1.P1);
        }
        [Test]
        public void Player2Test()
        {
            Game g1 = new Game(p1, p2);
            Player expected= p2;
            Assert.AreEqual(expected, g1.P2);
        }
    }
}*/