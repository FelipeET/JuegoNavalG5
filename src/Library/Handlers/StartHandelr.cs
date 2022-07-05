namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/jugar".
    /// </summary>
    public class StartHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/jugar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/jugar" };
        }

        /// <summary>
        /// Procesa el mensaje "/jugar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, out string response)
        {

            if (message.ToLower().Equals("/jugar"))
            {
                response = "Use el comando /crear para crear una partida";
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}