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

        public Game (Player p1_, Player p2_)
        {
            this.p1 = p1_;
            this.p2 = p2_;
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
    }
}