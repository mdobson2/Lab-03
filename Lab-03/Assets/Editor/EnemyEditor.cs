using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @author Mike Dobson
/// </summary>


[CustomPropertyDrawer(typeof(EnemyType))]
public class EnemyEditor : PropertyDrawer
{
    EnemyType thisObject;

    float extraHeight = 100f;

    EnemyType enemyScript;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect enemyTypeDisplay = new Rect(position.x, position.y, position.width, 15f);

        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty name = property.FindPropertyRelative("name");
        SerializedProperty damageType = property.FindPropertyRelative("attackDamage");
        SerializedProperty spellType = property.FindPropertyRelative("spellType");
        SerializedProperty health = property.FindPropertyRelative("Health");
        SerializedProperty mana = property.FindPropertyRelative("Mana");

        //Weapon types
        SerializedProperty twoHanded = property.FindPropertyRelative("twoHanded");
        SerializedProperty dualWield = property.FindPropertyRelative("dualWield");

        //Armor types
        SerializedProperty clothArmor = property.FindPropertyRelative("clothArmor");
        SerializedProperty leatherArmor = property.FindPropertyRelative("leatherArmor");
        SerializedProperty mailArmor = property.FindPropertyRelative("mailArmor");
        SerializedProperty plateArmor = property.FindPropertyRelative("plateArmor");

        EditorGUI.PropertyField(enemyTypeDisplay, name);

        float offset = position.x;

        Rect damageTypeDisplay = new Rect(offset, position.y + 16f, position.width / 2, 15f);
        offset += position.width / 2;
        EditorGUI.PropertyField(damageTypeDisplay, damageType, GUIContent.none);

        if (damageType.enumValueIndex == (int)AttackDamage.SPELL)
        {
            Rect spellTypeDisplay = new Rect(offset, position.y + 16f, position.width / 2, 15f);
            EditorGUI.PropertyField(spellTypeDisplay, spellType, GUIContent.none);
        }

        offset = position.x;

        Rect healthDisplay = new Rect(offset, position.y + 32f, position.width / 2, 15f);
        offset += position.width / 2;
        EditorGUI.PropertyField(healthDisplay, health);

        if (damageType.enumValueIndex == (int)AttackDamage.SPELL)
        {
            Rect manaDisplay = new Rect(offset, position.y + 32f, position.width / 2, 15f);
            EditorGUI.PropertyField(manaDisplay, mana);
        }
        else
        {
            mana.floatValue = 0f;
        }

        offset = position.x;

        Rect weaponTypeLabelDisplay = new Rect(offset, position.y + 48f, position.width, 15f);
        EditorGUI.LabelField(weaponTypeLabelDisplay, "What type of weapons can this enemy use?");

        Rect twoHandedDisplay = new Rect(offset, position.y + 64f, position.width / 2, 15f);
        offset += position.width / 2;
        EditorGUI.PropertyField(twoHandedDisplay, twoHanded);

        Rect dualWieldDisplay = new Rect(offset, position.y + 64f, position.width / 2, 15f);
        offset = position.x;
        EditorGUI.PropertyField(dualWieldDisplay, dualWield);

        Rect armorTypeLabelDisplay = new Rect(offset, position.y + 80f, position.width, 15f);
        EditorGUI.LabelField(armorTypeLabelDisplay, "What type of armor can this enemy use?");

        if (damageType.enumValueIndex == (int)AttackDamage.SPELL)
        {
            Rect clothLabelDisplay = new Rect(offset, position.y + 96f, 50f, 15f);
            offset += 50;
            EditorGUI.LabelField(clothLabelDisplay, "Cloth");
            Rect clothDisplay = new Rect(offset, position.y + 96f, position.width/8, 15f);
            offset += position.width/8;
            EditorGUI.PropertyField(clothDisplay, clothArmor, GUIContent.none);
        }
        else
        {
            clothArmor.boolValue = false;
        }

        Rect leatherLabelDisplay = new Rect(offset, position.y + 96f, 50f, 15f);
        offset += 50;
        EditorGUI.LabelField(leatherLabelDisplay, "Leather");

        Rect leatherDisplay = new Rect(offset, position.y + 96f, position.width / 8, 15f);
        offset += position.width / 8;
        EditorGUI.PropertyField(leatherDisplay, leatherArmor, GUIContent.none);

        if(twoHanded.boolValue == false)
        {
            Rect mailLabelDisplay = new Rect(offset, position.y + 96f, 50f, 15f);
            offset += 50f;
            EditorGUI.LabelField(mailLabelDisplay, "Mail");

            Rect mailDisplay = new Rect(offset, position.y + 96f, position.width / 8, 15f);
            offset += position.width / 8;
            EditorGUI.PropertyField(mailDisplay, mailArmor,GUIContent.none);
        }
        else
        {
            mailArmor.boolValue = false;
        }

        Rect plateLabelDispaly = new Rect(offset, position.y + 96f, 50f, 15f);
        offset += 50f;
        EditorGUI.LabelField(plateLabelDispaly, "Plate");

        Rect plateDisplay = new Rect(offset, position.y + 96, position.width / 8, 15f);
        offset += position.width / 8;
        EditorGUI.PropertyField(plateDisplay, plateArmor, GUIContent.none);

        //==================================
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }

}
