using UnityEngine;
using System.Collections;

/// <summary>
/// @author Mike Dobson
/// </summary>

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        ObjectContainer container = Camera.main.GetComponent<ObjectContainer>();

        foreach (WeaponScript weapon in container.weapons)
        {
            Debug.Log("classification " + weapon.classification);
            Debug.Log("weapon type " + weapon.weaponType);
            Debug.Log("upgradeable " + weapon.upgradeable);
            Debug.Log("damage " + weapon.damage);
            Debug.Log("---------------");
        }

        Debug.Log("=================");
        foreach (EnemyType enemy in container.enemies)
        {
            Debug.Log("name " + enemy.name);
            Debug.Log("damage type " + enemy.attackDamage);
            Debug.Log("spell type " + enemy.spellType);
            Debug.Log("cloth " + enemy.clothArmor);
            Debug.Log("leather " + enemy.leatherArmor);
            Debug.Log("mail " + enemy.mailArmor);
            Debug.Log("plate " + enemy.plateArmor);
            Debug.Log("two handed " + enemy.twoHanded);
            Debug.Log("dual wield " + enemy.dualWield);
            Debug.Log("health " + enemy.Health);
            Debug.Log("mana " + enemy.Mana);
            Debug.Log("---------------");
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
