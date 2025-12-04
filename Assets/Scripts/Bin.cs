using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreTxt;
    [SerializeField]
    private SpawnItems spawnItems;

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

        if (item.CompareTag("Healthy")) GameInfo.Score -= GameInfo.DecreaseScore;
        else GameInfo.Score += GameInfo.IncreaseScore;
        scoreTxt.text = "Score: " + GameInfo.Score;

        GameInfo.CurrentItems.Remove(item);
        GameInfo.ExpiringItems.Remove(item);
        spawnItems.Spawn();
        if (GameInfo.ExpiringItems.Contains(item)) spawnItems.StartExpire();
        Destroy(item);
    }
}
