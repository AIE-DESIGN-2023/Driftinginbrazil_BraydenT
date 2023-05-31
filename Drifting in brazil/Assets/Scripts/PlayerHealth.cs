using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;
    private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameStateManager = FindObjectOfType<GameStateManager>();
    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            gameStateManager.PlayerDies();

            //Debug.Log("Man im dead");
            //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }
}
