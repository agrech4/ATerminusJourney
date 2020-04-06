using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject {

    public RuntimeAnimatorController animatorController;
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
}
