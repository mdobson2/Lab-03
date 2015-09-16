using UnityEngine;
using System.Collections;

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
public class WeaponScript : MonoBehaviour
{
    public Classification classification;
    public WeaponType weaponType;

    public bool upgradeable;

    public float damage;
}