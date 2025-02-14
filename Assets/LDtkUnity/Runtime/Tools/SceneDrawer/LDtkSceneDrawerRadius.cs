﻿using System.Reflection;
using UnityEngine;

namespace LDtkUnity
{
    public class LDtkSceneDrawerRadius : LDtkSceneDrawerBase
    {
        public override void Draw()
        {
            switch (Mode)
            {
                case EditorDisplayMode.RadiusPx:
                    DrawRadius(GridSize);
                    break;

                case EditorDisplayMode.RadiusGrid:
                    DrawRadius(1);
                    break;
            }
        }

        private void DrawRadius(float pixelsPerUnit)
        {
            if (pixelsPerUnit == 0)
            {
                Debug.LogError("Did not draw, avoided dividing by zero");
                return;
            }
            float radius = GetRadius() / pixelsPerUnit; 
                
#if UNITY_EDITOR
            UnityEditor.Handles.DrawWireDisc(Transform.position, Vector3.forward, radius);
#endif
                
        }
        
        private float GetRadius()
        {
            FieldInfo fieldInfo = GetFieldInfo();
            if (fieldInfo == null)
            {
                return default;
            }
                
            if (fieldInfo.FieldType == typeof(float))
            {
                return (float) fieldInfo.GetValue(Source);
            }
            if (fieldInfo.FieldType == typeof(int))
            {
                return (int) fieldInfo.GetValue(Source);
            }
            return default;
        }
    }
}