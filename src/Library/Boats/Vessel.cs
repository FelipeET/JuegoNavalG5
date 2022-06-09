using System;
public class Vessel : IBoat
{
    private int id = 1;
    private int boatLength = 1;
    private string name = "Buque";

    public int ID{
        get{
            return id;
        }
    }

    public int BoatLength{
        get{
            return boatLength;
        }
    }

    public string Name{
        get{
            return name;
        }
    }
}