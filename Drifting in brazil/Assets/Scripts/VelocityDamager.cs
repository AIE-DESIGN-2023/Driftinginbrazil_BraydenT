using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Damageable))]
public class VelocityDamager : Damager
{
    private Rigidbody rigidBody;
    private Damageable damageable;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        damageable = GetComponent<Damageable>();
    }

    public float minDamageVelocity;
    [Range(0, 1)] public float velocityThreshold;
    private void OnCollisionEnter(Collision collision)
    {
        float damageFactor = rigidBody.velocity.magnitude / minDamageVelocity;

        if(damageFactor > velocityThreshold)
        damageable.Damage(damage * damageFactor);
    }


}
