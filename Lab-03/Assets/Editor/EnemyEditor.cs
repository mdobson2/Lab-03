using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EnemyType))]
public class EnemyEditor : Editor 
{
    EnemyType enemyScript;
    
    void Awake()
    {
        enemyScript = (EnemyType)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //------------------------

        SerializedProperty name = serializedObject.FindProperty("name");
        SerializedProperty attackDamage = serializedObject.FindProperty("attackDamage");
        SerializedProperty spellType = serializedObject.FindProperty("spellType");
        SerializedProperty health = serializedObject.FindProperty("Health");
        SerializedProperty mana = serializedObject.FindProperty("Mana");

        //armor types
        SerializedProperty clothArmor = serializedObject.FindProperty("clothArmor");
        SerializedProperty leatherArmor = serializedObject.FindProperty("leatherArmor");
        SerializedProperty mailArmor = serializedObject.FindProperty("mailArmor");
        SerializedProperty plateArmor = serializedObject.FindProperty("plateArmor");

        //weapon types
        SerializedProperty twoHanded = serializedObject.FindProperty("twoHanded");
        SerializedProperty dualWield = serializedObject.FindProperty("dualWield");

        EditorGUILayout.PropertyField(name);
        EditorGUILayout.PropertyField(attackDamage);
        if (attackDamage.enumValueIndex == (int)AttackDamage.SPELL)
        {
            EditorGUILayout.PropertyField(spellType);
        }
        EditorGUILayout.LabelField("Damage Types");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(twoHanded);
        EditorGUILayout.PropertyField(dualWield);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Armor Types");
        EditorGUILayout.BeginHorizontal();
        if (attackDamage.enumValueIndex == (int)AttackDamage.SPELL)
        {
            EditorGUILayout.PropertyField(clothArmor);
        }
        EditorGUILayout.PropertyField(leatherArmor);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (twoHanded.boolValue == false)
        {
            EditorGUILayout.PropertyField(mailArmor);
        }
        EditorGUILayout.PropertyField(plateArmor);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(health);
        if (attackDamage.enumValueIndex == (int)AttackDamage.SPELL)
        {
            EditorGUILayout.PropertyField(mana);
        }

        //========================
        serializedObject.ApplyModifiedProperties();
    }
	
}
