using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items = new List<GameObject>();

    public static List<Transform> FreePos = new List<Transform> ();
    public static List<Transform> OccupiedPos = new List<Transform> ();    
    public static List<GameObject> Items = new List<GameObject> ();
    public static List<Transform> ExpiringPos = new List<Transform> ();

    void Start()
    {
        Items = new List<GameObject> (items);
    }
}
