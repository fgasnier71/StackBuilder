#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.TestLayerEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var bProperties = new BoxProperties(null, 400.0, 300.0, 200.0);
            bProperties.SetAllColors(Enumerable.Repeat<Color>(Color.Beige, 6).ToArray());
            bProperties.TapeColor = Color.Orange;
            bProperties.TapeWidth = new treeDiM.Basics.OptDouble(true, 50.0);
            Content = bProperties;

            BoxPositions.Add(new BoxPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            BoxPositions.Add(new BoxPosition(new Vector3D(400.0, 0.0, 0.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            BoxPositions.Add(new BoxPosition(new Vector3D(1100.0, 0.0, 0.0), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N));
            BoxPositions.Add(new BoxPosition(new Vector3D(300.0, 300.0, 0.0), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N));
            BoxPositions.Add(new BoxPosition(new Vector3D(700.0, 300.0, 0.0), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N));
            BoxPositions.Add(new BoxPosition(new Vector3D(700.0, 400.0, 0.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));

            layerEditor.PtMin = new Vector2D(-400.0, -400.0);
            layerEditor.PtMax = new Vector2D(1500.0, 1400.0);
            layerEditor.Content = Content;
            layerEditor.Positions = BoxPositions;
            layerEditor.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            layerEditor.Invalidate();
        }

        public List<BoxPosition> BoxPositions { get; set; } = new List<BoxPosition>();
        public BoxProperties Content { get; set; }
    }
}
