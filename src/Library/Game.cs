using System;

//clase que reúne a dos jugadores que desean participar del juego y los coloca en un nuevo juego.
namespace PII_Batalla_Naval
{
    public class Game
    {
        //referencia al jugador 1.
        private Player p1;

        //referencia al jugador 2.
        private Player p2;

        //indica el turno en el cual se encuentra la partida.
        public int Turns = 1;

        //indica el ganador de dicha partida.
        public string winner;

        //indica en que fase del juego se estra (ayuda a los handlers)
        private GamePhase phase;

        //instancia de PrintBoard encargada de imprimir el tablero del jugador 1.
        private PrintBoard print1;

        //instancia de PrintBoard encargada de imprimir el tablero del jugador 2. 
        private PrintBoard print2;

        //instancia de PrintRivalBoard encargada de imprimir el tablero del jugador 2 
        //según el punto de vista del jugador 1. 
        private PrintRivalBoard printPlayer1;

        //instancia de PrintRivalBoard encargada de imprimir el tablero del jugador 1 
        //según el punto de vista del jugador 2.
        private PrintRivalBoard printPlayer2;

        //instancia de MatchInfo que nos permitirá guardar los datos de la partida.
        public MatchInfo info;

        private string message;


        public Game (string namep1, string namep2)
        {
            this.p1 = new Player(namep1);
            this.p2 = new Player(namep2);
            this.print1 = new PrintBoard(p1.PlayerBoard, p1.PlayerBoard.Length, p1.PlayerBoard.Length);
            this.print2 = new PrintBoard(p2.PlayerBoard, p2.PlayerBoard.Length, p2.PlayerBoard.Length);
            this.printPlayer1 = new PrintRivalBoard(p2.PlayerBoard, p2.PlayerBoard.Length, p2.PlayerBoard.Length);
            this.printPlayer2 = new PrintRivalBoard(p1.PlayerBoard, p1.PlayerBoard.Length, p1.PlayerBoard.Length);   
            this.phase = GamePhase.GameEmpty;
        }

        //Cambia el atributo phase de la clase Game
        public void ChangePhase(GamePhase newPhase)
        {
            this.phase = newPhase;
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
                    string message = UserMessage(this.message);
                    coords = message.Split(" ");

                    if (!coords[2].Equals("horizontal") && !coords[2].Equals("vertical"))
                    {
                        throw new OrientationCheckerException("Error de orientacion: Orientacion invalida.");
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
                            throw new IndexCheckerException("recuerda que las coordenadas deben ser numeros entre 0 y 5");
                        }
                        //Console.WriteLine("PRUEBA 4");
                        if (!player.PlayerBoard.NotOcuppied(x,y))
                        {
                            //Console.WriteLine("PRUEBA 5");
                            throw new FreePositionCheckerException("Posicion ya ocupada, intente nuevamente");
                        }
                        else if (!player.PlayerBoard.InLimits(x, y))
                        {
                            //Console.WriteLine("PRUEBA 6");
                            throw new LimitsCheckerException("Posicion fuera de limites, intente nuevamente");   
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
                    Console.WriteLine("El barco se coloco correctamente:");
                    break;

                case 1:
                    Destructor destructor = new Destructor();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Destructor (ocupa 3 espacios en el tablero)");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), destructor);
                    Console.WriteLine("El barco se coloco correctamente:");
                    break;

                 case 2:
                    Submarine submarine= new Submarine();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Submarino (ocupa 2 espacios en el tablero)");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                    player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[2]), submarine);
                    Console.WriteLine("El barco se coloco correctamente:");
                    break;   

                case 3:
                    Vessel vessel = new Vessel();
                    printAppeal.PrintInScreen();
                    Console.WriteLine("Ingrese una coordenada y una orientacion (X, Y, horizontal/vertical separadas por un espacio entre ellas) para su Buque (ocupa 1 espacios en el tablero)");
                    message = Console.ReadLine();
                    coords = message.Split(" ");
                   player.PlayerBoard.AddBoat(player.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]), GetOri(coords[0]), vessel);
                    Console.WriteLine("El barco se coloco correctamente:");
                    break;

                default:
                    Console.WriteLine("Todos los barcos listos.");
                    break;      

            }
        }

        public void PlayerMove(Player player, Player enemigo)
        {
            string message;
            String[] coords;
            PrintRivalBoard printEnemy = new PrintRivalBoard(enemigo.PlayerBoard, enemigo.PlayerBoard.Length, enemigo.PlayerBoard.Length);
            PrintBoard printTurnPlayer = new PrintBoard(player.PlayerBoard, player.PlayerBoard.Length, player.PlayerBoard.Length);
            
            Console.WriteLine($"Turno {this.Turns} / Juega: {player.Name}");
            Console.WriteLine($"Tablero de {player.Name}:");
            printTurnPlayer.PrintInScreen();
            if (this.Turns <= 2)
            {
                Console.WriteLine($"Tablero de {enemigo.Name}:");
                printEnemy.PrintHidden();
            }
            else
            {
                Console.WriteLine($"Tablero de {enemigo.Name}:");
                printEnemy.PrintInScreen();
            }
            Console.WriteLine("Ingrese una coordenada (X e Y separadas por un epacio entre si) a la cual deseas disparar");
            message = Console.ReadLine();
            coords = message.Split(" ");

            try
            {   
                int x = Int32.Parse(coords[0]);
                int y = Int32.Parse(coords[1]);
                if (x < 0 || x > 5 || y < 0 || y > 5)
                {
                    throw new IndexCheckerException("Las coordenadas deben ser un int entre 0 y 5.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Coordenadas invalidas: ", e);
            }

            enemigo.PlayerBoard.Shoot(enemigo.PlayerBoard, Int32.Parse(coords[0]), Int32.Parse(coords[1]));
            player.StatusWaiting();
            enemigo.StatusOnTurn();
            this.Turns++;
        }

        public Player P1
        {
            get 
            {
                return p1;
            }
        }

        public Player P2
        {
            get
            {
                return p2;
            }
        }

        public string Winner
        {
            get
            {
                return winner;
            }
        }

        public GamePhase Phase
        {
            get 
            {
                return phase;
            }
        }
        public int Turn
        {
            get{
                return Turns;
            }
        }
    }
}