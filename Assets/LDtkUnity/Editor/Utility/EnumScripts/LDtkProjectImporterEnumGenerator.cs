﻿using System.IO;
using System.Linq;
using UnityEditor;

#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif

namespace LDtkUnity.Editor
{
    /// <summary>
    /// Code mainly inspired from Unity's new input system code. 
    /// </summary>
    public class LDtkProjectImporterEnumGenerator
    {
        private readonly AssetImportContext _ctx;
        private readonly string _enumScriptPath;
        private readonly string _enumScriptNamespace;
        private readonly LDtkEnumFactoryTemplate[] _templates;
        
        public LDtkProjectImporterEnumGenerator(EnumDefinition[] enums, AssetImportContext ctx, string enumScriptPath, string enumScriptNamespace)
        {
            _templates = enums.Select(LDtkEnumFactoryTemplate.FromDefinition).ToArray();
            _ctx = ctx;
            _enumScriptPath = enumScriptPath;
            _enumScriptNamespace = enumScriptNamespace;
        }
        
        public void Generate()
        {
            string filePath = GetFilePath(_ctx);

            LDtkPathUtility.CleanPath(filePath);
            LDtkPathUtility.TryCreateDirectoryForFile(filePath);

            LDtkEnumFactory factory = new LDtkEnumFactory(_templates, filePath, _enumScriptNamespace);

            if (factory.CreateEnumFile())
            {
                EditorApplication.delayCall += AssetDatabase.Refresh;
            }
        }

        private string GetFilePath(AssetImportContext ctx)
        {
            string assetPath = ctx.assetPath;
            string directory = Path.GetDirectoryName(assetPath);
            
            // If no path is specified, place it as a sibling to the original asset
            if (string.IsNullOrEmpty(_enumScriptPath))
            {
                string fileName = Path.GetFileNameWithoutExtension(assetPath);
                return Path.Combine(directory, fileName) + ".cs";
            }

            // if the path specified to start relative to relative path
            if (_enumScriptPath.StartsWith("./") || 
                _enumScriptPath.StartsWith(".\\") || 
                _enumScriptPath.StartsWith("../") || 
                _enumScriptPath.StartsWith("..\\"))
            {
                return Path.Combine(directory, _enumScriptPath);
            }
            
            // If the path specified to start relative to the Assets folder
            if (!_enumScriptPath.ToLower().StartsWith("assets/") && 
                !_enumScriptPath.ToLower().StartsWith("assets\\"))
            {
                return Path.Combine("Assets", _enumScriptPath);
            }

            return _enumScriptPath;
        }
    }
}