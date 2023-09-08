using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //CONSTANTS
    public const float DefaultMapSize = 5f;
    public const float DefaultMusicVolume = 8f / 100f;
    public const int BatsCount = 2;




    // GLOBAL VARIABLES
    public static float MusicVolume = DefaultMusicVolume;
    public static int MapSize = 5;

    public static int currentPlayerX = 0;
    public static int currentPlayerY = 0;
    public static int currentWumpusX = 0;
    public static int currentWumpusY = 0;
    public static int[] currentBatsX = new int[BatsCount];
    public static int[] currentBatsY = new int[BatsCount];
    public static int currentPitX = 0;
    public static int currentPitY = 0;

    public static float Scale = 6.5f * (1f / ((float)Constants.MapSize / 4f));
    public static bool BoolGameLost = false;
    public static bool BoolWin = false;
    public static bool BoolPlayerTeleport = false;
    public static bool BoolChangeWumpusPosition = false;

}

