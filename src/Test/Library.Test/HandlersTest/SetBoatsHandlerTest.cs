using NUnit.Framework;
using PII_Batalla_Naval;

namespace Library.Test
{
    public class SetBoatsHandlerTest
    {/*
    
    //No pudimos completar este test debido al funcionamiento de nuestro PlayingHandler con bucles.

        [Test]
        public void SetBoatsCommand1Test()
        {
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase( GamePhase.Player1SettingBoard);


            string expected = $"{match1.Game.P1.Name} a colocado sus barcos, es el turno de {match1.Game.P2.Name}. Para eso {match1.Game.P2.Name} debe usar el comando /colocar ";
            string response= string.Empty;
            string message="/colocar"; 
            StartBattleHandler A = new StartBattleHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);

            
        }

        [Test]
        public void SetBoatsCommand2Test()
        {
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase( GamePhase.Player2SettingBoard);


            string expected = $"{match.Game.P2.Name} a colocado sus barcos. Para comnzar la batalla {match.Game.P1.Name} debe ingresar el comando: /batalla";
            string response= string.Empty;
            string message="/colocar"; 
            StartBattleHandler A = new StartBattleHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);  
        }

        [Test]
        public void InvalidSetBoatsCommandTest()
        {
            Player playerT1 = new Player("Pepe");
            Player playerT2 = new Player("Papa");
            Match match1 = Match.Instance;
            match1.CreateGame(playerT1.Name, playerT2.Name);
            match1.Game.ChangePhase( GamePhase.Player2SettingBoard);


            string expected = "Comando invlaido, intente nuevamente";;
            string response= string.Empty;
            string message="/a"; 
            StartBattleHandler A = new StartBattleHandler(null);
            A.Handle(message, out response);
            Assert.AreEqual(expected, response);  
        }*/
    }
}