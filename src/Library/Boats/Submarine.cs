//Implementa IBoat (nombre: Submarino, id: 2 y longitud del barco: 2).
public class Submarine : IBoat
{
    private static int id = 2;
    private static int boatLenght = 2;
    private static string name = "Submarino";

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