using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //variables for speed
    public float speed;
    public float lifetime;
    public int damageStrength;
    public bool isEnemyBullet;
    public GameObject impactFX;

    //variable for the rigidbody component and lifetime
    private Rigidbody rb;
    public float lifetimeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting velo of bullet to match speed var
        rb.velocity = transform.forward * speed;

        //increase lifetiem counter in seconds
        lifetimeCounter += Time.deltaTime;

        //check if lifetiem count is < lifetime
        if (lifetimeCounter >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    //collides with any collider
    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(impactFX, transform.position, Quaternion.identity);

        if (collision.gameObject.tag == "Damageable")
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Damage(damageStrength);
            }
        }


        if (isEnemyBullet == false)
        {
            //check if the object we hit is tagged enemy
            if (collision.gameObject.tag == "Enemy")
            {
                //check if collision object has enemy health script
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageStrength);
                }
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageStrength);
                }
            }
        }

        
        //final command
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
