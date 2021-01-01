#region Using directives
using System;
#endregion

namespace treeDiM.StackBuilder.Engine.Heterogeneous2D
{
    public class ShelfNextFitBinPack
    {
		public ShelfNextFitBinPack()
		{
			binWidth = 0; binHeight = 0;
			currentX = 0; currentY = 0; shelfHeight = 0;
		}
		public ShelfNextFitBinPack(int width, int height)
		{
			Init(width, height);
		}
		public struct Node
		{
			public int X { get; set; }
			public int Y { get; set; }
			public int Width { get; set; }
			public int Height { get; set; }
			public bool Flipped { get; set; }
		};

		public void Init(int width, int height)
		{
			binWidth = width; binHeight = height;
			currentX = 0; currentY = 0; shelfHeight = 0;
		}

		public Node Insert(int width, int height)
		{
			Node newNode = new Node();
			// There are three cases:
			// 1. short edge <= long edge <= shelf height. Then store the long edge vertically.
			// 2. short edge <= shelf height <= long edge. Then store the short edge vertically.
			// 3. shelf height <= short edge <= long edge. Then store the short edge vertically.

			// If the long edge of the new rectangle fits vertically onto the current shelf,
			// flip it. If the short edge is larger than the current shelf height, store
			// the short edge vertically.
			if (((width > height && width < shelfHeight) ||
				(width < height && height > shelfHeight)))
			{
				newNode.Flipped = true;
				Swap(ref width, ref height);
			}
			else
				newNode.Flipped = false;

			if (currentX + width > binWidth)
			{
				currentX = 0;
				currentY += shelfHeight;
				shelfHeight = 0;

				// When starting a new shelf, store the new long edge of the new rectangle horizontally
				// to minimize the new shelf height.
				if (width < height)
				{
					Swap(ref width, ref height);
					newNode.Flipped = !newNode.Flipped;
				}
			}

			// If the rectangle doesn't fit in this orientation, try flipping.
			if (width > binWidth || currentY + height > binHeight)
			{
				Swap(ref width, ref height);
				newNode.Flipped = !newNode.Flipped;
			}

			// If flipping didn't help, return failure.
			if (width > binWidth || currentY + height > binHeight)
				return newNode;

			newNode.Width = width;
			newNode.Height = height;
			newNode.X = currentX;
			newNode.Y = currentY;

			currentX += width;
			shelfHeight = Math.Max(shelfHeight, height);

			usedSurfaceArea += width * height;

			return newNode;
		}

		private void Swap(ref int x, ref int y)
		{
			var temp = x;
			x = y;
			y = temp;
		}

		/// Computes the ratio of used surface area.
		public float Occupancy => (float)usedSurfaceArea / (binWidth * binHeight);
		
		private int binWidth;
		private int binHeight;
		private int currentX;
		private int currentY;
		private int shelfHeight;
		private int usedSurfaceArea;
	}
}
