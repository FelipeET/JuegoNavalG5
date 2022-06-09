using System;
public class Submarin : IBoat
{
    private int id = 2;
    private int boatLenght = 2;
    private string name = "Subamrino";

    public int ID{
        get{
            return id;
        }
    }

    public int BoatLength{
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