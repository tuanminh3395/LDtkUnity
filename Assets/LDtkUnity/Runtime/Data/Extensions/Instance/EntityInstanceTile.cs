﻿using UnityEngine;

namespace LDtkUnity
{
    public partial class EntityInstanceTile
    {
        public TilesetDefinition TilesetDefinition => LDtkProviderUid.GetUidData<TilesetDefinition>(TilesetUid);
        public Rect UnitySourceRect => SrcRect.ToRect();
    }
}