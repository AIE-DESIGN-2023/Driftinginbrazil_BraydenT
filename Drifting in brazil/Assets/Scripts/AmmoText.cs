using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour
{
    public ProjectileManagerScriptable weapon;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
    }
    
    public void UpdateAmmoText()
    {
        text.text = $"{weapon.currentClip} / {weapon.maxClipSize} Ammo | {weapon.currentAmmo} / {weapon.maxAmmoSize} Reserve";
    }
}
