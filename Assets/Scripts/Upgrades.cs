using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Information;
    [SerializeField]
    private TextMeshProUGUI IncreaseTxt;
    [SerializeField]
    private TextMeshProUGUI DecreaseTxt;

    private int upgrade = 0;
    // Start is called before the first frame update
    void Start()
    {
        IncreaseTxt.text = "Increase: " + GameInfo.IncreaseScore;
        DecreaseTxt.text = "Decrease: " + GameInfo.DecreaseScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowInformation()
    {
        Information.gameObject.SetActive(true);
    }

    private void HideInformation()
    {
        Information.gameObject.SetActive(false);
    }

    public void UpgradeScore()
    {
        upgrade = 1;
        ShowInformation();
        Information.text = "This upgrade will increase the amount of points you gain/lose by 1.";
    }

    public void UpgradeFall()
    {
        upgrade = 2;
        ShowInformation();
        Information.text = "This upgrade will slow down the fall time of the unhealthy foods into the cart.";
    }

    public void UpgradeLifetime()
    {
        upgrade = 3;
        ShowInformation();
        Information.text = "This upgrade will increase the minimum lifetimes of all foods by 1 second";
    }

    public void UpgradeAuto()
    {
        upgrade = 4;
        ShowInformation();
        Information.text = "The first time you buy this upgrade, a bot will automatically collect healthy foods into the cart or collect unhealthy foods into the bin. After first purchase, this upgrade will decrease the cooldown of this bot.";
    }

    public void Confirm()
    {
        if (upgrade == 1)
        {
            GameInfo.IncreaseScore++;
            GameInfo.DecreaseScore++;
            IncreaseTxt.text = "Increase: " + GameInfo.IncreaseScore;
            DecreaseTxt.text = "Decrease: " + GameInfo.DecreaseScore;
        }
        HideInformation();
    }
}
