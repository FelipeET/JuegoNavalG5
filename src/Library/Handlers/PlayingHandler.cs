using System;

namespace PII_Batalla_Naval
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "/disparar".
    /// </summary>
    public class PlayingHandler : BaseHandler
    {
        public Match match = Match.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayingHandler"/>. Esta clase procesa los mensajes "/disparar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PlayingHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/disparar", "/hits" , "/waters"};
        }

        /// <summary>
        /// Procesa los mensajes "/disparar" y retorna un string;
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        
        //Un bucle while que se ejecuta mientras que el tablero de uno de los jugadores 
        //no haya recibido  10 hits o mas a los barcos colocados en el (en este caso todos los barcos 
        //en ese tablero estarían hundidos).  
        //Dentro de este bucle si se recive el comando "/disparar" y el status del jugador 1 es OnTurn (lo habilita a jugar)
        //se invoca al metodo PlayerMove que habilita la interacción de el jugador de turno con su enemigo. 
        //Pero si se recive el comando "/disparar" y es el jugador 2 cuyo estado es OnTurn, se hace lo mismo 
        //pero tomando al jugador 2 como el jugador de turno.
        //Una vez que se sale del while se indica que la partida termino y dependiendo de quién sea 
        //el ganador se procede a realizar las acciones correspondientes. 
        //Para finalizar se guarda la información final de la partida y se reinicia el tablero de ambos jugadores.
        protected override bool InternalHandle(string message, out string response)
        {
            while(match.Game.P1.PlayerBoard.HitCounter < 10 && match.Game.P2.PlayerBoard.HitCounter < 10)
            {
                if (message.ToLower().Equals("/disparar") && match.Game.P1.PlayerStatus == Status.OnTurn && match.Game.Phase == GamePhase.GameRunning)
                {
                    match.Game.PlayerMove(match.Game.P1, match.Game.P2);
                    match.Game.P1.StatusWaiting();
                    match.Game.P2.StatusOnTurn();
                    response = $"Es el turno de {match.Game.P2.Name} de atacar (use el comando /disparar). Si desea ver los contadores escriba /waters o /hits."; 
                    return true;
                }
                else if (message.ToLower().Equals("/disparar") && match.Game.P2.PlayerStatus == Status.OnTurn && match.Game.Phase == GamePhase.GameRunning)
                {
                    match.Game.PlayerMove(match.Game.P2, match.Game.P1);
                    match.Game.P2.StatusWaiting();
                    match.Game.P1.StatusOnTurn(); 
                    response = $"Es el turno de {match.Game.P1.Name} de atacar (use el comando /disparar). Si desea ver los contadores escriba /waters o /hits.";
                    return true;
                }
                else if (message.ToLower().Equals("/waters"))
                {   
                    int WC= (match.Game.P1.PlayerBoard.WatCounter+ match.Game.P2.PlayerBoard.WatCounter);
                    response = WC.ToString()+ " golpes al agua. Escriba /disparar para seguir.";
                    return false;
                }
                else if (message.ToLower().Equals("/hits"))
                {
                    int HC= (match.Game.P1.PlayerBoard.HitCounter+ match.Game.P2.PlayerBoard.HitCounter);
                    response = HC.ToString()+ " golpes a barcos. Escriba /disparar para seguir.";
                    return false;
                }                    
                else
                {
                    response = "Comando invlaido, intente nuevamente";
                    return false;
                }
            }

            Console.WriteLine("LA BATALLA A TERMINADO!");
            
            if (match.Game.P1.PlayerBoard.HitCounter == 10)
            {
                match.Game.P2.AddVp(10);
                match.Game.winner = match.Game.P2.Name;
                Console.WriteLine($"{match.Game.P2.Name} es el ganador!");
                Console.WriteLine($"Los Puntos de Victoria de {match.Game.P2.Name} aumentaron en +10");
                Console.WriteLine($"Los Puntos de Victoria de {match.Game.P2.Name} son: {match.Game.P2.VP}");
            }
            else
            {
                match.Game.P1.AddVp(10);
                match.Game.winner = match.Game.P1.Name;
                Console.WriteLine($"{match.Game.P1.Name} es el ganador!");
                Console.WriteLine($"Los Putos de Victoria de {match.Game.P1.Name} aumentaron en +10");
                Console.WriteLine($"Los Putos de Victoria de {match.Game.P1.Name} son: {match.Game.P1.VP}");
            }

            match.Game.info.GamesPlayed();
            match.Game.info.AddInfo(match.Game);

            match.Game.P1.PlayerBoard.ResetBoard();
            match.Game.P2.PlayerBoard.ResetBoard();
            match.Game.ChangePhase(GamePhase.GameEnds);
            response = "Gracias por jugar, nos vemos la proxima!!!";
            return false;   
        }
    }
}