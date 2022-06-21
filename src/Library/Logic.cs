using System;
using System.Collections.Generic;
using System.IO;

namespace PII_Batalla_Naval
{
    public class Logic
    {
        private Game Match; 
        private List<string> PandTInfo = new List<string>();
        private List<Board> boardsInfo = new List<Board>();
        private string winner;
        PrintBoard print1; 
        PrintBoard print2; 
        //PrintHidden hidden; 
        PrintRivalBoard printPlayer1;
        PrintRivalBoard printPlayer2;
        PrintBoard printinfo;
        private string message;

        public Logic (Game game)
        {
            this.Match = game;
            this.print1 = new PrintBoard(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
            this.print2 = new PrintBoard(Match.P2.PlayerBoard, Match.P2.PlayerBoard.Length, Match.P2.PlayerBoard.Length);
            //this.hidden = new PrintHidden(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
            this.printPlayer1 = new PrintRivalBoard(Match.P2.PlayerBoard, Match.P2.PlayerBoard.Length, Match.P2.PlayerBoard.Length);
            this.printPlayer2 = new PrintRivalBoard(Match.P1.PlayerBoard, Match.P1.PlayerBoard.Length, Match.P1.PlayerBoard.Length);
        }

        public void LogGame()
        {
            Console.WriteLine("Es el turno del jugador 1 para colocar sus barcos"); 
            while (Match.P1.PlayerBoard.BoatsReady <= 3)
            {
                AppealForBoats(Match.P1);
            }
            Console.Clear();

            Console.WriteLine("Es el turno del jugador 2 para colocar sus barcos");
            while (Match.P2.PlayerBoard.BoatsReady <= 3)
            {
                AppealForBoats(Match.P2); 
            }
            Console.Clear(); 
        }

        public void LetsPlay()
        {
            /*while (Match.P1.PlayerBoard.HitCounter <= 10 || Match.P2.PlayerBoard.HitCounter <= 10)
            {
                Match.P1.StatusOnTurn();

                while (Match.P1.PlayerStatus == Status.OnTurn)
                {
                    PlayerMove(Match.P1, Match.P2);
                }

                while (Match.P2.PlayerStatus == Status.OnTurn)
                {
                    PlayerMove(Match.P2, Match.P1);
                }
            }*/

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
                this.winner = Match.P2.Name;
                Console.WriteLine($"{Match.P2.Name} es el ganador!");
                Console.WriteLine($"Los Puntos de Victoria de {Match.P2.Name} aumentaron en +10");
                Console.WriteLine($"Los Puntos de Victoria de {Match.P2.Name} son: {Match.P2.VP}");
            }
            else
            {
                Match.P1.AddVp(10);
                this.winner = Match.P1.Name;
                Console.WriteLine($"{Match.P1.Name} es el ganador!");
                Console.WriteLine($"Los Putos de Victoria de {Match.P1.Name} aumentaron en +10");
                Console.WriteLine($"Los Putos de Victoria de {Match.P1.Name} son: {Match.P1.VP}");
            }

            PandTInfo.Add($"Batalla entre {Match.P1.Name} y {Match.P2.Name} / Fecha del encuentro: {DateTime.Now.ToString("dd'/'MM'/'yyyy")} / Duracion: {Match.Turns} turnos/ El ganador fue: {this.winner}"); 
            boardsInfo.Add(Match.P1.PlayerBoard);
            boardsInfo.Add(Match.P2.PlayerBoard);

            Match.P1.PlayerBoard.ResetBoard();
            Match.P2.PlayerBoard.ResetBoard();
            Match.ResetTurns();
            this.winner = null;  
            
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
            message=Console.ReadLine();
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
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su porta aviones");
                    string message= UserMessage(this.message);
                    coords = message.Split(" ");

                    if (!coords[2].Equals("horizontal") && !coords[2].Equals("vertical"))
                    {
                        throw new OrientationCheckerException("Orientation Error: Invalid Orientation.");
                    }

                    try
                    {   
                        int x = Int32.Parse(coords[0]);
                        int y = Int32.Parse(coords[1]);
                        if (x < 0 || x > 5 || y < 0 || y > 5)
                        {
                            throw new Exception("recuerda que las coordenadas deben ser numeros entre 0 y 5");
                        }
                        if (!player.PlayerBoard.NotOcuppied(x,y))
                        {
                            throw new Exception("posicion ya ocupada, intente nuevamente");
                        }
                        else if (!player.PlayerBoard.InLimits(x, y))
                        {
                            throw new Exception("posicion fuera de limites, intente nuevamente");   
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("coordenadas invalidas: ", e);
                    }

                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), carrier);
                    Console.WriteLine("El barco se coloco correctaente:");
                    break;

                case 1:
                    Destructor destructor = new Destructor();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su destructor");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), destructor);
                    Console.WriteLine("El barco se coloco correctaente:");
                    break;

                 case 2:
                    Submarine submarine= new Submarine();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su submarino");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), submarine);
                    Console.WriteLine("El barco se coloco correctaente:");
                    break;   

                case 3:
                    Vessel vessel = new Vessel();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su buque");
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

        public void ShowMatchInfo()
        {
            Console.WriteLine("-----------------------");
            foreach (string info in PandTInfo)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine("-----------------------");
            foreach(Board board in boardsInfo)
            {
              printinfo = new PrintBoard(board, board.Length, board.Length);
              printinfo.PrintInScreen();  
            }
            Console.WriteLine("-----------------------");
        }
    }
}  



