﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public string charName;
    public int lvl;
    public int exp;
    public int expToNextLvl;
    public AbilityValues abilityScores;
    public List<Abilities> saveProfs;
    public List<Skills> skillProfs;
    public List<WeaponType> weaponProfs;
    public Money purse;
    public string[] inventory;

    public PlayerSaveData(PlayerData data) {
        charName = data.charName;
        lvl = data.lvl;
        exp = data.exp;
        expToNextLvl = data.expToNextLvl;
        abilityScores = data.abilityScores;
        saveProfs = data.saveProfs;
        skillProfs = data.skillProfs;
        weaponProfs = data.weaponProfs;
        purse = data.purse;
        inventory = new string[data.inventory.Length];
        for (int i = 0; i < inventory.Length; i++) {
            inventory[i] = data.inventory[i].itemName;
        }
    }
}
