using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class BoardTest
    {
        private Board board;
        [SetUp]
        public void Setup()
        {
            this.board= new Board();
            this.board.BuildBoard();    
        }

        [Test]
        public void BoardLengthTest()
        {
            const int expected = 6;
            Assert.AreEqual(expected, board.Length);
        }

        [Test]
        public void OnBoardBoatTest()
        {
            const int expected = 4;
            Assert.AreEqual(expected, board.OnBoardBoats);
        }

        [Test]
        public void BoardCheckTest()
        {
            bool Checker = true;
            try
            {
                this.board.BuildBoard();
            }
            catch (BuildBoardCheckerException)
            {
                Checker= false;
            }
            Assert.AreEqual(true, Checker);
        }             
        [Test]
        public void AddBoatTest()
        {
            Vessel vesselT = new Vessel();
            this.board.AddBoat(board, 1 , 1 , Vertical , vesselT );
        }
    }
}