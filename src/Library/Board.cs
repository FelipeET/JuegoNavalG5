using System;

//clase que corresponde al tablero que cada jugador tendrá asignado para jugar.

namespace PII_Batalla_Naval
{
    public class Board
    {
        //corresponde a la cantidad máxima de barcos que se pueden posicionar en el tablero (4 en este caso).
        private int onBoardBoats = 4;

        //corresponde al largo y ancho del tablero (6 en nuestro caso).
        private int lenght = 6;

        //es una matriz de enteros la cual será la base lógica de nuestro tablero, pues los métodos 
        //lógicos del juego interactúan con dicha matriz y en base a 
        //esta las clases “Print” imprimen en pantalla un tablero correspondiente.
        private int [,] board;

        //corresponde a la cantidad de golpes a barcos que puede recibir un tablero (10 máximo). 
        //Al finalizar cada partida este contador debe volver a 0.
        private int hitCounter = 0; 
        private int watCounter = 0;

        //es un booleano que indicara true si y solo si todas las posiciones que ocuparía un barco 
        //en proceso de ser colocado son validas. 
        //Dando así paso al programa para agaragar las partes el barco a dichas posiciones.
        private bool flag;

        //nos permitirá seguir agregando barcos siempre y cuando no alcancemos 
        //la cantidad máxima de barcos permitidos en el tablero (4).
        private int count = 0;

        //nos permite controlar que barco falta agregar al tablero 
        //(esto funciona pues en nuestro juego se agregan  los barcos siempre en el mismo orden).
        private int boatsReady = 0;

        public int x;
        public int y;
        public int EachChecker=36;
        public Board ()
        {
            int[,] board = new int [lenght,lenght];
            this.board = board;
        }

        //recibe dos enteros que corresponden a una coordenada. 
        //Coloca en todas las entradas de board un 0, dejándolo así preparado para iniciar cualquier partida.
        public void BuildBoard()
        {  
            for (y=0; y < lenght; y++)
            {
                for (x=0; x < lenght; x++)
                {
                    this.board[x,y] = 0; 
                }
            }  
            BoardChecker(); 
        }

        public void BoardChecker()
        {    
            for (y=0; y < 6; y++)
            {
                for (x=0; x < 6; x++)
                {
                    while (EachChecker>=0)
                    {
                        if (this.board[x,y]!=0)
                        {
                            throw new BuildBoardCheckerException("Error al construir el tablero, se recomienda reiniciar el juego");
                        }
                        else
                        {
                            EachChecker--;
                        }
                    }
                }
            }
        }

        //recibe dos enteros que corresponden a una coordenada.  
        //Se asegura que las coordenadas ingresadas por un jugador están dentro de los límites del tablero.
        public bool InLimits(int x, int y)
        {
            if (x <= this.lenght && y <= this.lenght && x >= 0 && y >= 0)
            {
                return true;
            }
            if (x > this.lenght && y > this.lenght)
            {
                return false;
            }
            else{
                return true;
            }
        }

