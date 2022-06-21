using System;

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
            //IHandler handler; //poner cadena de handlers

            this.SendMessage("Bienvenido a la Batalla Naval! \nUse un comando: \n> \"/jugar\" para iniciar el juego \n> \"/salir\" para salir del juego");
            string message = string.Empty;
            //string response;

            while (true)
            {
                message = Console.ReadLine();
                if(message.Equals("/salir", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.SendMessage("Nos vemos!");
                    break;
                }

                //IHandler result = handler.Handle(message, out response);

                if (message.Equals("", StringComparison.CurrentCultureIgnoreCase) || message.Equals("/", StringComparison.InvariantCultureIgnoreCase) || message.Equals(" ", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Comando no identificado \nIntenta nuevamente");
                }
                
                if (message.Equals("/jugar", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Iniciemos los preparativos... \n");

                    Console.WriteLine("Ingrese el nombre del jugador 1:");
                    string p1name = Console.ReadLine();
                    Player p1 = new Player(p1name);
                    Console.WriteLine("\n");
                    
                    Console.WriteLine("Ingrese el nombre del jugador 2:");
                    string p2name = Console.ReadLine();
                    Player p2 = new Player(p2name);
                    Console.WriteLine("\n");

                    Console.WriteLine($"Bienvenidos {p1name} y {p2name}, preparense para iniciar la batalla! \n");
                    Console.WriteLine("Generando encuentro... \n\n");

                    Logic log = new Logic(new Game(p1, p2));
                    log.LogGame();
                    Console.Clear();
                    log.LetsPlay();

                    Console.WriteLine("Gracias por jugar, vuelvan pronto!");

                }
            }
        }
    }
}