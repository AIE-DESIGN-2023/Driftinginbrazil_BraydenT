using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        ProjectileManagerScriptable weapon = collision.gameObject.GetComponentInChildren<ProjectileManagerScriptable>();
        if (weapon)
        {
            weapon.AddAmmo(weapon.maxAmmoSize);
            Destroy(gameObject);
        }
    }
}
