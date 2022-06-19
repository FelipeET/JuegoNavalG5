/*using System;

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
            IHandler handler; //poner cadena de handlers

            this.SendMessage("Bienvenido a la Batalla Naval! \nUse un comando \n> \"/jugar\" para iniciar el juego \n> \"/salir\" para salir del juego");
            string message = string.Empty;
            string response;
            while (true)
            {
                message = Console.ReadLine();
                if(message.Equals("/salir", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.SendMessage("Nos vemos pronto bro");
                    break;
                }

                IHandler result = handler.Handle(message, out response);

                if (result == null)
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
}*/