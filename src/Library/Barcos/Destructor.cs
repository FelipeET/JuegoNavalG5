using System;
public class Destructor : IBarco
{
    private int id = 3;
    private int longitud = 3;
    private string name = "Destructor";

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