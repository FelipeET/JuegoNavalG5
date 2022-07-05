/*using System;

//clase que contiene el funcionamiento lógico de la partida 
//(para esto utiliza métodos locales y otros pertenecientes a otras clases).

namespace PII_Batalla_Naval
{
    public class Logic
    {
        //referencia al Game que esta por llevarse a cabo.
        private Game Match; 

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

        //consta de los bucles while. El primero permite al jugador 1 colocar todos los barcos que le 
        //corresponden en su tablero. 
        //El segundo hace lo mismo pero para el jugador 2. Ambos bucles usan al método AppealForBoats.
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

        //consta de un bucle while principal que se ejecuta mientras que el tablero de uno de los jugadores 
        //no haya recibido  10 hits a barcos o mas (en este caso todos los barcos en ese tablero estarían hundidos).  
        //Dentro de este bucle se invoca el método StatusOnTurn para el jugador 1 
        //(lo deja habilitado para entrar a su turno), después se inicia un bucle while el cual se mantiene 
        //mientras que el jugador 1 este habilitado a jugar (su status debe ser OnTurn) e 
        //invoca al método PlayerMove que habilita la interacción de el jugador de turno con su enemigo. 
        //El siguiente bucle while hace lo mismo pero tomando al jugador 2 como el jugador de turno.
        //Una vez que se sale del while principal se indica que la partida termino y dependiendo de quién sea 
        //el ganador se procede a realizar las acciones correspondientes. 
        //Para finalizar se guarda la información final de la partida y se reinicia el tablero de ambos jugadores.
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

        //dependiendo de lo ingresado por el usuario en consola retorna una Orientation.
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

        /*
        Recibe un jugador como parámetro. En base a el valor de BoatsReady del tablero de dicho jugador s entra en un bloque switch. En caso de que sea:
        -0 se agrega un Porta Aviones.
        -1 se agrega un Destructor.
        -2 se agrega un Submarino.
        -3 se agrega un Buque.
        Obs1: en cada bloque caso se crea el barco que se pretende agregar al tablero y se le pide al jugador ingresar una coordenada y una orientación para dicho barco.
        Obs2: se utiliza un bloque try – catch para lidiar con posibles errores del usuario al intentar cumplir lo especificado en Obs1.
        El bloque default imprime "Todos los barcos listos".
        
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

        //recibe dos Player como parámetros (el jugador de turno y el enemigo respectivamente). 
        //Mientras que no se está al menos en el turno 3 de la partida usa PrintHidden para imprimri el 
        //tablero del rival (pues en teoría todavía ambos jugadores no han realizado movimientos contra su rival), 
        //una vez superado el turno 2 ya se utiliza enemy.PrintInScreen para imprimri el tablero rival. 
        //Se le pide al jugador de turno ingresar una coordenada para disparar 
        //(se implementa un bloque try – catch para lidiar con posibles errores en esta interacción). 
        //Después se utiliza el método Shoot para disparar al tablero del rival. Por último se pasa el status 
        //del jugador de turno a Waiting, el status del enemigo a OnTurn y se suma 1 a los turnos del match.
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
            Match.Turns++;
        }
    }
} */