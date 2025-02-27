using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{   //general
    public static bool DialogAreaOpen = false;
    //2scene 
    public static bool interactedWithEnemyNPC = false;
    //3 scene
    [SerializeField] public static int ShroomiesKilled = 0;
    public static bool CollidedWithYshel = false;
    public static bool InteractedWithYshel = false;
    public static bool YshelMoves = false;
    public static bool YshelTriggerer = false;
}
