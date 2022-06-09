using System;
public class Carrier : IBoat
{
    private int id = 4;
    private int boatLenght = 4;
    private string name = "Porta Aviones";

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