using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Logic
    {
        private Game Match; 
        PrintBoard print1; 
        PrintBoard print2; 
        PrintHidden hidden; 
        PrintRivalBoard printPlayer1;
        PrintRivalBoard printPlayer2;

        public int p;

        public Logic (Game game)
        {
            this.Match = game;
            this.print1 = new PrintBoard(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
            this.print2 = new PrintBoard(Match.P2.PlayerBoard, Match.P2.PlayerBoard.Length, Match.P2.PlayerBoard.Length);
            this.hidden = new PrintHidden(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
            this.printPlayer1 = new PrintRivalBoard(Match.P2.PlayerBoard, Match.P2.PlayerBoard.Length, Match.P2.PlayerBoard.Length);
            this.printPlayer2 = new PrintRivalBoard(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
        }

        public void LogGame()
        {
            while (Match.P1.PlayerBoard.BoatsReady <= 3)
            {
                AppealForBoats(Match.P1);
            }

            while (Match.P2.PlayerBoard.BoatsReady <= 3)
            {
                AppealForBoats(Match.P2); 
            }
        }

        public void LetsPlay()
        {
            while (Match.P1.PlayerBoard.HitCounter < 10 || Match.P2.PlayerBoard.HitCounter < 10)
            {
                Match.P1.StatusOnTurn();

                while (Match.P1.PlayerStatus == Status.OnTurn)
                {
                    PlayerMove(Match.P1, Match.P2);
                    printPlayer1.PrintInScreen();
                    print1.PrintInScreen();
                }

                while (Match.P2.PlayerStatus == Status.OnTurn)
                {
                    PlayerMove(Match.P2, Match.P1);
                    printPlayer2.PrintInScreen();
                    print2.PrintInScreen();
                }
            }
            
            if (Match.P1.PlayerBoard.HitCounter >= 10)
            {
                Match.P2.AddVp(10);
                Console.WriteLine($"{Match.P2.Name} es el ganador!");
                Console.WriteLine($"Los Putos de Victoria de {Match.P2.Name} aumentaron en +10");
                Console.WriteLine($"Los Putos de Victoria de {Match.P2.Name} son: {Match.P2.VP}");
            }
            else
            {
                Match.P1.AddVp(10);
                Console.WriteLine($"{Match.P1.Name} es el ganador!");
                Console.WriteLine($"Los Putos de Victoria de {Match.P1.Name} aumentaron en +10");
                Console.WriteLine($"Los Putos de Victoria de {Match.P1.Name} son: {Match.P1.VP}");
            }

            Match.P1.PlayerBoard.ResetBoard();
            Match.P2.PlayerBoard.ResetBoard();  
            
        }

        public Orientation GetOri(string ori)
        {

            if (ori == "horizontal")
            {
                return Orientation.Horizontal;
            }
            else
            {
                return Orientation.Vertical;
            }
        }

        public void AppealForBoats(Player player)
        {
            string message;
            String[] coords;

            switch (player.PlayerBoard.BoatsReady) 
            {
                case 0:
                    Carrier carrier = new Carrier();
                    print1.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su porta aviones");
                    message = Console.ReadLine();
                    coords = message.Split(" ");

                    if (!coords[2].Equals("horizontal") || !coords[2].Equals("vertical"))
                    {
                        throw new Exception("orientacion invalida");
                    }

                    try
                    {   
                        int x = Int32.Parse(coords[0]);
                        int y = Int32.Parse(coords[1]);
                        if (x < 0 || x > 5 || y < 0 || y > 5)
                        {
                            throw new Exception("recuerda que las coordenadas deben ser numeros entre 0 y 5");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("coordenadas invalidas: ", e);
                    }

                    Match.P1.PlayerBoard.AddBoat(Match.P1.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), carrier);
                    Console.WriteLine("El barco se coloco correctaente:");
                    print1.PrintInScreen();
                    break;

                case 1:
                    Destructor destructor = new Destructor();
                    print1.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su destructor");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    Match.P1.PlayerBoard.AddBoat(Match.P1.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), destructor);
                    Console.WriteLine("El barco se coloco correctaente:");
                    print1.PrintInScreen();
                    break;

                 case 2:
                    Submarine submarine= new Submarine();
                    print1.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su submarino");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    Match.P1.PlayerBoard.AddBoat(Match.P1.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), submarine);
                    Console.WriteLine("El barco se coloco correctaente:");
                    print1.PrintInScreen();
                    break;   

                case 3:
                    Vessel vessel = new Vessel();
                    print1.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su buque");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    Match.P1.PlayerBoard.AddBoat(Match.P1.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[0]), vessel);
                    Console.WriteLine("El barco se coloco correctaente:");
                    print1.PrintInScreen();
                    break;

                default:
                    Console.WriteLine("Todos los barcos listos");
                    break;      

            }
        }

        public void PlayerMove(Player player, Player enemigo)
        {
            string message;
            String[] coords;

            Console.WriteLine($"Turno {Match.Turns}");
            print1.PrintInScreen();
            hidden.PrintInScreen();
            Console.WriteLine("ingrese una coordenada (X e Y separadas por un epacio entre si) a la cual deseas disparar");
            message = Console.ReadLine();
            coords = message.Split(" ");

            try
            {   
                int x = Int32.Parse(coords[0]);
                int y = Int32.Parse(coords[1]);
                if (x < 0 || x > 5 || y < 0 || y > 5)
                {
                    throw new Exception("recuerda que las coordenadas deben ser numeros entre 0 y 5");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("coordenadas invalidas: ", e);
            }

            player.PlayerBoard.Shoot(enemigo.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]));
            player.StatusWaiting();
            enemigo.StatusOnTurn();
            Match.Turns++;
        }
    }
}  



