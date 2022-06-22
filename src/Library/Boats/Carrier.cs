//Implementa IBoat (nombre: Porta Aviones, id: 4  y longitud del barco: 4).
public class Carrier : IBoat
{
    private int id = 4;
    private int boatLength = 4;
    private string name = "Porta Aviones";

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