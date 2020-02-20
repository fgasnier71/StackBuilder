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
        public LayerEditorHelpers(Size sz, Vector3D dimCase, Vector2D dimContainer)
        {
            SizeImage = sz;
            DimCase = dimCase;
            DimContainer = dimContainer;
        }
        #endregion

        #region Public methods
        public Bitmap GetLayerImage(Packable content)
        {
            Graphics2DImage graphics = new Graphics2DImage(SizeImage);
            graphics.SetViewport(PtMin, PtMax);

            uint pickId = 0;
            foreach (var bp in Positions)
            {
                Box b;
                if (content is PackProperties pack)
                    b = new Pack(pickId++, pack, bp);
                else
                    b = new Box(pickId++, content as PackableBrick, bp);
                graphics.DrawBox(b);
            }
            graphics.DrawRectangle(Vector2D.Zero, DimContainer, Color.OrangeRed);

            if (-1 != SelectedIndex)
            {
                var bp = Positions[SelectedIndex];

                Box boxSelected;
                if (content is PackProperties pack)
                    boxSelected = new Pack((uint)SelectedIndex, pack, bp);
                else
                    boxSelected = new Box((uint)SelectedIndex, content as PackableBrick, bp);
                graphics.DrawBoxSelected(boxSelected);

                // draw position
                graphics.DrawText($"({bp.Position.X:0.##}, {bp.Position.Y:0.##}, {bp.Position.Z:0.##}), {HalfAxis.ToString(bp.DirectionLength)}, {HalfAxis.ToString(bp.DirectionWidth)}", FontSize);
            }
            return graphics.Bitmap;
        }

        public int GetPickedIndex(Point pt)
        {
            return BoxInteraction.SelectedPosition(Positions, DimCase, ReverseTransform(pt, DimCase, DimContainer));
        }

        public void MoveMax(HalfAxis.HAxis moveDir)
        {
            // sanity check
            if (!IsSelectionValid) return;
            // update position
            BoxPosition bpos = Positions[SelectedIndex];
            double distance = 0;
            if (BoxInteraction.MinDistance(Positions, DimCase, SelectedIndex, moveDir, ref distance))
            {
            }
            if (distance > 0)
                Positions[SelectedIndex] = bpos.Translate(moveDir, distance); ;
        }

        public void Move(HalfAxis.HAxis moveDir, double stepMove)
        {
            // sanity check
            if (!IsSelectionValid) return;
            // update position
            BoxPosition bpos = Positions[SelectedIndex];
            BoxPosition bposNew = bpos.Translate(moveDir, stepMove);
            if (!BoxInteraction.HaveIntersection(Positions, DimCase, SelectedIndex, bposNew)
                && BoxInteraction.BoxCanMoveInside(Positions[SelectedIndex], DimCase, PtMin, PtMax, moveDir))
                Positions[SelectedIndex] = bposNew;
            else
            {
                double distance = 0;
                if (BoxInteraction.MinDistance(Positions, DimCase, SelectedIndex, moveDir, ref distance))
                {
                    bposNew = bpos.Translate(moveDir, distance);
                    Positions[SelectedIndex] = bposNew;
                }
            }
        }
        public void Rotate()
        {
            if (!IsSelectionValid) return;
            Positions[SelectedIndex] = Positions[SelectedIndex].RotateZ90(DimCase); ;
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
                double max = double.MinValue;
                max = Math.Max(DimCase.X, max);
                max = Math.Max(DimCase.Y, max);
                max = Math.Max(DimCase.Z, max);
                return max;
            }
        }
        private bool IsSelectionValid => (SelectedIndex > -1) || (SelectedIndex < Positions.Count);
        #endregion

        #region Data members
        public List<BoxPosition> Positions { get; set; }
        public Size SizeImage { get; set; }
        public Vector3D DimCase { get; set; }
        public Vector2D DimContainer { get; set; }
        public int SelectedIndex { get; set; } = -1;
        public double FontSizeRatio { get; set; }
        public int FontSize => (int)(FontSizeRatio * SizeImage.Height);
        #endregion
    }
}
