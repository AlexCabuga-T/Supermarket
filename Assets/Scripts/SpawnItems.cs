using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private GameObject ShelfUnits_List;
    [SerializeField]
    private GameObject ExpireCanvas;
    [SerializeField]
    private int MaxVisible;
    [SerializeField]
    private int ExpireAmount;
    [SerializeField]
    private int ExpireMin;
    [SerializeField]
    private int ExpireMax;
    [SerializeField]
    private List<GameObject> Items;
    
    // Start is called before the first frame update
    void Start()
    {
        // Put all spawn positions into a list
        foreach (Transform shelfUnit in ShelfUnits_List.transform)
        {
            foreach (Transform shelf in shelfUnit)
            {
                Transform posList = shelf.Find("Positions");

                foreach (Transform pos in posList)
                {
                    GameInfo.Pos.Add(pos);
                }
            }
        }

        // If MaxVisible is bigger than the amount of spawn positions, set MaxVisible to max
        if (MaxVisible > GameInfo.Pos.Count) MaxVisible = GameInfo.Pos.Count;

        // Spawn items
        for (int i = 0; i < MaxVisible; i++)
        {
            Spawn();
        }        

        for (int i = 0; i < ExpireAmount; i++)
        {
            StartExpire();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        // Calculate free positions available
        List<Transform> freePos = new List<Transform> (GameInfo.Pos);        
        foreach (GameObject i in GameInfo.CurrentItems)
        {            
            freePos.Remove(i.transform.parent);
        }        

        // Selects random free position and item        
        Transform p = freePos[Random.Range(0, freePos.Count)];
        GameObject item = Items[Random.Range(0, Items.Count)];

        // Spawn in item at position
        GameObject newItem = Instantiate(item, p);
        GameInfo.CurrentItems.Add(newItem);        
    }

    public void StartExpire()
    {
        // Calculate fresh items available
        List<GameObject> freshItems = new List<GameObject> (GameInfo.CurrentItems);
        foreach (GameObject i in GameInfo.ExpiringItems)
        {
            freshItems.Remove(i);
        }

        // Select random item to expire
        GameObject item = freshItems[Random.Range(0, freshItems.Count)];

        GameInfo.ExpiringItems.Add(item);
        GameObject canvas = Instantiate(ExpireCanvas, item.transform);
        TextMeshProUGUI txt = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        StartCoroutine(Expire(item, item.transform.parent, txt));        
    }

    public IEnumerator Expire(GameObject item, Transform p, TextMeshProUGUI txt)
    {
        int life = Random.Range(ExpireMin, ExpireMax + 1);

        for (int i = life; i > 0; i--)
        {
            txt.text = i.ToString();
            yield return new WaitForSeconds(1);

        }

        GameInfo.CurrentItems.Remove(item);
        GameInfo.ExpiringItems.Remove(item);
        Destroy(item);
        Spawn();
        StartExpire();
    }
}
