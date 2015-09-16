using UnityEngine;
using System.Collections;

/// <summary>
/// @author Mike Dobson
/// </summary>


public enum AttackDamage
{
    PHYSICAL,
    SPELL
}

public enum SpellTypes
{
    NONE,
    FIRE,
    FROST,
    ARCANE
}



[System.Serializable]
public class EnemyType {

    public string name;

    public AttackDamage attackDamage;
    public SpellTypes spellType;
    
    //armor types
    public bool clothArmor;
    public bool leatherArmor;
    public bool mailArmor;
    public bool plateArmor;

    //weapon types
    public bool twoHanded;
    public bool dualWield;

    public float Health;
    public float Mana;
}
