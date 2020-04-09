using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDB", menuName = "ItemDB")]
public class ItemDB : ScriptableObject, ISerializationCallbackReceiver {

    public List<Item> items;
    private Dictionary<int, Item> itemDic = new Dictionary<int, Item>();

    public void OnAfterDeserialize() {
        itemDic = new Dictionary<int, Item>();
        foreach (Item item in items) {
            itemDic.Add(item.itemID, item);
        }
    }

    public Item GetItem(int itemID) {
        if (itemDic.ContainsKey(itemID)) {
            return itemDic[itemID];
        }
        return null;
    }

    public void OnBeforeSerialize() {
    }
}
