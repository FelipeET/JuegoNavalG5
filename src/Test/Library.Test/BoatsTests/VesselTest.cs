using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class VesselTest
    {
        private Vessel vessel;
        [SetUp]
        public void Setup()
        {
            this.vessel = new Vessel();
        }

        /// <summary>
        /// Test de atributos del barco /Tamano, id y nombre
        /// </summary>
        [Test]
        public void VesselLenghtTest()
        {
            const int expected = 1;
            Assert.AreEqual(expected, vessel.BoatLength);
        }
        [Test]
        public void VesselIDTest()
        {
            const int expected = 1;
            Assert.AreEqual(expected, vessel.ID);
        }
        [Test]
        public void VesselNameTest()
        {
            const string expected = "Buque";
            Assert.AreEqual(expected, vessel.Name);
        }
    }
}