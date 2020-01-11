#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class LayerEditorHelpers
    {
        #region Constructor
        public LayerEditorHelpers(Size sz)
        {
            SizeImage = sz;
        }
        #endregion

        #region Public methods
        public Bitmap GetLayerImage()
        {
            Graphics2DImage graphics = new Graphics2DImage(SizeImage);
            graphics.SetViewport(PtMin, PtMax);

            uint pickId = 0;
            foreach (var bp in Positions)
            {
                Box b;
                if (Content is PackProperties pack)
                    b = new Pack(pickId++, pack, bp);
                else
                    b = new Box(pickId++, Content as PackableBrick, bp);
                graphics.DrawBox(b);
            }
            graphics.DrawRectangle(Vector2D.Zero, DimContainer, Color.OrangeRed);

            if (-1 != SelectedIndex)
            {
                var bp = Positions[SelectedIndex];

                Box boxSelected;
                if (Content is PackProperties pack)
                    boxSelected = new Pack((uint)SelectedIndex, pack, bp);
                else
                    boxSelected = new Box(((uint)SelectedIndex), Content as PackableBrick, bp);
                graphics.DrawBoxSelected(boxSelected);
            }
            return graphics.Bitmap;
        }

        public int GetPickedIndex(Point pt, Vector3D dimCase, Vector2D dimContainer)
        {
            return BoxInteraction.SelectedPosition(Positions, dimCase, ReverseTransform(pt, dimCase, dimContainer));
        }

        public void MoveMax(HalfAxis.HAxis moveDir, Vector3D dimCase)
        {
            // sanity check
            if (SelectedIndex < 0 || SelectedIndex > Positions.Count - 1) return;
            // update position
            BoxPosition bpos = Positions[SelectedIndex];
        }

        public void Move(HalfAxis.HAxis moveDir, double stepMove, Vector3D dimCase)
        {
            // sanity check
            if (SelectedIndex < 0 || SelectedIndex > Positions.Count - 1) return;
            // update position
            BoxPosition bpos = Positions[SelectedIndex];
            BoxPosition bposNew = bpos.Translate(moveDir, stepMove);
            if (!BoxInteraction.HaveIntersection(Positions, dimCase, SelectedIndex, bposNew)
                && BoxInteraction.BoxCanMoveInside(Positions[SelectedIndex], dimCase, PtMin, PtMax, moveDir))
                Positions[SelectedIndex] = bposNew;

            else
            {
                double distance = 0;
                if (BoxInteraction.MinDistance(Positions, dimCase, SelectedIndex, moveDir, ref distance))
                {
                    bposNew = bpos.Translate(moveDir, distance);
                    Positions[SelectedIndex] = bposNew;
                }
            }
        }

        private Vector2D ReverseTransform(Point pt, Vector3D dimCase, Vector2D dimContainer)
        {
            double maxDim = double.MinValue;
            maxDim = Math.Max(maxDim, dimCase.X);
            maxDim = Math.Max(maxDim, dimCase.Y);
            maxDim = Math.Max(maxDim, dimCase.Z);

            double[] Viewport = new double[4];
            Viewport[0] = -maxDim;
            Viewport[1] = -maxDim;
            Viewport[2] = dimContainer.X + maxDim;
            Viewport[3] = dimContainer.Y + maxDim;

            double ViewportRatio = (Viewport[2] - Viewport[0]) / (Viewport[3] - Viewport[1]);
            double AspectRatio = (double)SizeImage.Width / SizeImage.Height;

            double VPSpanX = Viewport[2] - Viewport[0];
            double VPSpanY = Viewport[3] - Viewport[1];
            double VRatio = ViewportRatio / AspectRatio;

            if (VRatio >= 1)
            {
                return new Vector2D(
                    Viewport[0] + VPSpanX * (((double)pt.X / SizeImage.Width) ),
                    Viewport[3] - pt.Y * VRatio * VPSpanY / SizeImage.Height
                    );
            }
            else
            {
                return new Vector2D(
                    Viewport[0] + (VPSpanX / VRatio) * ((pt.X / (double)SizeImage.Width)),
                    Viewport[3] - (pt.Y / (double)SizeImage.Height) * VPSpanY
                    );
            }
        }

        #endregion

        #region Private properties
        public Vector2D PtMin => Vector2D.Zero - new Vector2D(MaxContentDim, MaxContentDim);
        public Vector2D PtMax => DimContainer + new Vector2D(MaxContentDim, MaxContentDim);
        public double MaxContentDim
        {
            get
            {
                if (null == Content) return 0.0;
                double max = double.MinValue;
                max = Math.Max(Content.OuterDimensions.X, max);
                max = Math.Max(Content.OuterDimensions.Y, max);
                max = Math.Max(Content.OuterDimensions.Z, max);
                return max;
            }
        }
        #endregion

        #region Data members
        public List<BoxPosition> Positions { get; set; }
        public Size SizeImage { get; set; }
        public Packable Content { get; set; }
        public Vector2D DimContainer { get; set; }
        public int SelectedIndex { get; set; } = -1;
        #endregion
    }
}
