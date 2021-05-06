using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LDtkUnity
{
    /// <summary>
    /// Stores the autogenerated sprites for the tiles, sprites for level backgrounds, and all TileBases for the Int Grid values, and for the LDtk tiles.
    /// </summary>
    [HelpURL(LDtkHelpURL.SCRIPTABLE_OBJECT_TILEMAP_COLLECTION)]
    public class LDtkArtifactAssets : ScriptableObject
    {
        public const string PROP_SPRITE_LIST = nameof(_cachedSprites);
        public const string PROP_TILE_LIST = nameof(_cachedTiles);

        [SerializeField] private List<Sprite> _cachedSprites = new List<Sprite>();
        [SerializeField] private List<TileBase> _cachedTiles = new List<TileBase>();

        public Sprite[] Sprites => _cachedSprites.ToArray();
        public TileBase[] Tiles => _cachedTiles.ToArray();

        public void AddSprite(Sprite sprite)
        {
            _cachedSprites.Add(sprite);
        }
        public void AddTile(TileBase tile)
        {
            _cachedTiles.Add(tile);
        }
        
        public Sprite GetSpriteByName(string spriteName) => GetItem(spriteName, _cachedSprites);
        public TileBase GetTileByName(string tileName) => GetItem(tileName, _cachedTiles);
        private T GetItem<T>(string assetName, IReadOnlyCollection<T> array) where T : Object
        {
            if (string.IsNullOrEmpty(assetName))
            {
                Debug.LogError("Tried getting an asset without no name");
                return null;
            }
            
            if (array.IsNullOrEmpty())
            {
                return null;
            }
            
            return array.FirstOrDefault(p => p.name.Equals(assetName));
        }
    }
}