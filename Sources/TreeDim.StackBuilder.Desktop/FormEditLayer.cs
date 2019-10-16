#region Using directives
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormEditLayer : Form
    {
        public FormEditLayer(Layer2DEditable layer, Packable content)
        {
            InitializeComponent();

            Layer = layer;
            Content = content as BoxProperties;
            uCtrlLayerEditor.Content = Content;
            uCtrlLayerEditor.Layer = Layer;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            uCtrlLayerEditor.Content = Content;
            uCtrlLayerEditor.Layer = Layer;
            uCtrlLayerEditor.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            uCtrlLayerEditor.Invalidate();
        }

        public Layer2DEditable Layer { get; set; }
        public BoxProperties Content { get; set; }

        private void OnSaveEnabled(bool enable)
        {
            bnOK.Enabled = enable;
        }
    }
}
