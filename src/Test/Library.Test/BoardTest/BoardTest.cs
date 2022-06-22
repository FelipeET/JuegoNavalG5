using NUnit.Framework;
using PII_Batalla_Naval;
using System;

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
        public void AddBoatVesselTest()
        {  
            Vessel vesselT = new Vessel();
            this.board.AddBoat(board, 2 , 2 , Orientation.Horizontal , vesselT );
            int expected = 1;
            Assert.AreEqual(expected,board.GetBoard()[2,2]);
        }
        [Test]
        public void AddBoatSubmarineTest()
        {  
            Submarine submarineT = new Submarine();
            this.board.AddBoat(board, 3 , 3 , Orientation.Vertical , submarineT );
            int expected = 2;
            Assert.AreEqual(expected,board.GetBoard()[3,3]);
        }
        [Test]
        public void AddBoatDestructorTest()
        {  
            Destructor destructorT = new Destructor();
            this.board.AddBoat(board, 3 , 3 , Orientation.Vertical , destructorT );
            int expected = 3;
            Assert.AreEqual(expected,board.GetBoard()[3,3]);
        }
        [Test]
        public void AddBoatCarrierTest()
        {  
            Carrier carrierT = new Carrier();
            this.board.AddBoat(board, 1 , 1 , Orientation.Vertical , carrierT );
            int expected = 4;
            Assert.AreEqual(expected,board.GetBoard()[1,1]);
        }
    }
}