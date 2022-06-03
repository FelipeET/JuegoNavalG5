using System;
public class PortaAviones : IBarco
{
    private int id = 4;
    private int longitud = 4;
    private string name = "Porta Aviones";

    public int ID{
        get{
            return id;
        }
    }

    public int Longitud{
        get{
            return longitud;
        }
    }

    public string Name{
        get{
            return name;
        }
    }
}