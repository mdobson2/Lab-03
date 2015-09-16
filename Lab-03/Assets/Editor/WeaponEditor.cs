using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @author Mike Dobson
/// </summary>

[CustomPropertyDrawer(typeof(WeaponScript))]
public class WeaponEditor : PropertyDrawer
{
    WeaponScript thisObject;

    float extraHeight = 40f;

    WeaponScript weaponScript;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect weaponDisplay = new Rect(position.x, position.y, position.width, 15f);
        int Index = 0;
        EditorGUI.BeginProperty(position, label, property);
        //--------------------------------------

        SerializedProperty classification = property.FindPropertyRelative("classification");
        SerializedProperty weaponType = property.FindPropertyRelative("weaponType");

        SerializedProperty upgradeable = property.FindPropertyRelative("upgradeable");
        SerializedProperty damage = property.FindPropertyRelative("damage");

        string[] options = new string[] { null };

        float offset = position.x;

        Rect weaponClassDisplay = new Rect(offset, position.y + 17f, position.width / 2, 15f);
        offset += position.width / 2;
        EditorGUI.PropertyField(weaponClassDisplay, classification, GUIContent.none);

        switch(classification.enumValueIndex)
        {
            case (int)Classification.TWOHANDED:
                options = new string[]{"Sword", "Hammer", "Scyth"};
                break;
            case (int)Classification.ONEHANDED:
                options = new string[] { "Sword", "Hammer" };
                break;
            case (int)Classification.OFFHAND:
                options = new string[] { "Shield", "Relic" };
                break;
        }

        Rect weaponTypeDisplay = new Rect(offset, position.y + 17f, position.width / 2, 15f);
        offset = position.x;
        EditorGUI.Popup(weaponTypeDisplay, Index, options);

        switch(classification.enumValueIndex)
        {
            case (int)Classification.TWOHANDED:
                switch(Index)
                {
                    case 0:
                        weaponType.enumValueIndex = 0;
                        break;
                    case 1:
                        weaponType.enumValueIndex = 3;
                        break;
                    case 2:
                        weaponType.enumValueIndex = 4;
                        break;
                }
                break;
            case (int)Classification.ONEHANDED:
                switch(Index)
                {
                    case 0:
                        weaponType.enumValueIndex = 0;
                        break;
                    case 1:
                        weaponType.enumValueIndex = 3;
                        break;                    
                }
                break;
            case (int)Classification.OFFHAND:
                switch(Index)
                {
                    case 0:
                        weaponType.enumValueIndex = 1;
                        break;
                    case 1:
                        weaponType.enumValueIndex = 2;
                        break;
                }
                break;
        }

        Rect damageDisplay = new Rect(offset, position.y + 35f, position.width / 2, 15f);
        offset += position.width / 2;
        EditorGUI.PropertyField(damageDisplay, damage);

        if (weaponType.enumValueIndex != (int)WeaponType.HAMMER)
        {
            Rect upgradeableDisplay = new Rect(offset, position.y + 35f, position.width / 2, 15f);
            EditorGUI.PropertyField(upgradeableDisplay, upgradeable);
        }
        else
        {
            upgradeable.boolValue = false;
        }

        //======================================
        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }       
}
