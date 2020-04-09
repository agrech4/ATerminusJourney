using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public List<InventorySlot> itemList = new List<InventorySlot>();
    public ItemDB itemDB;
    
    public void LoadInventory(PlayerSaveData saveData) {
        itemList = new List<InventorySlot>();
        for (int i = 0; i < saveData.items.Count; i++) {
            Item item = itemDB.GetItem(saveData.items[i].id);
            InventorySlot itemSlot = new InventorySlot(saveData.items[i].id, item, saveData.items[i].amount);
            itemList.Add(itemSlot);
        }
    }

    public void NewInventory() {
        itemList = new List<InventorySlot>();
    }

    public void AddItem(int _itemID, int _amount) {
        if (itemList.Exists(x => x.itemID == _itemID)) {
            itemList.Find(x => x.itemID == _itemID).ChangeAmount(_amount);
        } else {
            Item item = itemDB.GetItem(_itemID);
            itemList.Add(new InventorySlot(_itemID, item, _amount));
        }
    }

    public void OnBeforeSerialize() {
    }

    public void OnAfterDeserialize() {
        foreach (InventorySlot itemSlot in itemList) {
            if (itemSlot.item != null) {
                if (itemSlot.itemID == itemSlot.item.itemID) {
                    continue;
                }
            }
            itemSlot.item = itemDB.GetItem(itemSlot.itemID);
        }
    }
}

[System.Serializable]
public class InventorySlot {

    public int itemID;
    public Item item;
    public int amount;

    public InventorySlot(int _itemID, Item _item, int _amount) {
        itemID = _itemID;
        item = _item;
        amount = _amount;
    }

    public bool ChangeAmount(int deltaAmount) {
        amount += deltaAmount;
        if (amount < 0 || amount > 99) {
            amount -= deltaAmount;
            return false;
        }
        return true;
    }
}