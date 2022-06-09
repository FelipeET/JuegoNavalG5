using System;
public class Vessel : IBoat
{
    private int id = 1;
    private int boatLenght = 1;
    private string name = "Buque";

    public int ID{
        get{
            return id;
        }
    }

    public int BoatLenght{
        get{
            return boatLenght;
        }
    }

    public string Name{
        get{
            return name;
        }
    }
}