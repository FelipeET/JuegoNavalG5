namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "/iniciar".
    /// </summary>
    public class StartPlaceingBoatsHandler : BaseHandler
    {
        public Match match = Match.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartPlacingBoatsHandler"/>. Esta clase procesa los mensajes "/iniciar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartPlaceingBoatsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/iniciar"};
        }

        /// <summary>
        /// Procesa los mensajes "/iniciar" y retorna un string;
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        
        //Cambia el estado del juego a CreatingGame ademas de indicar como proseguir con el juego
        //(en este caso usar el comando "/colocar").
        protected override bool InternalHandle(string message, out string response)
        {
            if (message.ToLower().Equals("/iniciar") && match.Game.Phase == GamePhase.CraetingGame)
            {
                response = $"Es momento de posicionar sus naves jugadores, {match.Game.P1.Name} sera el primero en hacerlo, para eso use el comando: /colocar";
                match.Game.ChangePhase(GamePhase.Player1SettingBoard);
                return true;
            }
            else
            {
                response = "Comando invalido, intente nuevamnte";
                return false;
            }
        }
    }
}