//Implementa IBoat (nombre: Destructor, id: 3 y longitud del barco: 3).
public class Destructor : IBoat
{
    private int id = 3;
    private int boatLength = 3;
    private string name = "Destructor";

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