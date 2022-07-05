using System;

namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "/crear".
    /// </summary>
    public class CreateGameHandler : BaseHandler
    {
        //instancia de la clase Match
        public Match match;
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CraeteGameHandler"/>. Esta clase procesa los mensajes "/crear".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateGameHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/crear" };
        }

        /// <summary>
        /// Procesa los mensajes "/crear" y retorna un bool;
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        
        //Iguala match a Match.Instance
        //Si recive el comando "/crear" pide los nombres de los dos jugadores y usa el metodo CreateGame que 
        //inicializa una instancia de la clase Game en la clase match. Ademas indica al usuario como continuar
        //(en este caso usando el comando "/iniciar").
        protected override bool InternalHandle(string message, out string response)
        {
            match = Match.Instance;

            if (message.ToLower().Equals("/crear"))
            {
                Console.WriteLine("Ingrese los nombres del jugadro 1 y el jugador 2 (separados por un espacio entre ellos):");
                message = Console.ReadLine();
                string[] args = message.Split(" ");
                match.CreateGame(args[0], args[1]);
                match.Game.ChangePhase(GamePhase.CraetingGame);
                response = "Para iniciar la partida use el comando /iniciar";
                return true;
            }
            else
            {
                response = "Comando invalido, intente nuevamente con el comando: /crear";
                return false;
            }
        }
    }
}