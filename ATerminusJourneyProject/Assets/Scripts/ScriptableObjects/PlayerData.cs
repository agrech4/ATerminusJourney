using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject {

    //Any modifications here must be reflected in the SaveData
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
    public int speed;
    public Money purse;
    public Vector2 newScenePos;

    public void LoadPlayerData(PlayerSaveData data) {
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
        speed = data.speed;
        purse = data.purse;
    }

    private void ChooseAnimator() {
        switch (role) {
            case Role.barbarian:
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


    public void SetRoleFromString(string newRole) {
        if (!Enum.TryParse(newRole, out role)) {
            role = Role.barbarian;
        }
    }

    public void NewCharacterData(string newRole, int saveNum) {
        SetRoleFromString(newRole);
        ChooseAnimator();
        saveName = "Save" + saveNum.ToString("000");
        currentScene = "TownHub";
        charName = char.ToUpper(newRole.ToString()[0]) + newRole.ToString().Substring(1);
        lvl = 1;
        exp = 0;
        expToNextLvl = 300;
        abilityScores = new AbilityValues();
        saveProfs = new List<Abilities>();
        skillProfs = new List<Skills>();
        weaponProfs = new List<WeaponType>();
        purse = new Money();
    }

    public int GetModifier(Abilities ability) {
        int abilityScore = 0;
        switch (ability) {
            case Abilities.strength:
                abilityScore = abilityScores.Strength;
                break;
            case Abilities.dexterity:
                abilityScore = abilityScores.Dexterity;
                break;
            case Abilities.constitution:
                abilityScore = abilityScores.Constitution;
                break;
            case Abilities.intelligence:
                abilityScore = abilityScores.Intelligence;
                break;
            case Abilities.wisdom:
                abilityScore = abilityScores.Wisdom;
                break;
            case Abilities.charisma:
                abilityScore = abilityScores.Charisma;
                break;
            default:
                break;
        }
        return (int)(abilityScore - 10) / 2;
    }

    public int MovementInTiles() {
        return speed / 5;
    }
}
