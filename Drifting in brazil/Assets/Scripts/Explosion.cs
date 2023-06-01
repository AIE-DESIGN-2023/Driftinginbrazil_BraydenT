using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Damager
{
    public float radius;
    public float power;
    public int damageStrength;

    private void OnEnable() => Explode();

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Rigidbody rigidbody))
            {
                Vector3 direction = (colliders[i].transform.position - transform.position).normalized;
                rigidbody.AddForce(direction * power, ForceMode.Impulse);
            }

            if (colliders[i].gameObject.tag == "Damageable")
            {
                Damageable damageable = colliders[i].gameObject.GetComponent<Damageable>();
                if (damageable != null)
                {
                    damageable.Damage(damageStrength);
                }
            }
            
            if (colliders[i].gameObject.tag == "Player")
            {
                PlayerHealth damageable = colliders[i].gameObject.GetComponent<PlayerHealth>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damageStrength);
                }
            }
            
            if (colliders[i].gameObject.tag == "Enemy")
            {
                EnemyHealth damageable = colliders[i].gameObject.GetComponent<EnemyHealth>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damageStrength);
                }
            }
        }
    }





    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
