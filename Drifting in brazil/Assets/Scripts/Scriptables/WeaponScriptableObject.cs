using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//create menu aset
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponScriptableObject", order = 1)]


//change monobehaviour to scriptable object
public class WeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public GameObject bullet;

}
