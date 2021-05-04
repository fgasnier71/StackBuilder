#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public partial class Graphics2DRobotDropEditor : UserControl, IStateHost
    {
        #region Constructor
        public Graphics2DRobotDropEditor()
        {
            InitializeComponent();

            // double buffering
            SetDoubleBuffered();
            SetStyle(ControlStyles.Selectable, true);
            TabStop = true;

            // set default state
            SetDefaultState();
        }
        #endregion
        #region Double buffering
        private void SetDoubleBuffered()
        {
            System.Reflection.PropertyInfo aProp =
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            aProp.SetValue(this, true, null);
        }
        #endregion
        #region UserControl overrides (Drawing)
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                Graphics = new Graphics2DForm(this, e.Graphics);
                if (null == Layer) return;
                Vector2D margin = new Vector2D(200.0, 200.0);
                Graphics.SetViewport(Layer.MinPoint - margin, Layer.MaxPoint + margin);
                // draw layer boundary rectangle
                Graphics.DrawRectangle(Layer.MinPoint, Layer.MaxPoint, Color.OrangeRed);
                // draw all drops
                foreach (var drop in Layer.Drops)
                    DrawDrop(drop, CurrentState.ShowIDs, CurrentState.ShowSelected(drop), CurrentState.ShowAllowed(drop));
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void DrawDrop(RobotDrop drop, bool showID, bool selected, bool showAllowed)
        {
            // draw case(s)
            for (int index = 0; index < drop.Number; ++index)
            {
                Box b;
                if (drop.Content is PackProperties pack)
                    b = new Pack(0, pack, drop.InnerBoxPosition(index));
                else
                    b = new Box(0, drop.Content, drop.InnerBoxPosition(index));
                b.Draw(Graphics);
            }
            // draw drop boundary
            Graphics.DrawContour(drop.Contour, Color.Red);

            // draw 
            if (showID && drop.ID >= 0)
                Graphics.DrawText($"{drop.ID}", FontSizeID, new Vector2D(drop.Center.X, drop.Center.Y));
        }
        #endregion
        #region Mouse event handlers
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            OnStateMouseDown(ClickToIndex(e.Location));
            Invalidate();
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            OnStateMouseUp(ClickToIndex(e.Location));
            Invalidate();
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                SetDefaultState();
            else
                OnStateKeyPress(e.KeyChar);
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        #endregion
        #region Toolbar event handlers
        private void OnBuildCaseDropOf2(object sender, EventArgs e) => SetState(new StateBuildBlock(this, 2));
        private void OnBuildCaseDropOf3(object sender, EventArgs e) => SetState(new StateBuildBlock(this, 3));
        private void OnSplitDrop(object sender, EventArgs e) => SetState(new StateSplitDrop(this));
        private void OnReorder(object sender, EventArgs e) => SetState(new StateReoder(this));
        private void UpdateToolBar()
        {
            toolStripBnCaseDrop2.Enabled = !StateLoaded;
            toolStripBnCaseDrop3.Enabled = !StateLoaded;
            toolStripBnSplitDrop.Enabled = !StateLoaded;
            toolStripBnReorder.Enabled = !StateLoaded;
        }
        #endregion
        #region IStateHost implementation
        public void SetState(State state)
        {
            CurrentState = state;
            state.Host = this;
            UpdateToolBar();
        }
        public void ExitState() { CurrentState = null; UpdateToolBar(); }
        private State CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                _currentState.Host = this;
                Invalidate();
                UpdateToolBar();
            } 
        }
        public bool StateLoaded => !(CurrentState is StateDefault);

        public void OnStateMouseUp(int id) => CurrentState?.OnMouseUp(id);
        public void OnStateMouseDown(int id) => CurrentState?.OnMouseDown(id);
        public void OnStateKeyPress(char c) => CurrentState?.OnKey(c);
        public void SetDefaultState() { CurrentState = new StateDefault(this); }
        #endregion
        #region Helpers
        public Rectangle DropToRectangle(RobotDrop rd)
        {
            Vector3D[] cornerPoints = new Vector3D[8];
            for (int i = 0; i < 8; ++i)
                cornerPoints[i] = rd.CornerPoints[i] + new Vector3D(0.0, 200.0, 0.0);
            Point[] pts = Graphics.TransformPoint(cornerPoints);
            int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;
            foreach (var pt in pts)
            {
                minX = Math.Min(minX, pt.X);
                maxX = Math.Max(maxX, pt.X);
                minY = Math.Min(minY, pt.Y);
                maxY = Math.Max(maxY, pt.Y);                
            }
            return new Rectangle(minX, maxY, maxX - minX, maxY - minY);
        }
        public int ClickToIndex(Point pt)
        {
            int index = 0;
            foreach (var rd in Layer.Drops)
            {
                Rectangle rect = DropToRectangle(rd);
                if (rect.Contains(pt)) return index;
                ++index;
            }
            return -1;
        }
        #endregion
        #region Data members
        public RobotLayer Layer { get; set; }
        private Graphics2D Graphics { get; set; }
        private int FontSizeID => 16;
        protected ILog _log = LogManager.GetLogger(typeof(Graphics2DRobotDropEditor));
        private State _currentState;
        #endregion
    }

    #region State
    public interface IStateHost
    {
        void SetState(State state);
        void ExitState();
        void SetDefaultState();
        void Invalidate();
        RobotLayer Layer { get; }
    }
    public abstract class State
    {
        public virtual void OnMouseDown(int id) {}
        public virtual void OnMouseUp(int id) {}
        public virtual void OnKey(char c) {}
        protected void ExitState() { Host.SetDefaultState(); }
        public virtual bool ShowIDs { get; } = false;
        public virtual bool ShowSelected(RobotDrop drop) => false;
        public virtual bool ShowAllowed(RobotDrop drop) => false;
        public IStateHost Host { get; set; }
    }
    internal class StateDefault : State
    {
        public StateDefault(IStateHost host) { Host = host; }
        public override bool ShowIDs => true;
    }
    internal class StateBuildBlock : State
    {
        public StateBuildBlock(IStateHost host, int number)
        {
            Host = host;
            Number = number;
            IndexArray = new int[number];            
        }
        private int Number { get; set; }
        private int ClickCount { get; set; }
        public override void OnMouseUp(int index)
        {
            if (-1 == index) return;
            IndexArray[ClickCount] = index;
            ClickCount += 1;
            if (ClickCount == Number)
            {
                Merge();
                Reset();
            }
        }
        private void Merge()
        {
            Host.Layer.Merge(Number, IndexArray);
        }
        private void Reset()
        {
            ClickCount = 0;
            for (int i = 0; i < Number; ++i) IndexArray[i] = -1;
        }
        private int[] IndexArray;
    }

    internal class StateSplitDrop : State
    {
        public StateSplitDrop(IStateHost host) { Host = host; }
    }

    internal class StateReoder : State
    {
        public StateReoder(IStateHost host)
        {
            Host = host;
            Host.Layer.ResetNumbering();
            Host.Invalidate();
        }
        public override void OnMouseUp(int index)
        {
            // not a valid click!
            if (index == -1)
                return;
            // check if ID already set
            if (-1 == Host.Layer.Drops[index].ID)
                Host.Layer.Drops[index].ID = ID++;
            // check if layer is completely numbered
            if (Host.Layer.IsFullyNumbered)
            {
                Host.Layer.CompleteNumbering(Vector3D.Zero);
                ExitState();
            }
            Host.Invalidate();
        }
        public override bool ShowIDs => true;

        private int ID { get; set; } = 0;
    }
    #endregion
}
