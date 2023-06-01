using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;

    private Transform canvas;
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
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //Vector3 positionToLookAt = new Vector3(player.position.x, canvas.position.y, player.position.z);

        //canvas.LookAt(positionToLookAt);
    }

    public void Damage(float damageToTake)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damageToTake;
        Debug.Log("damage taken");

        //update image to show new health
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            StartCoroutine(Die(ExplosionDelay));
        }
    }



    private IEnumerator Die(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        OnDie.Invoke();
    }
}