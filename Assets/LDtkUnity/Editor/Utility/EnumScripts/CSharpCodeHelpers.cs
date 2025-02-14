﻿using System;
using System.Linq;
using System.Text;

namespace LDtkUnity.Editor
{
    /// <summary>
    /// Reference code from Unity's Input System
    /// https://github.com/Unity-Technologies/InputSystem/blob/develop/Packages/com.unity.inputsystem/InputSystem/Utilities/CSharpCodeHelpers.cs
    /// </summary>
    internal static class CSharpCodeHelpers
    {
        public static bool IsProperIdentifier(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (char.IsDigit(name[0]))
                return false;

            return name.All(ch => char.IsLetterOrDigit(ch) || ch == '_');
        }

        public static bool IsEmptyOrProperIdentifier(string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            return IsProperIdentifier(name);
        }

        public static bool IsEmptyOrProperNamespaceName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            return name.Split('.').All(IsProperIdentifier);
        }

        private static string MakeIdentifier(string name, string suffix = "")
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (char.IsDigit(name[0]))
                name = "_" + name;

            // See if we have invalid characters in the name.
            bool nameHasInvalidCharacters = false;
            foreach (char ch in name)
            {
                if (char.IsLetterOrDigit(ch) || ch == '_')
                {
                    continue;
                }
                
                nameHasInvalidCharacters = true;
                break;
            }

            // If so, create a new string where we remove them.
            if (nameHasInvalidCharacters)
            {
                StringBuilder buffer = new StringBuilder();
                foreach (char ch in name)
                {
                    if (char.IsLetterOrDigit(ch) || ch == '_')
                        buffer.Append(ch);
                }

                name = buffer.ToString();
            }

            return name + suffix;
        }

        public static string MakeTypeName(string name, string suffix = "")
        {
            string symbolName = MakeIdentifier(name, suffix);
            if (char.IsLower(symbolName[0]))
                symbolName = char.ToUpper(symbolName[0]) + symbolName.Substring(1);
            return symbolName;
        }
    }
}