using System;
public class Buque : IBarco
{
    private int id = 1;
    private int longitud = 1;
    private string name = "Buque";

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