        //se asegura que la casilla del tablero referenciada por las coordenadas ingresadas por un jugador no está ocupada.  Si la casilla contiene un 0 está libre, de otra forma está ocupada.se asegura que la casilla del tablero referenciada por las coordenadas ingresadas por un jugador no está ocupada.  
        //Si la casilla contiene un 0 está libre, de otra forma está ocupada.
        public bool NotOcuppied(int x, int y)
        {
            if (this.board[x,y] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //recibe un tablero y dos enteros que corresponden a una coordenada. 
        //Si estas coordenadas están dentro de los límites del tablero 
        //(en caso contrario imprime "Posición invalida, intente nuevamente"), 
        //y la casilla que referencian no contiene un 5 o un 6 
        //(en dicho caso ya se habría disparado antes a dicha posición e imprimiría 
        //"Ya disparaste anteriormente a esta posición, intenta con otra") entonces:  
        //si el numero de la casilla es 0 lo cambia a 6 e imprime “Agua!”, 
        //pero si el número de la casilla es entre 1 y 4 lo cambia a 5 e imprime “Tocado!”. 
        public void Shoot(Board board, int y, int x)
        {
            
            if (board.InLimits(x, y) && board.GetBoard()[x,y] != 5 && board.GetBoard()[x,y] != 6)
            {
                if(board.GetBoard()[x,y] == 0)
                {
                    board.GetBoard()[x,y] = 6;
                    Console.WriteLine("Agua!");
                    board.watCounter++;
                }

                if(board.GetBoard()[x,y] >= 1 && board.GetBoard()[x,y] <= 4)
                {
                    //board.CountSunkens(board, y, x);
                    board.GetBoard()[x,y] = 5;
                    Console.WriteLine("Tocado!");
                    board.hitCounter++;
                }
            }
            else 
            {
                if (!board.InLimits(x, y))
                {
                Console.WriteLine("Posicion invalida, intente nuevamente");
                }
                else
                {
                Console.WriteLine("Ya disparatse anteriormente a esta posicion, intenta con otra");
                }
            }
        }

        //recibe un tablero, dos enteros que corresponden a una coordenada, 
        //una orientación y un barco. Primero asigna el valor false a flag, 
        //después, si count es menor a la cantidad de barcos permitidos en un tablero: 
        //pregunta si las coordenadas están en los límites del tablero y la casilla 
        //a la que hace referencia dicha coordenada no está ocupada 
        //(en caso de que una de estas condiciones falle se indicara mediante un mensaje). 
        //En base a la orientación elegida comienza a validar todas las casillas que ocuparía dicho barco 
        //(los barcos se colocan de izquierda a derecha según su coordenada inicial y 
        //si la posición es horizontal, o de arriba hacia abajo según su coordenada inicial y 
        //si la orientación es vertical) y si todas son validas entonces flag pasa a ser true. 
        //Una vez hecho esto se procede a agregar a dichas casillas el identificador del barco que se está intentando 
        //agregar al tablero.
        public void AddBoat (Board board, int y, int x, Orientation ori, IBoat boat)
        {
            this.flag = false;

            if (count < board.OnBoardBoats)
            {
                if (board.InLimits(x,y))
                {
                    if (board.NotOcuppied(x,y))
                    {
                        if (ori == Orientation.Vertical)
                        {
                            for(int i = 0; i < boat.BoatLength; i++)
                            {
                                if (board.InLimits(x, y + i) && board.NotOcuppied(x, y + i))
                                {
                                    this.flag = true;
                                }
                            }
                            if (this.flag) 
                            {
                                for (int j = 0; j < boat.BoatLength; j++)
                                {
                                    board.GetBoard()[x, y + j] = boat.ID;
                                }
                                this.count++;
                                this.boatsReady++;
                            }
                            else 
                            {
                                Console.WriteLine("El barco no puede ser posicionado en este lugar, intente nuevamete");
                            }
                        }
                        if (ori == Orientation.Horizontal)
                        {
                            for(int i = 0; i < boat.BoatLength; i++)
                            {
                                if (board.InLimits(x + i, y) && board.NotOcuppied(x + i, y))
                                {
                                    this.flag = true;
                                }
                            }
                            if (this.flag) 
                            {
                                for (int j = 0; j < boat.BoatLength; j++)
                                {
                                    board.GetBoard()[x + j, y] = boat.ID;
                                }
                                this.count++;
                                this.boatsReady++;
                            }
                            else 
                            {
                                Console.WriteLine("El barco no puede ser posicionado en este lugar, intente nuevamete");
                            }

                        }
                    }
                    else
                    {
                      Console.WriteLine($"Posicion ya ocupada, no se puede agregar {boat.Name}, intente nuevamete");  
                    }
                }
                else
                {
                    Console.WriteLine("Posicion fuera de los limites del tablero, intente nuevamete");
                }
            } 
        }
        
        //nos permite reiniciar los valores de ciertos atributos de Board (hittCounter, count, boatsReady) 
        //además de volver a colocar todas las casillas de tablero en 0 (BuildBoard). 
        //Esto deja el tablero listo para una siguiente partida.
        public void ResetBoard()
        {
            this.hitCounter = 0;
            this.count = 0;
            this.boatsReady = 0;
            this.watCounter =0;
            BuildBoard();
        }

        //devuelve cualquier entrada del tablero.
        public int [,] GetBoard() 
        {
            return this.board;
        }
        
        public int OnBoardBoats{
            get {
                return this.onBoardBoats;
            }
        }

        public int Length{
            get {
                return this.lenght;
            }
        }

        public int HitCounter
        {
            get 
            {
                return hitCounter;
            }
        }

        public int WatCounter{
            get{
                return watCounter;
            }
        }

        public int Count
        {
            get 
            {
                return count;
            }
        }

        public int BoatsReady
        {
            get 
            {
                return boatsReady;
            }
        }
    }
}
