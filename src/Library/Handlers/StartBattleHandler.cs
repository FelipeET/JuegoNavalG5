namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "/batalla".
    /// </summary>
    public class StartBattleHandler : BaseHandler
    {
        public Match match = Match.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartBattleHandler"/>. Esta clase procesa los mensajes "/batalla".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartBattleHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/batalla"};
        }

        /// <summary>
        /// Procesa los mensajes "/batalla" y retorna un string;
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        
        //Cambia el status del jugador 1 a OnTurn ademas de indicar como proseguir con el juego
        //(en este caso usar el comando "/disparar").
        protected override bool InternalHandle(string message, out string response)
        {

            if (message.ToLower().Equals("/batalla") && match.Game.Phase == GamePhase.GameRunning)
            {
                response = $"Para disparar une el comando: /disparar, {match.Game.P1.Name} es el primero en jugar";
                match.Game.P1.StatusOnTurn();
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