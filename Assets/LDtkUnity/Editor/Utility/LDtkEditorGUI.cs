﻿using UnityEditor;
using UnityEngine;

namespace LDtkUnity.Editor
{
    public static class LDtkEditorGUI
    {
        private const string ICON_NAME_INFO = "console.infoicon.sml";
        private const string ICON_NAME_WARNING = "console.warnicon.sml";
        private const string ICON_NAME_ERROR = "console.erroricon.sml";
        
        private const string ICON_NAME_INFO_BIG = "console.infoicon@2x";
        private const string ICON_NAME_WARNING_BIG = "console.warnicon@2x";
        private const string ICON_NAME_ERROR_BIG = "console.erroricon@2x";
        
        public delegate void IconDraw(Rect controlRect, string tooltip);
        
        public static void DrawInfo(Vector2 pos, string tooltipText, TextAnchor anchor) => DrawIconInternal(pos, ICON_NAME_INFO, tooltipText, anchor);
        public static void DrawWarning(Vector2 pos, string tooltipText, TextAnchor anchor) => DrawIconInternal(pos, ICON_NAME_WARNING, tooltipText, anchor);
        public static void DrawError(Vector2 pos, string tooltipText, TextAnchor anchor) => DrawIconInternal(pos, ICON_NAME_ERROR, tooltipText, anchor);
        
        
        

        public static void DrawInfoBig(Vector2 pos, string tooltipText, TextAnchor anchor) => DrawIconInternal(pos, ICON_NAME_INFO_BIG, tooltipText, anchor);
        public static void DrawWarningBig(Vector2 pos, string tooltipText, TextAnchor anchor) => DrawIconInternal(pos, ICON_NAME_WARNING_BIG, tooltipText, anchor);
        public static void DrawErrorBig(Vector2 pos, string tooltipText, TextAnchor anchor) => DrawIconInternal(pos, ICON_NAME_ERROR_BIG, tooltipText, anchor);

        private static void DrawIconInternal(Vector2 pos, string iconName, string tooltipText, TextAnchor anchor)
        {
            const float dimension = 16;
            Vector2 size = new Vector2(dimension, dimension);
            Rect rect = new Rect(pos, size);
            rect = LDtkEditorGUIUtility.ChangePositionBasedOnAnchor(rect, anchor);
            
            Texture2D tex = (Texture2D)EditorGUIUtility.IconContent(iconName).image;

            GUIContent content = new GUIContent("", null, tooltipText);

            GUI.Label(rect, content);
            GUI.DrawTexture(rect, tex);
        }
        
        
        public static void DrawFieldInfo(Rect controlRect, string tooltip) => DrawInfo(GetFieldIconPosition(controlRect), tooltip, TextAnchor.MiddleRight);
        public static void DrawFieldWarning(Rect controlRect, string tooltip) => DrawWarning(GetFieldIconPosition(controlRect), tooltip, TextAnchor.MiddleRight);
        public static void DrawFieldError(Rect controlRect, string tooltip) => DrawError(GetFieldIconPosition(controlRect), tooltip, TextAnchor.MiddleRight);
        public static Vector2 GetFieldIconPosition(Rect controlRect)
        {
            float labelWidth = LDtkEditorGUIUtility.LabelWidth(controlRect.width);
            return new Vector2(controlRect.xMin + labelWidth, controlRect.yMin + controlRect.height / 2);
        }
    }
}