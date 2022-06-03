using System;
public class Submarino : IBarco
{
    private int id = 2;
    private int longitud = 2;
    private string name = "Subamrino";

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