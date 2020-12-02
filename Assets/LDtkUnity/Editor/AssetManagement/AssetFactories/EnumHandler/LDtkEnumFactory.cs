﻿using System.IO;
using LDtkUnity.Editor.AssetManagement.EditorAssetLoading;
using UnityEditor;
using UnityEngine;

namespace LDtkUnity.Editor.AssetManagement.AssetFactories.EnumHandler
{
    public static class LDtkEnumFactory
    {
        private const string TEMPLATE_PATH = LDtkEnumFactoryPath.PATH + "EnumTemplate.txt";
        private const string TEMPLATE_DEFINITION = "#DEFINITION#";
        private const string TEMPLATE_VALUES = "#VALUES#";
        private const string TEMPLATE_PROJECT = "#PROJECT#";
        
        public static void CreateEnumFile(string folderPath, string type, string[] values, string projectName)
        {
            LDtkAssetDirectory.CreateDirectoryIfNotValidFolder(folderPath);
            
            string template = GenerateEnumTemplate(type, values, projectName);
            
            string writeFilePath = folderPath + type + ".cs";
            using (StreamWriter streamWriter = new StreamWriter(writeFilePath))
            {
                streamWriter.Write(template);
            }

            LDtkAsmRefFactory.CreateAssemblyDefinitionReference(folderPath);

            AssetDatabase.Refresh();
        }

        private static string GenerateEnumTemplate(string type, string[] values, string projectName)
        {
            string template = LDtkInternalLoader.Load<TextAsset>(TEMPLATE_PATH).text;
            string joinedValues = string.Join(",\n        ", values);

            projectName = projectName.Replace(" ", "_");

            template = template.Replace(TEMPLATE_PROJECT, projectName);
            template = template.Replace(TEMPLATE_DEFINITION, type);
            template = template.Replace(TEMPLATE_VALUES, joinedValues);
            
            return template;
        }
    }
}