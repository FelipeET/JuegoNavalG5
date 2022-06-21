using System;
using System.Collections.Generic;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Logic
    {
        private Game Match; 
        private PrintBoard print1; 
        private PrintBoard print2; 
        private PrintRivalBoard printPlayer1;
        private PrintRivalBoard printPlayer2;
        private MatchInfo info;
        private string message;

        public Logic (Game game)
        {
            this.Match = game;
            this.print1 = new PrintBoard(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
            this.print2 = new PrintBoard(Match.P2.PlayerBoard, Match.P2.PlayerBoard.Length, Match.P2.PlayerBoard.Length);
            this.printPlayer1 = new PrintRivalBoard(Match.P2.PlayerBoard, Match.P2.PlayerBoard.Length, Match.P2.PlayerBoard.Length);
            this.printPlayer2 = new PrintRivalBoard(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
            this.info = new MatchInfo();
        }

        public void LogGame()
        {
            Console.WriteLine("IMPORTANTE: los barcos se colocan de izquierda a derecha (si la orientacion elegida es horizontal) y de arriba hacia abajo (si la orientacion elegida es vertical), ten esto en cuenta al momento de ingresar las coordenadas y orientacion de tus barcos \n");
            Console.WriteLine($"Es el turno de {Match.P1.Name} para colocar sus barcos"); 
            while (Match.P1.PlayerBoard.BoatsReady <= 3)
            {
                AppealForBoats(Match.P1);
            }
            Console.Clear();

            Console.WriteLine("IMPORTANTE: los barcos se colocan de izquierda a derecha (si la orientacion elegida es horizontal) y de arriba hacia abajo (si la orientacion elegida es vertical), ten esto en cuenta al momento de ingresar las coordenadas y orientacion de tus barcos \n");
            Console.WriteLine($"Es el turno de {Match.P2.Name} para colocar sus barcos");
            while (Match.P2.PlayerBoard.BoatsReady <= 3)
            {
                AppealForBoats(Match.P2); 
            }
            Console.Clear(); 
        }

        public void LetsPlay()
        {
            while (Match.P1.PlayerBoard.HitCounter < 10 && Match.P2.PlayerBoard.HitCounter < 10)
            {
                Match.P1.StatusOnTurn();

                while (Match.P1.PlayerStatus == Status.OnTurn && Match.P1.PlayerBoard.HitCounter < 10 && Match.P2.PlayerBoard.HitCounter < 10)
                {
                    PlayerMove(Match.P1, Match.P2);
                }
    
                while (Match.P2.PlayerStatus == Status.OnTurn && Match.P1.PlayerBoard.HitCounter < 10 && Match.P2.PlayerBoard.HitCounter < 10)
                {
                    PlayerMove(Match.P2, Match.P1);
                }
            }

            Console.WriteLine("LA BATALLA A TERMINADO!");
            
            if (Match.P1.PlayerBoard.HitCounter == 10)
            {
                Match.P2.AddVp(10);
                Match.winner = Match.P2.Name;
                Console.WriteLine($"{Match.P2.Name} es el ganador!");
                Console.WriteLine($"Los Puntos de Victoria de {Match.P2.Name} aumentaron en +10");
                Console.WriteLine($"Los Puntos de Victoria de {Match.P2.Name} son: {Match.P2.VP}");
            }
            else
            {
                Match.P1.AddVp(10);
                Match.winner = Match.P1.Name;
                Console.WriteLine($"{Match.P1.Name} es el ganador!");
                Console.WriteLine($"Los Putos de Victoria de {Match.P1.Name} aumentaron en +10");
                Console.WriteLine($"Los Putos de Victoria de {Match.P1.Name} son: {Match.P1.VP}");
            }

            info.GamesPlayed();
            info.AddInfo(Match);

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

        public string UserMessage(string message){
            message = Console.ReadLine();
            return message;
        }

        public void AppealForBoats(Player player)
        {
            String[] coords;
            PrintBoard printAppeal = new PrintBoard(player.PlayerBoard, player.PlayerBoard.Length, player.PlayerBoard.Length);

            switch (player.PlayerBoard.BoatsReady) 
            {
                case 0:
                    Carrier carrier = new Carrier();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Porta Aviones (ocupa 4 espacios en el tablero)");
                    string message= UserMessage(this.message);
                    coords = message.Split(" ");

                    if (!coords[2].Equals("horizontal") && !coords[2].Equals("vertical"))
                    {
                        throw new OrientationCheckerException("Orientation Error: Invalid Orientation.");
                    }

                    bool test = false;

                    try
                    {   
                        //Console.WriteLine("PRUEBA 1");
                        int x = Int32.Parse(coords[0]);
                        int y = Int32.Parse(coords[1]);
                        //Console.WriteLine("PRUEBA 2");
                        if (x < 0 || x > 5 || y < 0 || y > 5)
                        {
                            //Console.WriteLine("PRUEBA 3");
                            throw new Exception("recuerda que las coordenadas deben ser numeros entre 0 y 5");
                        }
                        //Console.WriteLine("PRUEBA 4");
                        if (!player.PlayerBoard.NotOcuppied(x,y))
                        {
                            //Console.WriteLine("PRUEBA 5");
                            throw new Exception("posicion ya ocupada, intente nuevamente");
                        }
                        else if (!player.PlayerBoard.InLimits(x, y))
                        {
                            //Console.WriteLine("PRUEBA 6");
                            throw new Exception("posicion fuera de limites, intente nuevamente");   
                        }
                        else{
                            test = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Coordenadas invalidas: ", e);
                    }
                    finally
                    {
                        if (test == false)
                        {
                            Console.WriteLine("Coordenada invalida, intente nuevamnte (recuerda que las coordenadas deben ser numeros entre 0 y 5)");
                            message = Console.ReadLine();
                            coords = message.Split();
                        }
                    }

                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), carrier);
                    Console.WriteLine("El barco se coloco correctaente:");
                    break;

                case 1:
                    Destructor destructor = new Destructor();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Destructor (ocupa 3 espacios en el tablero)");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), destructor);
                    Console.WriteLine("El barco se coloco correctaente:");
                    break;

                 case 2:
                    Submarine submarine= new Submarine();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Submarino (ocupa 2 espacios en el tablero)");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), submarine);
                    Console.WriteLine("El barco se coloco correctaente:");
                    break;   

                case 3:
                    Vessel vessel = new Vessel();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Buque (ocupa 1 espacios en el tablero)");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                   player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[0]), vessel);
                    Console.WriteLine("El barco se coloco correctaente:");
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
            PrintRivalBoard printEnemy = new PrintRivalBoard(enemigo.PlayerBoard, enemigo.PlayerBoard.Length, enemigo.PlayerBoard.Length);
            PrintBoard printTurnPlayer = new PrintBoard(player.PlayerBoard, player.PlayerBoard.Length, player.PlayerBoard.Length);
            
            Console.WriteLine($"Turno {Match.Turns} / Juega: {player.Name}");
            Console.WriteLine($"Tablero de {player.Name}:");
            printTurnPlayer.PrintInScreen();
            if (Match.Turns <= 2)
            {
                Console.WriteLine($"Tablero de {enemigo.Name}:");
                printEnemy.PrintHidden();
            }
            else
            {
                Console.WriteLine($"Tablero de {enemigo.Name}:");
                printEnemy.PrintInScreen();
            }
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

            enemigo.PlayerBoard.Shoot(enemigo.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]));
            player.StatusWaiting();
            enemigo.StatusOnTurn();
            Match.Turns++;
        }
    }
}  



