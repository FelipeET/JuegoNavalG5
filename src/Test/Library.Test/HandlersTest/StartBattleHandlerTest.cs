using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class StartBattleHandlerTest
    {
        [Test]
        public void StartBattleCommandTest()
        { 
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase(GamePhase.GameRunning);


            string expected = $"Para disparar une el comando: /disparar, {match1.Game.P1.Name} es el primero en jugar";
            string response= string.Empty;
            string message="/batalla"; 
            StartBattleHandler A = new StartBattleHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        } 
    }
}