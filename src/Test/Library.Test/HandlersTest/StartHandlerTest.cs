using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class StartHandlerTest
    {
        [Test]
        public void StartCommandTest()
        { 
            string expected = "Use el comando /crear para crear una partida";
            string response= string.Empty;
            string message="/jugar"; 
            StartHandler A = new StartHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        } 
    }
}