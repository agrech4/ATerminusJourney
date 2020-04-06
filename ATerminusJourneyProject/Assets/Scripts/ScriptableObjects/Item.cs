using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    weapon,
    hat,
    armor,
}


public abstract class Item : ScriptableObject
{

    public string itemName;
    public ItemType itemType;
    public bool needsAttunement;
    public Money value;
    public float weight;

}
