/*using System;
using System.Collections.Generic;

//clase que nos permitirá guardar los datos de cada partida que se juegue.

namespace PII_Batalla_Naval
{
    public class PlayersRanking
    {
        //arreglo de caracteres que guarda los jugadores que participaron, segun sus VP.
        private string [] PlayersVP; 

        //agrega a GameInfo y  GameBoardsInfo la información que les corresponde.
        public void AddPlayers(Game game)
        {
            PlayersVP.Add($"INFO DE LA PARTIDA NUMERO {CantGames} / Batalla entre {game.P1.Name} y {game.P2.Name} / Fecha del encuentro: {DateTime.Now.ToString("dd'/'MM'/'yyyy")} / Duracion: {game.Turns} turnos/ El ganador fue: {game.winner}"); 
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
}*/