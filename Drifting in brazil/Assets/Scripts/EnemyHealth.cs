using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public Image healthBar;

    private Transform canvas;
    private Transform player;

    public int moneyToDrop = 30;
    MoneyManagerScript moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        //set current health to max health
        currentHealth = maxHealth;
        canvas = GetComponentInChildren<Canvas>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moneyManager = FindObjectOfType<MoneyManagerScript>();
    }

    private void Update()
    {
        //Vector3 positionToLookAt = new Vector3(player.position.x, canvas.position.y, player.position.z);

        //canvas.LookAt(positionToLookAt);
    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        //update image to show new health
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            DoAddMoney();
            Destroy(gameObject);
            Debug.Log("destroy enemy");
        }
    }

    void DoAddMoney()
    {
        
        if (moneyManager != null)
        {
            Debug.Log("Adding money");
            moneyManager.AddMoney(moneyToDrop);
        }
    }
}
