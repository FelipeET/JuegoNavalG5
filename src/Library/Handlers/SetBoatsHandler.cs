using System;

namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "/colocar".
    /// </summary>
    public class SetBoatsHandler : BaseHandler
    {
        public Match match = Match.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SetBoatsHandler"/>. Esta clase procesa los mensajes "/colcoar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SetBoatsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/colocar"};
        }

        /// <summary>
        /// Procesa los mensajes "/colcoar" y retorna un string;
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        
        //Si recibe el comando "/colcoar" y el el juego esta en la fase "Player1SetingBoard":
        //permite al jugador 1 colocar todos los barcos que le corresponden en su tablero.
        //Pero, si recibe el comando "/colocar" y el juego esta en la fase "Player2SetingBoard":
        //permite al jugador 2 colocar todos los barcos que le corresponden en su tablero. 
        //Ambos casos usan un bucle while para controlar la interaccion, ademas de utilizar 
        //dentro de ellos el metodo AppealForBoats.
        protected override bool InternalHandle(string message, out string response)
        {
            if (message.ToLower().Equals("/colocar") && match.Game.Phase == GamePhase.Player1SettingBoard)
            {
                Console.WriteLine($"Es el turno de {match.Game.P1.Name} para colcoar sus barcos");
                Console.WriteLine("IMPORTANTE: los barcos se colocan de izquierda a derecha (si la orientacion elegida es horizontal) y de arriba hacia abajo (si la orientacion elegida es vertical), ten esto en cuenta al momento de ingresar las coordenadas y orientacion de tus barcos \n");
                while (match.Game.P1.PlayerBoard.BoatsReady <= 3)
                {
                    match.Game.AppealForBoats(match.Game.P1);
                }
                Console.Clear();

                response = $"{match.Game.P1.Name} a colocado sus barcos, es el turno de {match.Game.P2.Name}. n/Para eso {match.Game.P2.Name} debe usar el comando /colocar ";
                match.Game.ChangePhase(GamePhase.Player2SettingBoard);
                return true;
            }
            else if (message.ToLower().Equals("/colocar") && match.Game.Phase == GamePhase.Player2SettingBoard)
            {
                Console.WriteLine($"Es el turno de {match.Game.P2.Name} para colocar sus barcos");
                Console.WriteLine("IMPORTANTE: los barcos se colocan de izquierda a derecha (si la orientacion elegida es horizontal) y de arriba hacia abajo (si la orientacion elegida es vertical), ten esto en cuenta al momento de ingresar las coordenadas y orientacion de tus barcos \n"); 
                while (match.Game.P2.PlayerBoard.BoatsReady <= 3)
                {
                    match.Game.AppealForBoats(match.Game.P2);
                }
                Console.Clear();

                response = $"{match.Game.P2.Name} a colocado sus barcos. /n Para comnzar la batalla {match.Game.P1.Name} debe ingresar el comando: /batalla";
                match.Game.ChangePhase(GamePhase.GameRunning);
                return true;
            }
            else
            {
                response = "Comando invlaido, intente nuevamente";
                return false;
            }
        }
    }
}