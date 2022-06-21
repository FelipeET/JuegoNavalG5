using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class CarrierTest
    {
        private Carrier carrier;
        [SetUp]
        public void Setup()
        {
            this.carrier = new Carrier();
        }

        [Test]
        public void CarrierLenghtTest()
        {
            const int expected = 4;
            Assert.AreEqual(expected, carrier.BoatLength);
        }
        [Test]
        public void CarrierIDTest()
        {
            const int expected = 4;
            Assert.AreEqual(expected, carrier.ID);
        }
        [Test]
        public void CarrierNameTest()
        {
            const string expected = "Porta Aviones";
            Assert.AreEqual(expected, carrier.Name);
        }
    }
}