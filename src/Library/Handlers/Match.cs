//La clase Match es un singleton que contiene una instancia de Game. 
//Esto nos permite trabajar con esa misma instancia de game durante la ejecucion del programa.  
namespace PII_Batalla_Naval
{
    public class Match
    {

        //instancia de la clase Game
        public static Game game;

        private Match()
        {
            
        }

        private static Match instance;

        public static Match Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Match();
                }
                return instance;
            }
        }

        // metodo que se encarga de inicializar game
        public void CreateGame(string p1name, string p2name)
        {
            game = new Game(p1name, p2name);
        }

        public Game Game{
            get 
            {
                return game;
            }
        }
    }
}