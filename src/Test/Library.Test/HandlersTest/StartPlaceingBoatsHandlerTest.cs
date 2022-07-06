using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class StartPlaceingBoatsHandlerTest
    {
        [Test]
        public void StartPlaceingBoatsCommandTest()
        { 
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase(GamePhase.CraetingGame);


            string expected = $"Es momento de posicionar sus naves jugadores, {match1.Game.P1.Name} sera el primero en hacerlo, para eso use el comando: /colocar";
            string response= string.Empty;
            string message="/iniciar"; 
            StartPlaceingBoatsHandler A = new StartPlaceingBoatsHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);

            
        }
        [Test]
        public void InvalidStartPlaceingBoatsCommandTest()
        { 
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase(GamePhase.CraetingGame);


            string expected = string.Empty;//"Comando invalido, intente nuevamnte";
            string response= string.Empty;
            string message="a"; 
            StartPlaceingBoatsHandler A = new StartPlaceingBoatsHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);

            
        } 
    }
}