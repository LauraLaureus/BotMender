﻿using System.Collections.Generic;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Shared;
using UnityEngine.Assertions;

namespace Assets.Scripts.Structures {
	/// <summary>
	/// Utility methods for both the EditableStructure and the CompleteStructure classes.
	/// </summary>
	public static class StructureUtilities {
		/// <summary>
		/// Removes the blocks from the dictionary which are connected to the specified block (directly or not).
		/// </summary>
		public static void RemoveConnected<T>(T block, int ignoreBit, IDictionary<BlockPosition, T> blocks) where T : IBlock {
			Assert.IsTrue(blocks.Remove(block.Position), "The block is no longer in the dictionary.");
			for (int bit = 0; bit < 6; bit++) {
				if (bit == ignoreBit) {
					continue;
				}

				BlockSides side = block.ConnectSides & (BlockSides)(1 << bit);
				BlockPosition offseted;
				T other;
				if (side == BlockSides.None
					|| !block.Position.GetOffseted(side, out offseted)
					|| !blocks.TryGetValue(offseted, out other)) {
					continue;
				}

				int inverseBit = bit % 2 == 0 ? bit + 1 : bit - 1;
				if ((other.ConnectSides & (BlockSides)(1 << inverseBit)) != BlockSides.None) {
					RemoveConnected(other, inverseBit, blocks);
				}
			}
		}
	}
}
