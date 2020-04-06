using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ItemWeapon : Item {
    public WeaponType type;
    public List<WeaponProperties> properties;
    public int reach = 5;
    public int rangeNormal = 20;
    public int rangeLong = 60;
    public int toHitMod = 0;
    public Damage[] damages;
}
