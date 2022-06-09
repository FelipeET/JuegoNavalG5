using System;
public class Destructor : IBoat
{
    private int id = 3;
    private int boatLenght = 3;
    private string name = "Destructor";

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