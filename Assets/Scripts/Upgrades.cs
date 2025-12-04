using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI InformationTxt;
    [SerializeField]
    private TextMeshProUGUI PointsReqTxt;
    [SerializeField]
    private TextMeshProUGUI IncreaseTxt;
    [SerializeField]
    private TextMeshProUGUI DecreaseTxt;
    [SerializeField]
    private Image WarningImg;
    [SerializeField]
    private int Upgrade1Req;
    [SerializeField]
    private int Upgrade2Req;
    [SerializeField]
    private int Upgrade3Req;
    [SerializeField]
    private int Upgrade4Req;

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
        InformationTxt.gameObject.SetActive(true);
    }

    private void HideInformation()
    {
        InformationTxt.gameObject.SetActive(false);
    }

    private void ShowWarning()
    {
        WarningImg.gameObject.SetActive(true);
    }
    private void HideWarning()
    {
        Debug.Log("Hiding Warning");
        WarningImg.gameObject.SetActive(false);
    }

    public void UpgradeScore()
    {
        upgrade = 1;
        ShowInformation();
        HideWarning();
        InformationTxt.text = "This upgrade will increase the amount of points you gain/lose by 1.";
        PointsReqTxt.text = "Points Needed: " + Upgrade1Req;
    }

    public void UpgradeFall()
    {
        upgrade = 2;
        ShowInformation();
        HideWarning();
        InformationTxt.text = "This upgrade will slow down the fall time of the unhealthy foods by 1 second.";
        PointsReqTxt.text = "Points Needed: " + Upgrade2Req;
    }

    public void UpgradeLifetime()
    {
        upgrade = 3;
        ShowInformation();
        HideWarning();
        InformationTxt.text = "This upgrade will increase the minimum lifetimes of all foods by 1 second";
        PointsReqTxt.text = "Points Needed: " + Upgrade3Req;
    }

    public void UpgradeAuto()
    {
        upgrade = 4;
        ShowInformation();
        HideWarning();
        InformationTxt.text = "The first time you buy this upgrade, a bot will automatically collect healthy foods into the cart or collect unhealthy foods into the bin. After first purchase, this upgrade will decrease the cooldown of this bot.";
        PointsReqTxt.text = "Points Needed: " + Upgrade4Req;
    }

    public void Confirm()
    {        
        if (upgrade == 1)
        {
            if (!(GameInfo.Score >= Upgrade1Req))
            {
                ShowWarning();
                return;
            }
            GameInfo.IncreaseScore++;
            GameInfo.DecreaseScore++;
            IncreaseTxt.text = "Increase: " + GameInfo.IncreaseScore;
            DecreaseTxt.text = "Decrease: " + GameInfo.DecreaseScore;
            Upgrade1Req += 10;
        }
        else if (upgrade == 2)
        {
            if (!(GameInfo.Score >= Upgrade2Req))
            {
                ShowWarning();
                return;
            }
            GameInfo.FallTime++;
            Upgrade2Req += 2;
        }
        else if (upgrade == 3)
        {
            if (!(GameInfo.Score >= Upgrade3Req))
            {
                ShowWarning();
                return;
            }
            GameInfo.ExpireMin += 2;
            GameInfo.ExpireMax += 2;
            Upgrade3Req += 2;
        }
        else if (upgrade == 4)
        {
            if (!(GameInfo.Score >= Upgrade4Req))
            {
                ShowWarning();
                return;
            }
            Upgrade4Req += 50;
        }

            HideInformation();
    }
}
