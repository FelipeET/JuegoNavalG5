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
            playerT.AddVp(5);
            const int expected = 8;
            Assert.AreEqual(expected, playerT.VP);
        }

        [Test]
        public void PlayerStatusTest()
        {
            Status expected= playerT.PlayerStatus;
            Assert.AreEqual(expected, Status.OnTurn);
        }
    }
}