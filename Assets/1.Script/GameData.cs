using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public enum GameState
    {
        Lobby,
        Game,
        Dead
    }

    public static GameState gameState;
    public static float score;
    public static int highestScore = 0;
    public static float carSpeed = 10;
    public static float carSpeedUpTimer;
    
    public static int[] carSpeedLevel = { 50, 100, 150, 200, 250, 300, 350, 400, 450, 500 };
}
