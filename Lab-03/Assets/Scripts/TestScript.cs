using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EnemyType enemyScript = Camera.main.GetComponent<EnemyType>();
        WeaponScript weaponScript = Camera.main.GetComponent<WeaponScript>();

        Debug.Log("classification " + weaponScript.classification);
        Debug.Log("weapon type " + weaponScript.weaponType);
        Debug.Log("upgradeable " + weaponScript.upgradeable);
        Debug.Log("damage " + weaponScript.damage);

        Debug.Log("-");

        Debug.Log("name " + enemyScript.name);
        Debug.Log("damage type " + enemyScript.attackDamage);
        Debug.Log("spell type " + enemyScript.spellType);
        Debug.Log("cloth " + enemyScript.clothArmor);
        Debug.Log("leather " + enemyScript.leatherArmor);
        Debug.Log("mail " + enemyScript.mailArmor);
        Debug.Log("plate " + enemyScript.plateArmor);
        Debug.Log("two handed " + enemyScript.twoHanded);
        Debug.Log("dual wield " + enemyScript.dualWield);
        Debug.Log("health " + enemyScript.Health);
        Debug.Log("mana " + enemyScript.Mana);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
