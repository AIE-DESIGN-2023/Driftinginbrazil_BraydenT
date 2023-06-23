using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    //references to health and healthbar
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;

    
    private Transform canvas;
    public GameObject canvasToOff;
    private Transform player;
    public UnityEvent OnDie;

    [SerializeField]
    private float ExplosionDelay;

    // Start is called before the first frame update
    void Start()
    {
        //set current health to max health
        currentHealth = maxHealth;
        canvas = GetComponentInChildren<Canvas>().transform;

        //turn off healthbar at the start
        canvasToOff.gameObject.SetActive(false);
    }

    private void Update()
    {

    }

    public void Damage(float damageToTake)
    {
        //turn on healthbar when taking damage
        canvasToOff.gameObject.SetActive(true);
        if (currentHealth <= 0)
            return;

        //deduct health when taking damage
        currentHealth -= damageToTake;
        Debug.Log("damage taken");

        //update image to show new health
        healthBar.fillAmount = currentHealth / maxHealth;

        //die when health drops to 0
        if (currentHealth <= 0)
        {
            canvasToOff.gameObject.SetActive(false);
            StartCoroutine(Die(ExplosionDelay));
        }
    }



    private IEnumerator Die(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        OnDie.Invoke();
    }
}