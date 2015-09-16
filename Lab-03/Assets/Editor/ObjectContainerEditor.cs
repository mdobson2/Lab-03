using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @author Mike Dobson
/// </summary>


[CustomEditor(typeof(ObjectContainer))]
public class ObjectContainerEditor : Editor {

    ObjectContainer containerScript;

    void Awake()
    {
        containerScript = (ObjectContainer)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //-----------------

        SerializedProperty enemyContainer = serializedObject.FindProperty("enemies");
        SerializedProperty weaponContainer = serializedObject.FindProperty("weapons");

        EditorGUILayout.PropertyField(enemyContainer);

        if(enemyContainer.isExpanded)
        {
            EditorGUILayout.PropertyField(enemyContainer.FindPropertyRelative("Array.size"));
            EditorGUI.indentLevel++;

            for(int i = 0; i < enemyContainer.arraySize; i++)
            {
                EditorGUILayout.PropertyField(enemyContainer.GetArrayElementAtIndex(i));
            }
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.PropertyField(weaponContainer);

        if(weaponContainer.isExpanded)
        {
            EditorGUILayout.PropertyField(weaponContainer.FindPropertyRelative("Array.size"));
            EditorGUI.indentLevel++;

            for(int i = 0; i < weaponContainer.arraySize; i++)
            {
                EditorGUILayout.PropertyField(weaponContainer.GetArrayElementAtIndex(i));
            }
            EditorGUI.indentLevel--;
        }

        //=================
        serializedObject.ApplyModifiedProperties();
    }


}
