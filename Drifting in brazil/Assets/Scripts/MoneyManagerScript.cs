using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagerScript : MonoBehaviour
{
    public TextMeshProUGUI money;
    public int currentMoney = 100;
    public Transform resupplyPoint;
    public GameObject ammoPickup;
    public GameObject notEnoughMoneyText;
    public Transform notEnoughMoneyTextSpawn;
    public GameObject barrelCluster;
    public Transform barrelClusterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = 100;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "$ " + currentMoney;

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currentMoney >= 200)
            {
                Instantiate(ammoPickup, resupplyPoint.position, resupplyPoint.rotation, null);
                currentMoney -= 200;
            }
            else
            {
                Instantiate(notEnoughMoneyText, notEnoughMoneyTextSpawn.position, notEnoughMoneyTextSpawn.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (currentMoney >= 300)
            {
                Instantiate(barrelCluster, barrelClusterSpawn.position, barrelClusterSpawn.rotation, null);
                currentMoney -= 300;
            }
            else
            {
                Instantiate(notEnoughMoneyText, notEnoughMoneyTextSpawn.position, notEnoughMoneyTextSpawn.rotation);
            }
        }
    }

    public void AddMoney(int moneyAmount)
    {
        currentMoney += moneyAmount;
    }

    public void MinusMoney(int moneyAmount)
    {
        currentMoney -= moneyAmount;
    }
}
