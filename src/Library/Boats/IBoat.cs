/*
es una interface que define los atributos que todo barco debe tener:
    -Nombre: nos permite identificar al barco con un nombre en particular.
    -Id: nos permite saber qué lugar ocupa el barco en el tablero
    -Longitud del barco: se refiere a la cantidad de espacios en el tablero que puede ocupar el barco.
*/
public interface IBoat
{
    public string Name {get;}
    public int ID {get;}
    public int BoatLength {get;}
}