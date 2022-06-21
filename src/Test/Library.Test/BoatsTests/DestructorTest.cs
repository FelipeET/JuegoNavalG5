using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class DestructorTest
    {
        private Destructor destructor;
        [SetUp]
        public void Setup()
        {
            this.destructor = new Destructor();
        }


        [Test]
        public void DestructorLenghtTest()
        {
            const int expected = 3;
            Assert.AreEqual(expected, destructor.BoatLength);
        }
        [Test]
        public void DestructorIDTest()
        {
            const int expected = 3;
            Assert.AreEqual(expected, destructor.ID);
        }
        [Test]
        public void DestructorNameTest()
        {
            const string expected = "Destructor";
            Assert.AreEqual(expected, destructor.Name);
        }
    }
}