﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject {

    public RuntimeAnimatorController animatorController;
    public RuntimeAnimatorController[] animatorControllers;
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
    public Item[] inventory;

    public void LoadData(PlayerSaveData data) {
        saveName = data.saveName;
        currentScene = data.currentScene;
        charName = data.charName;
        role = data.role;
        ChooseAnimator();
        lvl = data.lvl;
        exp = data.exp;
        expToNextLvl = data.expToNextLvl;
        abilityScores = data.abilityScores;
        saveProfs = data.saveProfs;
        skillProfs = data.skillProfs;
        weaponProfs = data.weaponProfs;
        purse = data.purse;
    }

    private void ChooseAnimator() {
        switch (role) {
            case Role.babarian:
                animatorController = animatorControllers[0];
                break;
            case Role.druid:
                animatorController = animatorControllers[1];
                break;
            case Role.fighter:
                animatorController = animatorControllers[2];
                break;
            case Role.priest:
                animatorController = animatorControllers[3];
                break;
        }
    }


    public void NewCharacter(string newRole, int saveNum) {
        switch (newRole) {
            case "barbarian":
            default:
                role = Role.babarian;
                break;
            case "druid":
                role = Role.druid;
                break;
            case "fighter":
                role = Role.fighter;
                break;
            case "priest":
                role = Role.priest;
                break;
        }
        ChooseAnimator();
        saveName = "Save" + saveNum.ToString("000");
        currentScene = "TownHub";
        charName = newRole.ToString();
        lvl = 1;
        exp = 0;
        expToNextLvl = 300;
        abilityScores = new AbilityValues();
        saveProfs = new List<Abilities>();
        skillProfs = new List<Skills>();
        weaponProfs = new List<WeaponType>();
        purse = new Money();
    }
}
