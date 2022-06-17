using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class PlayerTest
    {
        private Player player;
        [SetUp]
        public void Setup()
        {
            this.player = new Player("Pepe", "0");
        }

        [Test]
        public void PlayerNameTest()
        {
            const string expected = "Pepe";
            Assert.AreEqual(expected, player.Name);
        }
        [Test]
        public void PlayerIDTest()
        {
            const string expected = "0";
            Assert.AreEqual(expected, player.Id);
        }
        [Test]
        public void PlayerVPTest()
        {
            const int expected = 0;
            Assert.AreEqual(expected, player.VP);
        }
        [Test]
        public void PlayerVPAddTest()
        {
            player.AddVp(3);
            const int expected = 3;
            Assert.AreEqual(expected, player.VP);
        }
    }
}