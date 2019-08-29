#region Using directives
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

using log4net;
using System.ComponentModel;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public partial class Graphics2DLayerEditor : UserControl
    {
        #region Constructor
        public Graphics2DLayerEditor()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public Vector2D PtMin { get; set; }
        public Vector2D PtMax { get; set; }
        #endregion

        #region UserControl overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                Graphics = new Graphics2DForm(this, e.Graphics);
                Graphics.SetViewport((float)PtMin.X, (float)PtMin.Y, (float)PtMax.X, (float)PtMax.Y);

                BoxProperties boxProperties = Content as BoxProperties;
                uint pickId = 0;
                foreach (var bp in Positions)
                {
                    Box b = new Box(pickId++, boxProperties, bp);
                    Graphics.DrawBox(b);
                }
                Graphics.DrawRectangle(PtMin, PtMax, Color.Red);

                if (-1 != SelectedIndex)
                {
                    Box boxSelected = new Box((uint)SelectedIndex, boxProperties, Positions[SelectedIndex]);
                    Graphics.DrawBoxSelected(boxSelected);

                    ArrowButtons.Clear();
                    Vector2D ptCenter = new Vector2D(boxSelected.Center.X, boxSelected.Center.Y);

                    for (int i = 0; i < 4; ++i)
                    {
                        if (Arrows[i])
                        {
                            Graphics.DrawArrow(ptCenter, i, 100, 5, 10, Color.Red, out Rectangle rect);
                            ArrowButtons.Add(i, rect);
                        }
                    }

                    if (ArrowRotate)
                        Graphics.DrawArcArrow(ptCenter, 50, 10, Color.Red, out Rectangle rectRotation);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Event handlers
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            foreach (var item in ArrowButtons)
            {
                if (item.Value.Contains(e.Location))
                {
                    StartMove(item.Key);
                    break;
                }
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (Moving)
            {
                EndMove();
                Moving = false;
            }
            else
            {
                Vector2D pt = Graphics.ReverseTransform(e.Location);
                BoxProperties boxProperties = Content as BoxProperties;
                // selected index
                SelectedIndex = BoxInteraction.SelectedPosition(Positions, boxProperties.OuterDimensions, pt);
            }

            UpdateArrows();
            Invalidate();
        }
        #endregion
        #region Moving items
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (-1 == SelectedIndex) return;
            BoxPosition bpos = Positions[SelectedIndex];
            BoxPosition bposNew = bpos.Translate(MoveDir, StepMove);
            if (!BoxInteraction.HaveIntersection(Positions, Dimensions, SelectedIndex, bposNew))
                Positions[SelectedIndex] = bposNew;
            else
            {
                double distance = 0;
                if (BoxInteraction.MinDistance(Positions, Dimensions, SelectedIndex, MoveDir, ref distance))
                {
                    bposNew = bpos.Translate(MoveDir, distance);
                    Positions[SelectedIndex] = bposNew;
                }
                EndMove();
            }

            CountMove++;

            UpdateArrows();
            Invalidate();
        }

        private void StartMove(int dir)
        {
            CountMove = 0;
            if (dir < 0 || dir > 3) return;
            MoveDir = Directions[dir];
            timerMove.Start();
            Moving = true;
        }
        private void EndMove()
        {
            timerMove.Stop();
        }
        private double StepMove
        {
            get
            {
                if (CountMove < 3) return 0.1;
                else if (CountMove < 10) return 1.0;
                else if (CountMove < 20) return 10.0;
                else return 30.0;
            }
        }
        private int CountMove { get; set; }
        #endregion

        #region Distances
        private void UpdateArrows()
        {
            Vector3D dim = Dimensions;
            Arrows = Enumerable.Repeat(false, 4).ToArray();
            for (int i = 0; i < 4; ++i)
            {
                double distance = 0.0;
                if (!BoxInteraction.MinDistance(Positions, dim, SelectedIndex, Directions[i], ref distance) || distance > 0.1)
                    Arrows[i] = true;
            }
        }
        #endregion
        #region Helpers
        private Vector3D Dimensions
        {
            get
            {
                if (Content is BoxProperties boxProperties)
                    return boxProperties.OuterDimensions;
                else
                    return Vector3D.Zero;
            }
        }
        #endregion
        #region Data members
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Packable Content { get; set; }
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private Graphics2D Graphics { get; set; } 

        public List<BoxPosition> Positions { get; set; }
        private int SelectedIndex { get; set; } = -1;
        private HalfAxis.HAxis MoveDir { get; set; }
        private readonly HalfAxis.HAxis[] Directions = { HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N, HalfAxis.HAxis.AXIS_Y_N };
        private bool[] Arrows = { false, false, false, false};
        private bool ArrowRotate = false;
        private bool Moving { get; set; } = false;
        private Dictionary<int, Rectangle> ArrowButtons { get; set; } = new Dictionary<int, Rectangle>();
        private static readonly ILog _log = LogManager.GetLogger(typeof(Graphics2DLayerEditor));
        #endregion


    }
}
