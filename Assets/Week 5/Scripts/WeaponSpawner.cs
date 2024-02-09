using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject Weapon;
    
    public void spawnWeapon()
    {
        Instantiate(Weapon);
    }
}
