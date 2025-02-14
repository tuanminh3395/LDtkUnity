﻿using System;
using UnityEditor;
using UnityEngine;

namespace LDtkUnity.Editor
{
    [CustomEditor(typeof(LDtkFields))]
    public class LDtkFieldsEditor : UnityEditor.Editor
    {
        private static readonly GUIContent HelpBox = new GUIContent()
        {
            text = "Access the fields by gaining reference to this component with GetComponent<LDtkFields>();",
        };

        private void OnSceneGUI()
        {
            //todo try drawing the values in here. might be better than a point drawer component
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.HelpBox(HelpBox, true);
            
            SerializedProperty fieldsProp = serializedObject.FindProperty(LDtkFields.PROP_FIELDS);

            for (int i = 0; i < fieldsProp.arraySize; i++)
            {
                SerializedProperty elementProp = fieldsProp.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(elementProp);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}