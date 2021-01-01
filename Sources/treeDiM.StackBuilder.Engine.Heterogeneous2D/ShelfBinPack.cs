#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
#endregion

namespace treeDiM.StackBuilder.Engine.Heterogeneous2D
{
	/* ShelfBinPack implements different bin packing algorithms that use the SHELF data structure.ShelfBinPack
	also uses GuillotineBinPack for the waste map if it is enabled. */
	public class ShelfBinPack
	{
		/// Default ctor initializes a bin of size (0,0). Call Init() to init an instance.
		public ShelfBinPack()
		{
			binWidth = 0; binHeight = 0; currentY = 0; usedSurfaceArea = 0;
			useWasteMap = false;
		}

		public ShelfBinPack(int width, int height, bool useWasteMap)
		{
			Init(width, height, useWasteMap);
		}

		/// Clears all previously packed rectangles and starts packing from scratch into a bin of the given size.
		public void Init(int width, int height, bool useWasteMap_)
		{
			useWasteMap = useWasteMap_;
			binWidth = width;
			binHeight = height;

			currentY = 0;
			usedSurfaceArea = 0;

			shelves.Clear();
			StartNewShelf(0);

			if (useWasteMap)
			{
				wasteMap.Init(width, height);
				wasteMap.FreeRectangles.Clear();
			}
		}

		/// Defines different heuristic rules that can be used in the packing process.
		public enum ShelfChoiceHeuristic
		{
			ShelfNextFit, ///< -NF: We always put the new rectangle to the last open shelf.
			ShelfFirstFit, ///< -FF: We test each rectangle against each shelf in turn and pack it to the first where it fits.
			ShelfBestAreaFit, ///< -BAF: Choose the shelf with smallest remaining shelf area.
			ShelfWorstAreaFit, ///< -WAF: Choose the shelf with the largest remaining shelf area.
			ShelfBestHeightFit, ///< -BHF: Choose the smallest shelf (height-wise) where the rectangle fits.
			ShelfBestWidthFit, ///< -BWF: Choose the shelf that has the least remaining horizontal shelf space available after packing.
			ShelfWorstWidthFit, ///< -WWF: Choose the shelf that will have most remainining horizontal shelf space available after packing.
		};

