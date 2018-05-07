﻿using UnityEngine;

namespace Assets.Scripts.Blocks.Placed {
	/// <summary>
	/// A placed block which has a GameObject.
	/// </summary>
	public abstract class RealPlacedBlock : MonoBehaviour, IPlacedBlock {
		public BlockSides ConnectSides { get; protected set; }
		public BlockPosition Position { get; protected set; }
		public BlockType Type { get; protected set; }
		public byte Rotation { get; protected set; }
	}
}
