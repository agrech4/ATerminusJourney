using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData {

    public string saveName;
    public string currentScene;
    public string charName;
    public Role role;
    public int lvl;
    public int exp;
    public int expToNextLvl;
    public AbilityValues abilityScores;
    public List<Abilities> saveProfs;
    public List<Skills> skillProfs;
    public List<WeaponType> weaponProfs;
    public Money purse;
    public List<(int id, int amount)> items = new List<(int, int)>();

    public PlayerSaveData(PlayerData data, Inventory inventory) {
        //PlayerData info
        saveName = data.saveName;
        currentScene = data.currentScene;
        charName = data.charName;
        role = data.role;
        lvl = data.lvl;
        exp = data.exp;
        expToNextLvl = data.expToNextLvl;
        abilityScores = data.abilityScores;
        saveProfs = data.saveProfs;
        skillProfs = data.skillProfs;
        weaponProfs = data.weaponProfs;
        purse = data.purse;

        //Inventory info
        foreach (InventorySlot itemSlot in inventory.itemList) {
            items.Add((itemSlot.itemID, itemSlot.amount));
        }
    }
}