		/// Inserts a single rectangle into the bin. The packer might rotate the rectangle, in which case the returned
		/// struct will have the width and height values swapped.
		/// @param method The heuristic rule to use for choosing a shelf if multiple ones are possible.
		public Rect Insert(int width, int height, ShelfChoiceHeuristic method)
		{
			Rect newNode = new Rect();

			// First try to pack this rectangle into the waste map, if it fits.
			if (useWasteMap)
			{
				newNode = wasteMap.Insert(width, height, true, GuillotineBinPack.FreeRectChoiceHeuristic.RectBestShortSideFit,
					GuillotineBinPack.GuillotineSplitHeuristic.SplitMaximizeArea);
				if (newNode.Height != 0)
				{
					// Track the space we just used.
					usedSurfaceArea += width * height;
					return newNode;
				}
			}

			switch (method)
			{
				case ShelfChoiceHeuristic.ShelfNextFit:
					if (FitsOnShelf(shelves.Last(), width, height, true))
					{
						AddToShelf(shelves.Last(), width, height, ref newNode);
						return newNode;
					}
					break;
				case ShelfChoiceHeuristic.ShelfFirstFit:
					for (int i = 0; i < shelves.Count; ++i)
						if (FitsOnShelf(shelves[i], width, height, i == shelves.Count - 1))
						{
							AddToShelf(shelves[i], width, height, ref newNode);
							return newNode;
						}
					break;

				case ShelfChoiceHeuristic.ShelfBestAreaFit:
					{
						// Best Area Fit rule: Choose the shelf with smallest remaining shelf area.
						Shelf bestShelf = null;
						int bestShelfSurfaceArea = int.MaxValue;
						for (int i = 0; i < shelves.Count; ++i)
						{
							// Pre-rotate the rect onto the shelf here already so that the area fit computation
							// is done correctly.
							RotateToShelf(shelves[i], ref width, ref height);
							if (FitsOnShelf(shelves[i], width, height, i == shelves.Count - 1))
							{
								int surfaceArea = (binWidth - shelves[i].currentX) * shelves[i].height;
								if (surfaceArea < bestShelfSurfaceArea)
								{
									bestShelf = shelves[i];
									bestShelfSurfaceArea = surfaceArea;
								}
							}
						}

						if (null != bestShelf)
						{
							AddToShelf(bestShelf, width, height, ref newNode);
							return newNode;
						}
					}
					break;

				case ShelfChoiceHeuristic.ShelfWorstAreaFit:
					{
						// Worst Area Fit rule: Choose the shelf with smallest remaining shelf area.
						Shelf bestShelf = null;
						int bestShelfSurfaceArea = -1;
						for (int i = 0; i < shelves.Count; ++i)
						{
							// Pre-rotate the rect onto the shelf here already so that the area fit computation
							// is done correctly.
							RotateToShelf(shelves[i], ref width, ref height);
							if (FitsOnShelf(shelves[i], width, height, i == shelves.Count - 1))
							{
								int surfaceArea = (binWidth - shelves[i].currentX) * shelves[i].height;
								if (surfaceArea > bestShelfSurfaceArea)
								{
									bestShelf = shelves[i];
									bestShelfSurfaceArea = surfaceArea;
								}
							}
						}

						if (null != bestShelf)
						{
							AddToShelf(bestShelf, width, height, ref newNode);
							return newNode;
						}
					}
					break;

				case ShelfChoiceHeuristic.ShelfBestHeightFit:
					{
						// Best Height Fit rule: Choose the shelf with best-matching height.
						Shelf bestShelf = null;
						int bestShelfHeightDifference = 0x7FFFFFFF;
						for (int i = 0; i < shelves.Count; ++i)
						{
							// Pre-rotate the rect onto the shelf here already so that the height fit computation
							// is done correctly.
							RotateToShelf(shelves[i], ref width, ref height);
							if (FitsOnShelf(shelves[i], width, height, i == shelves.Count - 1))
							{
								int heightDifference = Math.Max(shelves[i].height - height, 0);
								Debug.Assert(heightDifference >= 0);

								if (heightDifference < bestShelfHeightDifference)
								{
									bestShelf = shelves[i];
									bestShelfHeightDifference = heightDifference;
								}
							}
						}

						if (null != bestShelf)
						{
							AddToShelf(bestShelf, width, height, ref newNode);
							return newNode;
						}
					}
					break;

				case ShelfChoiceHeuristic.ShelfBestWidthFit:
					{
						// Best Width Fit rule: Choose the shelf with smallest remaining shelf width.
						Shelf bestShelf = null;
						int bestShelfWidthDifference = 0x7FFFFFFF;
						for (int i = 0; i < shelves.Count; ++i)
						{
							// Pre-rotate the rect onto the shelf here already so that the height fit computation
							// is done correctly.
							RotateToShelf(shelves[i], ref width, ref height);
							if (FitsOnShelf(shelves[i], width, height, i == shelves.Count - 1))
							{
								int widthDifference = binWidth - shelves[i].currentX - width;
								Debug.Assert(widthDifference >= 0);

								if (widthDifference < bestShelfWidthDifference)
								{
									bestShelf = shelves[i];
									bestShelfWidthDifference = widthDifference;
								}
							}
						}

						if (null != bestShelf)
						{
							AddToShelf(bestShelf, width, height, ref newNode);
							return newNode;
						}
					}
					break;

				case ShelfChoiceHeuristic.ShelfWorstWidthFit:
					{
						// Worst Width Fit rule: Choose the shelf with smallest remaining shelf width.
						Shelf bestShelf = null;
						int bestShelfWidthDifference = -1;
						for (int i = 0; i < shelves.Count; ++i)
						{
							// Pre-rotate the rect onto the shelf here already so that the height fit computation
							// is done correctly.
							RotateToShelf(shelves[i], ref width, ref height);
							if (FitsOnShelf(shelves[i], width, height, i == shelves.Count - 1))
							{
								int widthDifference = binWidth - shelves[i].currentX - width;
								Debug.Assert(widthDifference >= 0);

								if (widthDifference > bestShelfWidthDifference)
								{
									bestShelf = shelves[i];
									bestShelfWidthDifference = widthDifference;
								}
							}
						}

						if (null != bestShelf)
						{
							AddToShelf(bestShelf, width, height, ref newNode);
							return newNode;
						}
					}
					break;
			}

			// The rectangle did not fit on any of the shelves. Open a new shelf.
			// Flip the rectangle so that the long side is horizontal.
			if (width < height && height <= binWidth)
				Swap(ref width, ref height);

			if (CanStartNewShelf(height))
			{
				if (useWasteMap)
					MoveShelfToWasteMap(shelves.LastOrDefault());
				StartNewShelf(height);
				Debug.Assert(FitsOnShelf(shelves.LastOrDefault(), width, height, true));
				AddToShelf(shelves.LastOrDefault(), width, height, ref newNode);
				return newNode;
			}
			/*
				///\todo This is problematic: If we couldn't start a new shelf - should we give up
				///      and move all the remaining space of the bin for the waste map to track,
				///      or should we just wait if the next rectangle would fit better? For now,
				///      don't add the leftover space to the waste map.
				else if (useWasteMap)
				{
					assert(binHeight - shelves.back().startY >= shelves.back().height);
					shelves.back().height = binHeight - shelves.back().startY;
					if (shelves.back().height > 0)
						MoveShelfToWasteMap(shelves.back());

					// Try to pack the rectangle again to the waste map.
					GuillotineBinPack::Node node = wasteMap.Insert(width, height, true, 1, 3);
					if (node.height != 0)
					{
						newNode.x = node.x;
						newNode.y = node.y;
						newNode.width = node.width;
						newNode.height = node.height;
						return newNode;
					}
				}
			*/

			// The rectangle didn't fit.
			return newNode;
		}

