using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class PlaceBoat
    {
        private bool flag = false;
        private int count = 0;
        public void AddBoat (Board board, int y, int x, Orientation ori, IBoat boat)
        {
            if (count < board.OnBoardBoats)
            {
                if (tab.InLimits(x,y) && tab.NotOcuppied(x,y))
                {
                    if (ori == Orientation.Vertical)
                    {
                        for(int i = 0; i < boat.BoatLength; i++)
                        {
                            if (board.InLimits(x, y + i) && board.NotOcuppied(x, y + i))
                            {
                                flag = true;
                            }
                        }
                        if (flag) 
                        {
                            for (int j = 0; j < boat.BoatLength; j++)
                            {
                                board.GetBoard()[x, y + j] = boat.ID;
                            }
                            count++;
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
                                flag = true;
                            }
                        }
                        if (flag) 
                        {
                            for (int j = 0; j < boat.BoatLength; j++)
                            {
                                board.GetBoard()[x + j, y] = boat.ID;
                            }
                            cont++;
                        }
                        else 
                        {
                            Console.WriteLine("El barco no puede ser posicionado en este lugar, intente nuevamete");
                        }

                    }
                }
                else
                {
                    if (!board.InLimits(x,y))
                    {
                        Console.WriteLine("Posicion fuera de los limites del tablero, intente nuevamete");
                    }
                    if (!board.NotOcuppied(x, y))
                    {
                         Console.WriteLine($"Posicion ya ocupada, no se puede agregar {boat.Name}, intente nuevamete");
                    }
                }
            } 
        }
    }
}