//Implementa IBoat (nombre: Buque, id: 1 y longitud del barco: 1).
public class Vessel : IBoat
{
    private static int id = 1;
    private static int boatLength = 1;
    private static string name = "Buque";

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