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
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impactFX, transform.position, Quaternion.identity);

        if (other.gameObject.tag == "Damageable")
        {
            Damageable damageable = other.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Damage(damageStrength);
            }

            Destroy(this.gameObject);
        }


        if (isEnemyBullet == false)
        {
            //check if the object we hit is tagged enemy
            if (other.gameObject.tag == "Enemy")
            {
                //check if collision object has enemy health script
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageStrength);
                }
            }

            Destroy(this.gameObject);
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageStrength);
                }
            }

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
