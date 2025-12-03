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
    private int MaxVisible;
    [SerializeField]
    private GameObject ExpireCanvas;
    [SerializeField]
    private int ExpireAmount;
    
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
                    GameInfo.FreePos.Add(pos);
                }
            }
        }

        // If MaxVisible is bigger than the amount of spawn positions, set MaxVisible to max
        if (MaxVisible > GameInfo.FreePos.Count) MaxVisible = GameInfo.FreePos.Count;

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

    private void StartExpire()
    {
        Transform p = GameInfo.OccupiedPos[Random.Range(0, GameInfo.OccupiedPos.Count)];
        GameInfo.ExpiringPos.Add(p);
        GameInfo.OccupiedPos.Remove(p);

        GameObject item = p.GetChild(0).gameObject;
        GameObject canvas = Instantiate(ExpireCanvas, item.transform);
        TextMeshProUGUI txtObj = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        StartCoroutine(Expire(item, p, txtObj));
    }

    private void Spawn()
    {
        Transform p = GameInfo.FreePos[Random.Range(0, GameInfo.FreePos.Count)];
        GameObject selectedItem = GameInfo.Items[Random.Range(0, GameInfo.Items.Count)];
        
        Instantiate(selectedItem, p);
        GameInfo.OccupiedPos.Add(p);
        GameInfo.FreePos.Remove(p);
    }

    public IEnumerator Expire(GameObject item, Transform p, TextMeshProUGUI txtObj)
    {
        int life = Random.Range(5, 11);

        for (int i = life; i > 0; i--)
        {
            txtObj.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        GameInfo.ExpiringPos.Remove(p);
        GameInfo.FreePos.Add(p);
        Destroy(item);        
        Spawn();
        StartExpire();
    }
}
