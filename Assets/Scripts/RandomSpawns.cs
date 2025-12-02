using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawns : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Positions;
    [SerializeField]
    private List<GameObject> Items;  
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject pos in Positions)
        {
            GameObject item = Items[Random.Range(0, Items.Count)];

            Instantiate(item, pos.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
