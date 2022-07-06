using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class GoodByeHandlerTest
    {
        [Test]
        public void GoodByeCommandTest()
        { 
            string expected = "¡Chau! ¡Qué andes bien!";
            string response= string.Empty;
            string message="/salir"; 
            GoodByeHandler A = new GoodByeHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        }
        [Test]
        public void InvalidGoodByeCommandTest()
        { 
            string expected = string.Empty;
            string response= string.Empty;
            string message="a"; 
            GoodByeHandler A = new GoodByeHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        }  
    }
}