namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/salir".
    /// </summary>
    public class GoodByeHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GoodByeHandler"/>. Esta clase procesa el mensaje "/salir"
        /// y el mensaje "adiós" -un ejemplo de cómo un "handler" puede procesar comandos con sinónimos.
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public GoodByeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/salir" };
        }

        /// <summary>
        /// Procesa el mensaje "/salir" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, out string response)
        {

            if (message.ToLower().Equals("/salir"))
            {
                response = "¡Chau! ¡Qué andes bien!";
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}