using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damager : MonoBehaviour
{
    public float damage;
    public void Damage(Damageable damageable) => damageable.Damage(damage);
}
