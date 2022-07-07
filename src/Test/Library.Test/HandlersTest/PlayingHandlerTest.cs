using NUnit.Framework;
using PII_Batalla_Naval;
using System;

namespace Library.Test
{
    public class PlayingHandlerTest
    { 
    //No pudimos completar este test debido al funcionamiento de nuestro PlayingHandler con bucles.
        public Match match = Match.Instance;
        [Test]
        public void HitCounterTest()
        {
            Player playerT1 = new Player("B");
            Player playerT2 = new Player("A");
            match.CreateGame(playerT1.Name, playerT2.Name);
            match.Game.ChangePhase(GamePhase.GameRunning);
            match.Game.P1.StatusOnTurn();
            int expected= 0;
            int A= (match.Game.P1.PlayerBoard.HitCounter+match.Game.P2.PlayerBoard.HitCounter);
            Assert.AreEqual(expected, A);
        }
        [Test]
        public void WatCounterTest()
        {
            Player playerT1 = new Player("B");
            Player playerT2 = new Player("A");
            match.CreateGame(playerT1.Name, playerT2.Name);
            match.Game.ChangePhase(GamePhase.GameRunning);
            match.Game.P1.StatusOnTurn();
            int expected= 0;
            int A= (match.Game.P1.PlayerBoard.WatCounter+match.Game.P2.PlayerBoard.WatCounter);
            Assert.AreEqual(expected, A);
        }
    }
}