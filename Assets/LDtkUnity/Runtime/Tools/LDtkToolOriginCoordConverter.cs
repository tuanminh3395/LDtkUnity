﻿using UnityEngine;

namespace LDtkUnity
{
    /// <summary>
    /// LDtk's coordinate system origin is based around the top-left. Convert that in order to be relative to Unity's bottom-left coordinate system.
    /// </summary>
    public static class LDtkToolOriginCoordConverter
    {
        public static Vector2Int IntGridValueCsvCoord(int csvIndex, Vector2Int cellSize)
        {
            int index = 0;
                
            for (int y = 0; y < cellSize.y; y++)
            {
                for (int x = 0; x < cellSize.x; x++)
                {
                    if (index == csvIndex)
                    {
                        return new Vector2Int(x, y);
                    }
                    index++;
                }
            }

            Debug.LogError("Failed to get CSV coord");
            return Vector2Int.zero;
        }

        public static Vector2Int ConvertCell(Vector2Int cellPos, int verticalCellCount)
        {
            cellPos = NegateY(cellPos);
            cellPos.y += verticalCellCount - 1;
            return cellPos;
        }
        
        public static Vector2 ConvertParsedPointValue(Vector2 relativeOrigin, Vector2Int cellPos, int lvlCellHeight)
        {
            cellPos = NegateY(cellPos);
            cellPos.y += lvlCellHeight - 1;
            Vector2 extraHalfUnit = Vector2.one * 0.5f;
            return relativeOrigin + cellPos + extraHalfUnit;
        }
        
        public static Vector2 LevelPosition(Vector2Int pixelPos, int pixelHeight, int pixelsPerUnit)
        {
            pixelPos += Vector2Int.up * pixelHeight;
            return (Vector2)NegateY(pixelPos) / pixelsPerUnit;
        }
        public static Vector2 EntityLocalPosition(Vector2Int pixelPos, int pixelHeight, int pixelsPerUnit)
        {
            pixelPos += Vector2Int.down * pixelHeight;
            return (Vector2)NegateY(pixelPos) / pixelsPerUnit;
        }

        public static Vector2 LevelBackgroundPosition(Vector2 pos, float pixelHeight, int pixelsPerUnit, float yScale)
        {

            pos += Vector2.up * (pixelHeight*yScale);
            return pos / pixelsPerUnit;
        }

        public static Vector2Int ImageSliceCoord(Vector2Int pos, int textureHeight, int sliceHeight)
        {
            pos = NegateY(pos);
            pos.y += textureHeight - sliceHeight;
            return pos;
        }
        public static Vector2 LevelBackgroundImageSliceCoord(Vector2 pos, int textureHeight, float sliceHeight)
        {
            pos = NegateY(pos);
            pos.y += textureHeight - sliceHeight;
            return pos;
        }

        private static Vector2Int NegateY(Vector2Int pos)
        {
            return new Vector2Int
            {       
                x = pos.x,
                y = - pos.y
            };
        }
        private static Vector2 NegateY(Vector2 pos)
        {
            return new Vector2
            {       
                x = pos.x,
                y = - pos.y
            };
        }
    }
}