using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class LogicTest
    {
        private Logic log;
        [Test]
        public void GetOriTest()
        {
            Player p1 = new Player("1");
            Player p2 = new Player("2");
            Game gt = new Game(p1, p2);
            this.log = new Logic(gt);

            string ori= ("horizontal");
            Orientation expected= Orientation.Horizontal; 
            Assert.AreEqual(expected, log.GetOri(ori));
        }
    }
}