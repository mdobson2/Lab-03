using UnityEngine;
using System.Collections;

/// <summary>
/// @author Mike Dobson
/// </summary>

public enum Classification
{
    TWOHANDED,
    ONEHANDED,
    OFFHAND
}

public enum WeaponType
{
    SWORD = 0,
    SHIELD = 1,
    RELIC = 2,
    HAMMER = 3,
    SCYTH = 4
}

[System.Serializable]
public class WeaponScript
{
    public Classification classification;
    public WeaponType weaponType;

    public bool upgradeable;

    public float damage;

}