using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjectTypes))]
public class ObjectTypeDrawer : PropertyDrawer {

    ObjectTypes thisObject;

    float extraHeight = 55f;

    int shouldSolidMove = 0;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect objectTypeDisplay = new Rect(position.x, position.y, position.width, 15f);

        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty objectType = property.FindPropertyRelative("type");

        SerializedProperty breakablePoints = property.FindPropertyRelative("breakablePoints");

        SerializedProperty solidMoving = property.FindPropertyRelative("solidMoving");
        SerializedProperty solidStart = property.FindPropertyRelative("solidStart");
        SerializedProperty solidEnd = property.FindPropertyRelative("solidEnd");

        SerializedProperty damageType = property.FindPropertyRelative("damageType");
        SerializedProperty damageAmount = property.FindPropertyRelative("damageAmount");

        SerializedProperty healingType = property.FindPropertyRelative("healingType");
        SerializedProperty healingPickupType = property.FindPropertyRelative("healingPickupType");
        SerializedProperty healingAmount = property.FindPropertyRelative("healingAmount");

        
        EditorGUI.PropertyField(objectTypeDisplay, objectType, GUIContent.none);

        switch((ObjectType)objectType.enumValueIndex)
        {
            case ObjectType.BREAKABLE:
                Rect breakableDisplay = new Rect(position.x, position.y + 17, position.width, 15f);
                EditorGUI.PropertyField(breakableDisplay, breakablePoints);
                break;
            case ObjectType.DAMAGING:
                float offset = position.x;

                Rect damageTypeLabelDisplay = new Rect(offset, position.y + 17f, 35f, 17f);
                offset += 35f;
                EditorGUI.LabelField(damageTypeLabelDisplay, "Type");

                Rect damageTypeDisplay = new Rect(offset, position.y + 17f, position.width / 3, 17f);
                offset += position.width / 3;
                EditorGUI.PropertyField(damageTypeDisplay, damageType, GUIContent.none);

                Rect damageAmountLabelDisplay = new Rect(offset, position.y + 17f, 55f, 17f);
                offset += 55f;
                EditorGUI.LabelField(damageAmountLabelDisplay, "Amount");

                Rect damageAmountDisplay = new Rect(offset, position.y + 17f, position.width / 3, 17f);
                EditorGUI.PropertyField(damageAmountDisplay, damageAmount, GUIContent.none);
                break;
            case ObjectType.HEALING:
                EditorGUI.indentLevel--;
                
                float offsetH = position.x;
                Rect healingLabelDisplay = new Rect(offsetH, position.y + 17f, 192f, 17f);
                offsetH += 192f;
                EditorGUI.LabelField(healingLabelDisplay, "This item will heal the player's");

                Rect healingTypeDisplay = new Rect(offsetH, position.y + 17f, position.width / 4, 17f);
                offsetH += position.width / 4;
                EditorGUI.PropertyField(healingTypeDisplay, healingType, GUIContent.none);

                healingLabelDisplay = new Rect(offsetH, position.y + 17f, 17f, 17f);
                offsetH += 17f;
                EditorGUI.LabelField(healingLabelDisplay, "by");

                Rect healingAmountDisplay = new Rect(offsetH, position.y + 17f, position.width / 13, 17f);
                offsetH += position.width / 13;
                EditorGUI.PropertyField(healingAmountDisplay, healingAmount, GUIContent.none);

                healingLabelDisplay = new Rect(offsetH, position.y + 17f, 35f, 17f);
                offsetH = position.x;
                EditorGUI.LabelField(healingLabelDisplay, "if it is");

                Rect healingPickupTypeDisplay = new Rect(offsetH, position.y + 35f, position.width / 4, 17f);
                offsetH += position.width / 4;
                EditorGUI.PropertyField(healingPickupTypeDisplay, healingPickupType, GUIContent.none);

                healingLabelDisplay = new Rect(offsetH, position.y + 35f, 50f, 17f);
                EditorGUI.LabelField(healingLabelDisplay, "with.");

                EditorGUI.indentLevel++;
                break;
            case ObjectType.PASSABLE:
                Rect passableDisplay = new Rect(position.x, position.y + 17f, position.width, 17f);
                EditorGUI.LabelField(passableDisplay, "There are no settings for passable objects.");
                break;
            case ObjectType.SOLID:
                Rect shouldMove = new Rect(position.x, position.y + 17, position.width, 17f);
                int index = solidMoving.boolValue ? 0 : 1;
                string[] options = new string[] { "Yes", "No" };
                index = EditorGUI.Popup(shouldMove, "Should it move?", index, options);
                solidMoving.boolValue = (index > 0) ? false : true;

                if(solidMoving.boolValue)
                {
                    float offsetS = position.x;
                    Rect startDisplay = new Rect(offsetS, position.y + 34, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.LabelField(startDisplay, "Start Position");

                    startDisplay = new Rect(offsetS, position.y + 34f, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.LabelField(startDisplay, "End Point");

                    offsetS = position.x;
                    startDisplay = new Rect(offsetS, position.y + 50f, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.PropertyField(startDisplay, solidStart, GUIContent.none);

                    startDisplay = new Rect(offsetS, position.y + 50f, position.width / 2, 17f);
                    offsetS += position.width / 2;
                    EditorGUI.PropertyField(startDisplay, solidEnd, GUIContent.none);
                }

                break;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }
}
