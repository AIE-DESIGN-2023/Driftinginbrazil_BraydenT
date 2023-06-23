using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectible : MonoBehaviour
{
    public int moneyAmount = 50;
    MoneyManagerScript moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoAddMoney();
        }
    }

    void DoAddMoney()
    {
        moneyManager.AddMoney(moneyAmount);
        Destroy(this.gameObject);
    }
}
