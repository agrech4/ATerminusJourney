using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Abilities {
    strength,
    dexterity,
    constitution,
    intelligence,
    wisdom,
    charisma,
}

public enum Role {
    babarian,
    druid,
    fighter,
    priest,
}

public enum DamageType {
    slashing,
    piercing,
    bludgeoning,
    cold,
    poison,
    acid,
    psychic,
    fire,
    necrotic,
    radiant,
    force,
    thunder,
    lightning,
}

public enum Skills {
    strSave,
    dexSave,
    conSave,
    intSave,
    wisSave,
    charSave,
    athletics,
    acrobatics,
    sleightOfHand,
    stealth,
    arcana,
    history,
    investigation,
    nature,
    religion,
    animalHandling,
    insight,
    medicine,
    perception,
    survivial,
    deception,
    intimidation,
    performance,
    persuasion,
}

public enum WeaponProperties {
    ammunition,
    finesse,
    heavy,
    light,
    loading,
    range,
    reach,
    special,
    thrown,
    twoHanded,
    versatile,
}

public enum WeaponType {
    simple,
    martial,
}

[System.Serializable]
public struct AbilityValues {
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
}

[System.Serializable]
public struct Damage {
    public int dieNumber;
    public int dieType;
    public int damageMod;
    public DamageType damageType;
}

[System.Serializable]
public struct Money {
    public int cp;
    public int sp;
    public int ep;
    public int gp;
    public int pp;
}