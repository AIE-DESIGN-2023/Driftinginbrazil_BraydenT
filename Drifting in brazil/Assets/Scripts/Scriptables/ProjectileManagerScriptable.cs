using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileManagerScriptable : MonoBehaviour
{
    public Transform spawnPosition;
    public Transform muzzleFlashPosition;
    public GameObject projectile;
    public GameObject muzzleFlash;
    public GameObject laserPointer;
    public WeaponScriptableObject currentWeapon;
    public List<WeaponScriptableObject> weaponsCollected;
    public TextMeshProUGUI currentWeaponText;

    private bool laserOn = false;

    //FULL AUTO FUNCTION
    private float lastAttackTime = 0f;
    public float fireRate = 5f; //how many bullets are fired/second

    //AMMO RELAOD SYSTEM
    public int currentClip, maxClipSize = 50, currentAmmo, maxAmmoSize = 500;

    // Start is called before the first frame update
    void Start()
    {
        weaponsCollected.Add(currentWeapon);
        //currentWeaponText.text = currentWeapon.weaponName;

        //turn off laser pointer at the start

        laserPointer.gameObject.SetActive(false);
        laserOn = false;

        //show weapon name
        currentWeaponText.text = currentWeapon.weaponName;
    }


    // Update is called once per frame
    void Update()
    {
        //check if left click is true, then fire projectiles if there is ammo in the magazine
        if (Input.GetButton("Fire1"))
        {
            if(currentClip > 0)
            {
                if (Time.time - lastAttackTime >= 1f / fireRate)
                {
                    //null is for the fact it does not have a parent
                Instantiate(currentWeapon.bullet, spawnPosition.position, spawnPosition.rotation, null);
                    Instantiate(muzzleFlash, muzzleFlashPosition.position, muzzleFlashPosition.rotation, null);
                currentClip--;
                    lastAttackTime = Time.time;
                }

            }     
        }

        //check if right click is true, then turn on or off the laser pointer
        if (Input.GetMouseButtonDown(1))
        {
            if (laserOn == false)
            {
                laserPointer.gameObject.SetActive(true);
                laserOn = true;
            }
            else
            {
                laserPointer.gameObject.SetActive(false);
                laserOn = false;
            }
        }

        //if R is presed, reload weapon
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        int numberPressed = GetPressedNumber();
        if (numberPressed > 0)
        {
            if (numberPressed <= weaponsCollected.Count)
            {
                currentWeapon = weaponsCollected[numberPressed - 1];
                currentWeaponText.text = currentWeapon.weaponName;
            }
            else
            {
                currentWeaponText.text = "Empty Slot";
            }
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip; //how many bullets to refill clip
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    //add ammo to the reserves when picking up ammo
    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }

    public void PickedUpWeapon(WeaponScriptableObject weaponPickedUp)
    {
        if (!weaponsCollected.Contains(weaponPickedUp))
        {
            currentWeapon = weaponPickedUp;
            weaponsCollected.Add(currentWeapon);
        }
    }

    public int GetPressedNumber()
    {
        //whatever a for loop is
        for (int number = 0; number <= 9; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
            {
                return number;
            }
        }

        return -1;
    }
}