		private void Swap(ref int x, ref int y)
		{
			var temp = x;
			x = y;
			y = temp;
		}

        /// Computes the ratio of used surface area to the total bin area.
        public float Occupancy => (float)usedSurfaceArea / (binWidth * binHeight);
        private int binWidth;
        private int binHeight;

        /// Stores the starting y-coordinate of the latest (topmost) shelf.
        private int currentY;

        /// Tracks the total consumed surface area.
        private long usedSurfaceArea;

        /// If true, the following GuillotineBinPack structure is used to recover the SHELF data structure from losing space.
        private bool useWasteMap;
        private GuillotineBinPack wasteMap = new GuillotineBinPack();

        /// Describes a horizontal slab of space where rectangles may be placed.
        internal class Shelf
        {
			internal Shelf()
			{
				Console.WriteLine("New shelf!");
			}
            /// The x-coordinate that specifies where the used shelf space ends.
            /// Space between [0, currentX[ has been filled with rectangles, [currentX, binWidth[ is still available for filling.
            internal int currentX;
            /// The y-coordinate of where this shelf starts, inclusive.
            internal int startY;
            /// Specifices the height of this shelf. The topmost shelf is "open" and its height may grow.
            internal int height;
 
            /// Lists all the rectangles in this shelf.
            internal readonly List<Rect> usedRectangles = new List<Rect>();
        };

        private readonly List<Shelf> shelves = new List<Shelf>();

