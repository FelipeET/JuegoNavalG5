using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class PlayerTest
    {
        private Player playerT;
        [SetUp]
        public void Setup()
        {
            this.playerT = new Player("Pepe");

        }

        [Test]
        public void PlayerNameTest()
        {
            const string expected = "Pepe";
            Assert.AreEqual(expected, playerT.Name);
        }
        [Test]
        public void PlayerVPTest()
        {
            const int expected = 0;
            Assert.AreEqual(expected, playerT.VP);
        }
        
        [Test]
        public void PlayerVPAddTest()
        {
            playerT.AddVp(3);
            const int expected = 3;
            Assert.AreEqual(expected, playerT.VP);
        }
        /*
        [Test]
        public void PlayerBoardTest()
        {
            Board expected= playerT.PlayerBoard;
            Assert.AreEqual(expected, playerT.PlayerBoard);
        }
        [Test]
        public void PlayerStatusTest()
        {
            Status expected= playerT.PlayerStatus; // Waiting OnTurn
            Assert.AreEqual(expected, playerT.PlayerStatus);
        }

        public void PStatusOnTurnTest()
        {
            const Status expected = OnTurn;
            Assert.AreEqual(expected, playerT.StatusOnTurn);
        }

        public void PStatusWaitingTest()
        {
            const Status expected = Waiting;
            Assert.AreEqual(expected, playerT.StatusWaiting);
        }*/
    }
}

/*      [Test]
        public void PlayerIDTest()
        {
            const string expected = "0";
            Assert.AreEqual(expected, player.Id);
        }*/