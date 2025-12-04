using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collection : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txt;
    [SerializeField]
    private int increaseScore;
    [SerializeField]
    private int decreaseScore;
    [SerializeField]
    private SpawnItems spawnItems;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;        

        if (item.CompareTag("Healthy")) score += increaseScore;        
        else score -= decreaseScore;        
        txt.text = "Score: " + score;

        GameInfo.CurrentItems.Remove(item);
        GameInfo.ExpiringItems.Remove(item);
        spawnItems.Spawn();
        if (GameInfo.ExpiringItems.Contains(item)) spawnItems.StartExpire();
        Destroy(item);
    }
}
