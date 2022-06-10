using System;
using System.IO;

namespace PII_Batalla_Naval
{
  public class Hit
  {
    private int hitCounter;
    private bool effectedShot;
    public void Shoot(Board board, int y, int x)
    {
      effectedShot = false;
      
      if (board.InLimits(x, y) && board.GetBoard()[x,y] != 5 && board.GetBoard()[x,y] != 6)
      {
        if(board.GetBoard()[x,y] == 0)
          {
            board.GetBoard()[x,y] = 6;
            ValidShot(); 
          }
        if(board.GetBoard()[x,y] >= 1 && board.GetBoard()[x,y] <= 4)
          {
            board.GetBoard()[x,y] = 5;
            hitCounter++;
            ValidShot(); 
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

    public void ValidShot(){
      effectedShot = true;
    }

    public int HitCounter
    {
      get 
      {
        return hitCounter;
      }
    }

    public bool EffectedShot
    {
      get
      {
        return effectedShot;
      }
    }
  }
}