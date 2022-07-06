using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class StartHandlerTest
    {
        [Test]
        public void JugarCommandTest()
        { 
            bool expected = true;
            string response= "Use el comando /crear para crear una partida";
            string message="/start"; 
            StartHandler A = new StartHandler(null);
            //Assert.AreEqual(message, Is.Not.Null);
            Assert.AreEqual(expected, A.Handle(message, out response));

            
        } 
    }
}