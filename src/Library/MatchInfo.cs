using System;
using System.Collections.Generic;

//clase que nos permitirá guardar los datos de cada partida que se juegue.

namespace PII_Batalla_Naval
{
    public class MatchInfo
    {
        //lista de caracteres que guarda numero de partida, 
        //los jugadores que participaron, fecha del encuentro y el ganador de la partida.
        private List<string> GameInfo = new List<string>();

        //lista de Boards que guarda los tableros finales de cada jugador en una partida.
        private List<Board> GameBoardsInfo = new List<Board>();

        //instancia de Print Board para imprimir lo guardado en GameBoardsInfo.
        PrintBoard printinfo;

        //entero que controla la cantidad de partidas jugadas.
        private int CantGames = 0;

        //agrega a GameInfo y  GameBoardsInfo la información que les corresponde.
        public void AddInfo(Game game)
        {
            GameInfo.Add($"INFO DE LA PARTIDA NUMERO {CantGames} / Batalla entre {game.P1.Name} y {game.P2.Name} / Fecha del encuentro: {DateTime.Now.ToString("dd'/'MM'/'yyyy")} / Duracion: {game.Turns} turnos/ El ganador fue: {game.winner}"); 
            GameBoardsInfo.Add(game.P1.PlayerBoard);
            GameBoardsInfo.Add(game.P2.PlayerBoard);
        }

        //Imprime los datos de cada partida jugada hasta el momento.
        public void ShowGameInfo(Game game)
        {
            Console.WriteLine("-------------------------------");
            foreach (string info in GameInfo)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine("-------------------------------");
            foreach(Board board in GameBoardsInfo)
            {
              Console.WriteLine($"Tableros finales de {game.P1.Name} y {game.P2.Name} respectivamente: ");
              printinfo = new PrintBoard(board, board.Length, board.Length);
              printinfo.PrintInScreen();  
            }
            Console.WriteLine("-------------------------------");
        }

        //suma 1 al valor de CantGames cada vez que termina una partida.
        public void GamesPlayed()
        {      
            CantGames++;
        }
    }
}