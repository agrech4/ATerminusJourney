using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    weapon,
    hat,
    armor,
    consumable,
}


public abstract class Item : ScriptableObject {

    public int itemID;
    public GameObject prefab;
    public ItemType itemType;
    public string itemName;
    [TextArea(15,20)]
    public string description;
    public bool needsAttunement;
    public Money value;
    public float weight;

}
