using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class GameTest
    {
        private Player p1= new Player("A");
        private Player p2= new Player("B");

        [Test]
        public void PlayerInGameTest()
        { 
            Game g1 = new Game(p1.Name, p2.Name); 
            string expected= p1.Name;
            Assert.AreEqual(expected, g1.P1.Name);
        }
        [Test]
        public void OtherPlayerInGameTest()
        { 
            Game g1 = new Game(p1.Name, p2.Name); 
            string expected= p2.Name;
            Assert.AreEqual(expected, g1.P2.Name);
        }

        [Test]
        public void StartGameTurnsTest()
        {
            Game g2 = new Game(p1.Name, p2.Name);
            int expected = 1;
            Assert.AreEqual(expected, g2.Turns);
        }

        [Test]
        public void StartWinnerTest()
        {
            Game g2 = new Game(p1.Name, p2.Name);
            string expected = null;
            Assert.AreEqual(expected, g2.Winner);
        }
        [Test]
        public void GamePhaseTest()
        {
            Game g2 = new Game(p1.Name, p2.Name);
            GamePhase expected = GamePhase.GameEmpty;
            Assert.AreEqual(expected, g2.Phase);
        }
        
    }
}