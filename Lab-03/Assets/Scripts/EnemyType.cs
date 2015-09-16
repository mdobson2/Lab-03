using UnityEngine;
using System.Collections;

public enum AttackDamage
{
    PHYSICAL,
    SPELL
}

public enum SpellTypes
{
    FIRE,
    FROST,
    ARCANE
}



[System.Serializable]
public class EnemyType :MonoBehaviour {

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
