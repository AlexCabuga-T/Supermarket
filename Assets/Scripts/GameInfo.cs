using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInfo : MonoBehaviour
{   
    public static List<Transform> Pos = new List<Transform> ();    
    public static List<GameObject> ExpiringItems = new List<GameObject> ();
    public static List<GameObject> CurrentItems = new List<GameObject> ();

    public static int IncreaseScore = 1;
    public static int DecreaseScore = 2;
    public static int Score = 0;
}
