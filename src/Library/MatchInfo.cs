using System;
using System.Collections.Generic;

namespace PII_Batalla_Naval
{
    public class MatchInfo
    {
        private List<string> GameInfo = new List<string>();
        private List<Board> GameBoardsInfo = new List<Board>();
        PrintBoard printinfo;
        private int CantGames = 0;

        public void AddInfo(Game game)
        {
            GameInfo.Add($"INFO DE LA PARTIDA NUMERO {CantGames} / Batalla entre {game.P1.Name} y {game.P2.Name} / Fecha del encuentro: {DateTime.Now.ToString("dd'/'MM'/'yyyy")} / Duracion: {game.Turns} turnos/ El ganador fue: {game.winner}"); 
            GameBoardsInfo.Add(game.P1.PlayerBoard);
            GameBoardsInfo.Add(game.P2.PlayerBoard);
        }

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

        public void GamesPlayed()
        {      
            CantGames++;
        }
    }
}