        /// Parses through all rectangles added to the given shelf and adds the gaps between the rectangle tops and the shelf
        /// ceiling into the waste map. This is called only once when the shelf is being closed and a new one is opened.
        void MoveShelfToWasteMap(Shelf shelf)
        {
			List<Rect> freeRects = wasteMap.FreeRectangles;

			// Add the gaps between each rect top and shelf ceiling to the waste map.
			for (int i = 0; i < shelf.usedRectangles.Count; ++i)
			{
				Rect r = shelf.usedRectangles[i];
                Rect nodeNew = new Rect
                {
                    X = r.X,
                    Y = r.Y + r.Height,
                    Width = r.Width,
                    Height = shelf.height - r.Height
                };
                if (nodeNew.Height > 0)
					freeRects.Add(nodeNew);
			}
			shelf.usedRectangles.Clear();

            // Add the space after the shelf end (right side of the last rect) and the shelf right side. 
            Rect newNode = new Rect
            {
                X = shelf.currentX,
                Y = shelf.startY,
                Width = binWidth - shelf.currentX,
                Height = shelf.height
            };
            if (newNode.Width > 0)
				freeRects.Add(newNode);

			// This shelf is DONE.
			shelf.currentX = binWidth;

			// Perform a rectangle merge step.
			wasteMap.MergeFreeList();
		}

        /// Returns true if the rectangle of size width*height fits on the given shelf, possibly rotated.
        /// @param canResize If true, denotes that the shelf height may be increased to fit the object.
        private bool FitsOnShelf(Shelf shelf, int width, int height, bool canResize)
        {
            int shelfHeight = canResize ? (binHeight - shelf.startY) : shelf.height;
            return ((shelf.currentX + width <= binWidth && height <= shelfHeight) ||
                (shelf.currentX + height <= binWidth && width <= shelfHeight));
        }

        /// Measures and if desirable, flips width and height so that the rectangle fits the given shelf the best.
        /// @param width [in,out] The width of the rectangle.
        /// @param height [in,out] The height of the rectangle.
        private void RotateToShelf(Shelf shelf, ref int width, ref int height)
        {
			// If the width > height and the long edge of the new rectangle fits vertically onto the current shelf,
			// flip it. If the short edge is larger than the current shelf height, store
			// the short edge vertically.
			if ((width > height && width > binWidth - shelf.currentX) ||
				(width > height && width < shelf.height) ||
				(width < height && height > shelf.height && height <= binWidth - shelf.currentX))
				Swap(ref width, ref height);
		}

        /// Adds the rectangle of size width*height into the given shelf, possibly rotated.
        /// @param newNode [out] The added rectangle will be returned here.
        private void AddToShelf(Shelf shelf, int width, int height, ref Rect newNode)
        {
			Debug.Assert(FitsOnShelf(shelf, width, height, true));

			// Swap width and height if the rect fits better that way.
			RotateToShelf(shelf, ref width, ref height);

			// Add the rectangle to the shelf.
			newNode.X = shelf.currentX;
			newNode.Y = shelf.startY;
			newNode.Width = width;
			newNode.Height = height;
			shelf.usedRectangles.Add(newNode);

			// Advance the shelf end position horizontally.
			shelf.currentX += width;
			Debug.Assert(shelf.currentX <= binWidth);

			// Grow the shelf height.
			shelf.height = Math.Max(shelf.height, height);
			Debug.Assert(shelf.height <= binHeight);

			usedSurfaceArea += width * height;
		}

        /// Returns true if there is still room in the bin to start a new shelf of the given height.
        private bool CanStartNewShelf(int height) => shelves.LastOrDefault().startY + shelves.LastOrDefault().height + height <= binHeight;


        /// Creates a new shelf of the given starting height, which will become the topmost 'open' shelf.
        private void StartNewShelf(int startingHeight)
        {
            if (shelves.Count > 0)
            {
                Debug.Assert(shelves.LastOrDefault().height != 0);
                currentY += shelves.LastOrDefault().height;
                Debug.Assert(currentY < binHeight);
            }

            Shelf shelf = new Shelf()
            {
                currentX = 0,
                height = startingHeight,
                startY = currentY
            };

            Debug.Assert(shelf.startY + shelf.height <= binHeight);
            shelves.Add(shelf);
        }
    }
}
