using System;

//BotInConsole: Nos permite una primera interacción con el usuario, pidiéndole que ingrese 
//un comando en base a lo que este desea hacer. En caso de querer jugar se le pide ingresar “/jugar”, 
//en caso de querer salir del juego se le pide ingresar “/salir”. 
//Si se ingresa un comando inválido o vacio se le pedirá al usuario intentar nuevamente. 
//Cabe destacar que la idea para esta clase es utilizar una cadena de Handlers 
//(objetivo primordial para la última entrega).

//Obs1: Si el usuario ingresa “/jugar”, comenzara el juego (ingerasr el nombre de los jugadores, posicionar sus barcos
//y la batalla en si), esto mediante el recorrido de la cadena de Hanlders.
//Obs2: Si el usuario ingresa “/salir”, el juego terminará.

namespace PII_Batalla_Naval
{
    public class BotInConsole
    {
        private static BotInConsole instance;

        public static BotInConsole Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new BotInConsole();
                }
                return instance;
            }
        }

        private BotInConsole(){}

        public void SendMessage(string text)
        {
            System.Console.WriteLine(text);
        }

        public void StartCommunication()
        {
            this.SendMessage("Bienvenido a la Batalla Naval! \nUse un comando: \n> \"/jugar\" para iniciar el juego \n> \"/salir\" para salir del juego");

            //Cadena de Handlers del patron Chain of Responsibility  
            IHandler handler = 
                new StartHandler(
                new CreateGameHandler(
                new StartPlaceingBoatsHandler(
                new SetBoatsHandler(
                new StartBattleHandler(
                new PlayingHandler(
                new GoodByeHandler(null)))))));

            string response;

            while (true)
            {
                string message = Console.ReadLine();

                if(message.Equals("/salir", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.SendMessage("Nos vemos!");
                    break;
                }

                IHandler result = handler.Handle(message, out response);

                if (message.Equals("", StringComparison.CurrentCultureIgnoreCase) || message.Equals("/", StringComparison.InvariantCultureIgnoreCase) || message.Equals(" ", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Comando no identificado \nIntenta nuevamente");
                }
                else
                {
                    Console.WriteLine(response);
                }
            }
        }
    }
}