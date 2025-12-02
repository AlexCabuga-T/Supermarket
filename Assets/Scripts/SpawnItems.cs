using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Shelves;
    [SerializeField]
    private List<GameObject> Items;
    [SerializeField]
    private int MaxVisible;

    private List<Transform> PosList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {        
        foreach (GameObject s in Shelves)
        {
            Transform posList = s.transform.Find("Positions");
            List<Transform> poss = posList.GetComponentsInChildren<Transform>().ToList();

            poss.RemoveAt(0);            
            PosList.AddRange(poss);
        }

        if (MaxVisible > PosList.Count) MaxVisible = PosList.Count;
        
        for (int i = 0; i < MaxVisible; i++)
        {
            Transform p = PosList[Random.Range(0, PosList.Count)];
            GameObject item = Items[Random.Range(0, Items.Count)];
            
            Instantiate(item, p);
            PosList.Remove(p);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
