//Contiene los enumerados GameEmpty, CraetingGame, Player1SetingBoard, Player2SetingBoard, 
//GameRunning y GameEnds, cuya funcion es ayudar al control de interacciones dentro de la Chain of Responsibility.
public enum GamePhase
{
    GameEmpty,
    CraetingGame, 
    Player1SettingBoard, 
    Player2SettingBoard, 
    GameRunning,
    GameEnds
}