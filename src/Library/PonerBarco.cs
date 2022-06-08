using System;
using System.IO;

namespace PII_Batalla_Naval
{
    public class PonerBarco
    {
        private bool flag = false;
        private int cont = 0;
        public void AgregarBraco (Tablero tab, int y, int x, Orientacion ori, IBarco barco)
        {
            if (cont < tab.CantBarcosTotal)
            {
                if (tab.DentroDeLimites(x,y) && tab.NoOcupada(x,y))
                {
                    if (ori == Orientacion.Vertical)
                    {
                        for(int i = 0; i < barco.Longitud; i++)
                        {
                            if (tab.DentroDeLimites(x, y + i) && tab.NoOcupada(x, y + i))
                            {
                                flag = true;
                            }
                        }
                        if (flag) 
                        {
                            for (int j = 0; j < barco.Longitud; j++)
                            {
                                tab.GetBoard()[x, y + j] = barco.ID;
                            }
                            cont++;
                        }
                        else 
                        {
                            Console.WriteLine("El barco no puede ser posicionado en este lugar, intente nuevamete");
                        }
                    }
                    if (ori == Orientacion.Horizontal)
                    {
                        for(int i = 0; i < barco.Longitud; i++)
                        {
                            if (tab.DentroDeLimites(x + i, y) && tab.NoOcupada(x + i, y))
                            {
                                flag = true;
                            }
                        }
                        if (flag) 
                        {
                            for (int j = 0; j < barco.Longitud; j++)
                            {
                                tab.GetBoard()[x + j, y] = barco.ID;
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
                    if (!tab.DentroDeLimites(x,y))
                    {
                        Console.WriteLine("Posicion fuera de los limites del tablero, intente nuevamete");
                    }
                    if (!tab.NoOcupada(x, y))
                    {
                         Console.WriteLine($"Posicion ya ocupada, no se puede agregar {barco.Name}, intente nuevamete");
                    }
                }
            } 
        }
    }
}