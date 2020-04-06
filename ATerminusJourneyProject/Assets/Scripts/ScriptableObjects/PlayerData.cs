using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject {

    public RuntimeAnimatorController animatorController;
    public string saveName;
    public string currentScene;
    public string charName;
    public int lvl;
    public int exp;
    public int expToNextLvl;
    public AbilityValues abilityScores;
    public List<Abilities> saveProfs;
    public List<Skills> skillProfs;
    public List<WeaponType> weaponProfs;
    public Money purse;
    public Item[] inventory;

    public void loadData(PlayerSaveData data) {
        saveName = data.saveName;
        currentScene = data.currentScene;
        charName = data.charName;
        lvl = data.lvl;
        exp = data.exp;
        expToNextLvl = data.expToNextLvl;
        abilityScores = data.abilityScores;
        saveProfs = data.saveProfs;
        skillProfs = data.skillProfs;
        weaponProfs = data.weaponProfs;
        purse = data.purse;
    }
}
