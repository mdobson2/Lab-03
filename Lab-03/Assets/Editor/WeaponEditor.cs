using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(WeaponScript))]
public class WeaponEditor : Editor
{

    WeaponScript weaponScript;
    bool weaponClass = false;
    bool weaponSettings = false;
    int Index;
    string[] options;

    void Awake()
    {
        weaponScript = (WeaponScript)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //-------------------------

        SerializedProperty classification = serializedObject.FindProperty("classification");
        SerializedProperty weaponType = serializedObject.FindProperty("weaponType");

        SerializedProperty upgradeable = serializedObject.FindProperty("upgradeable");
        SerializedProperty damage = serializedObject.FindProperty("damage");

        weaponClass = EditorGUILayout.Foldout(weaponClass, "Weapon Classification");
        if(weaponClass)
        {
            EditorGUILayout.PropertyField(classification);
            if(classification.enumValueIndex == (int)Classification.TWOHANDED)
            {
                options = new string[]{"Sword", "Hammer", "Scyth"};
                EditorGUILayout.Popup("Weapon Type", Index, options);
                if(Index == 0)
                {
                    weaponType.enumValueIndex = 0;
                }
                if(Index == 1)
                {
                    weaponType.enumValueIndex = 3;
                }
                if(Index == 2)
                {
                    weaponType.enumValueIndex = 4;
                }
            }
            if(classification.enumValueIndex == (int)Classification.ONEHANDED)
            {
                options = new string[] { "Sword", "Hammer" };
                EditorGUILayout.Popup("Weapon Type", Index, options);

                if (Index == 0)
                {
                    weaponType.enumValueIndex = 0;
                }
                if (Index == 1)
                {
                    weaponType.enumValueIndex = 3;
                }                
            }
            if(classification.enumValueIndex ==(int)Classification.OFFHAND)
            {
                options = new string[] { "Shield", "Relic" };
                EditorGUILayout.Popup("Weapon Type", Index, options);
                if (Index == 0)
                {
                    weaponType.enumValueIndex = 1;
                }
                if (Index == 1)
                {
                    weaponType.enumValueIndex = 2;
                }                
            }
        }

        weaponSettings = EditorGUILayout.Foldout(weaponSettings, "Weapon Settings");
        if (weaponSettings)
        {            
            EditorGUILayout.PropertyField(damage);

            if (weaponType.enumValueIndex != (int)WeaponType.HAMMER)
            {
                EditorGUILayout.PropertyField(upgradeable);
            }
        }

        //=========================
        serializedObject.ApplyModifiedProperties();
    }
}
