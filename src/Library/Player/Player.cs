//Esta clase se utiliza para representar a los jugadores que participan en la batalla.
namespace PII_Batalla_Naval
{
    public class Player
    {
        //indica el nombre del jugador, el cual usaremos para identificarlo.
        private string name;

        //indica los puntos de victoria que posee el jugador 
        //(cuando el jugador gana una partida este suman puntos de victoria).
        private int vp = 0;

        //cada jugador tiene su propio tablero personal, el cual se usa al momento de jugar una partida. 
        //Cabe destacar que este tablero se reinicia una vez 
        //finalizada una partida, para que así pueda ser reutilizado en futuras batallas.
        private Board playerBoard;

        //nos permite asignarle un estado de juego al jugador, de modo que los métodos lógicos 
        //del juego saben cómo interactuar con el mismo a lo largo de una partida.
        private Status playerStatus;

        public Player(string _name)
        {
            this.name = _name;
            this.playerBoard = new Board();
            this.playerBoard.BuildBoard();
        }

        //este método nos habilita a asignar el enumerado Status.OnTurn al atributo PlayerStatus.
        public void StatusOnTurn()
        {
            playerStatus = Status.OnTurn;
        }
        
        //este método nos habilita a asignar el enumerado Status.Waiting al atributo PlayerStatus.
        public void StatusWaiting()
        {
            playerStatus = Status.Waiting;
        }

        //este método nos permite aumentar los Vp de cada jugador.
        public void AddVp (int vpToAdd)
        {
            this.vp += vpToAdd;
        }

        public string Name
        {
            get {

                return this.name;
            }   
        }

        public int VP
        {
            get {
                
                return vp;
            }
        }

        public Board PlayerBoard
        {
            get {
                
                return playerBoard;
            }
        }

         public Status PlayerStatus
        {
            get {
                
                return playerStatus;
            }
        }
    }
}
