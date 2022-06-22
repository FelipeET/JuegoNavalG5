using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class SubmarineTests
    {
        private Submarine submarine;
        [SetUp]
        public void Setup()
        {
            this.submarine = new Submarine();
        }
        /// <summary>
        /// Test de atributos del barco /Tamano, id y nombre
        /// </summary>

        [Test]
        public void SubmarineLenghtTest()
        {
            const int expected = 2;
            Assert.AreEqual(expected, submarine.BoatLength);
        }
        [Test]
        public void SubmarineIDTest()
        {
            const int expected = 2;
            Assert.AreEqual(expected, submarine.ID);
        }
        [Test]
        public void SubmarineNameTest()
        {
            const string expected = "Submarino";
            Assert.AreEqual(expected, submarine.Name);
        }
    }
}