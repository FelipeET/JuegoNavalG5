using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class PlayingHandlerTest
    { 
    //No pudimos completar este test debido al funcionamiento de nuestro PlayingHandler con bucles.
          /*
        [Test]
        public void ShootCommand1Test()
        { 
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase(GamePhase.GameRunning);
            match1.Game.P1.StatusOnTurn();


            string expected = $"Es el turno de {match1.Game.P1.Name} de atacar (use el comando /disparar)";
            string response= string.Empty;
            string message="/disparar"; 
            PlayingHandler A = new PlayingHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        } 
        
        [Test]
        public void ShootCommand2Test()
        { 
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase(GamePhase.GameRunning);
            match1.Game.P2.StatusOnTurn();


            string expected = $"Es el turno de {match1.Game.P2.Name} de atacar (use el comando /disparar)";
            string response= string.Empty;
            string message="/disparar"; 
            PlayingHandler A = new PlayingHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        }
        [Test]
        public void InvalidShootCommand2Test()
        { 
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase(GamePhase.GameRunning);
            match1.Game.P2.StatusOnTurn();


            string expected = "Comando invlaido, intente nuevamente";
            string response= string.Empty;
            string message="/a"; 
            PlayingHandler A = new PlayingHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);
        } */


    }
}