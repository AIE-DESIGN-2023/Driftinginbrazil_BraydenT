using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit an ammo pickup");
            ProjectileManagerScriptable weapon = collision.GetComponentInChildren<ProjectileManagerScriptable>();
            if (weapon != null)
            {
                Debug.Log("Adding ammo");
                weapon.AddAmmo(200);
                Destroy(gameObject);
            }
        }
    }
}
