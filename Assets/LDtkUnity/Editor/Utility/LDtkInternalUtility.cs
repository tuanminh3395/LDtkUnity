﻿using UnityEditor;
using UnityEngine;

namespace LDtkUnity.Editor
{
    internal static class LDtkInternalUtility
    {
        private const string ASSETS = "Assets/LDtkUnity/";
        private const string PACKAGES = "Packages/com.cammin.ldtkunity/";
        
        public static T Load<T>(string pathFromRoot) where T : Object
        {
            //release package path
            string fullPath = PACKAGES + pathFromRoot;
            T template = AssetDatabase.LoadAssetAtPath<T>(fullPath);
            if (template != null) return template;
            
            //development environment path
            fullPath = ASSETS + pathFromRoot;
            template = AssetDatabase.LoadAssetAtPath<T>(fullPath);
            if (template != null) return template;

            Debug.LogError($"LDtk: Could not load the asset {typeof(T).Name} at path {fullPath}");
            return null;
        }
    }
}