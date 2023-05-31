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

    // Start is called before the first frame update
    void Start()
    {
        //set current health to max health
        currentHealth = maxHealth;
        canvas = GetComponentInChildren<Canvas>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 positionToLookAt = new Vector3(player.position.x, canvas.position.y, player.position.z);

        canvas.LookAt(positionToLookAt);
    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        //update image to show new health
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
