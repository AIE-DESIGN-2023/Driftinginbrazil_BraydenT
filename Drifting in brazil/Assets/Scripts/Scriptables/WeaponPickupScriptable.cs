using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScriptable : MonoBehaviour
{
    public WeaponScriptableObject weaponToPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ProjectileManagerScriptable>().PickedUpWeapon(weaponToPickup);
        }
    }


}
