using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AmmoPickup")
        {
            ProjectileManagerScriptable weapon = collision.gameObject.GetComponentInChildren<ProjectileManagerScriptable>();
            if (weapon)
            {
                weapon.AddAmmo(weapon.maxAmmoSize);
                Destroy(gameObject);
            }
        }
    }
}
