#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace ListBoxWithToolTip
{
    /// <summary>
    /// Interface for objects used in ToolTipListBox.
    /// </summary>
    internal interface IToolTipDisplayer
    {
        string GetToolTipText();
    }
    /// <summary>
    /// ListBox that displays item-specific tooltips.
    /// </summary>
    internal partial class ToolTipListBox : ListBox
    {

        public ToolTipListBox()
        {
            InitializeComponent();

            MouseMove += OnMouseMove;
            MouseLeave += OnMouseLeave;
            
            _currentItemSet = false;
            _toolTipDisplayed = false;
            _toolTipDisplayTimer = new Timer();
            _toolTip = new ToolTip();

            // Set the timer interval to the system time that it takes for a tooltip to appear
            _toolTipDisplayTimer.Interval = SystemInformation.MouseHoverTime;
            _toolTipDisplayTimer.Tick += OnToolTipDisplayTimerTick;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // Get the item that the mouse is currently over
            Point cursorPoint = Cursor.Position;
            cursorPoint = PointToClient(cursorPoint);
            int itemIndex = IndexFromPoint(cursorPoint);

            if (itemIndex == NoMatches)
            {
                // Mouse is over empty space in the listbox so hide tooltip
                _toolTip.Hide(this);
                _currentItemSet = false;
                _toolTipDisplayed = false;
                _toolTipDisplayTimer.Stop();
            }
            else if (!_currentItemSet)
            {
                // Mouse is over a new item so start timer to display tooltip
                _currentItem = itemIndex;
                _currentItemSet = true;
                _toolTipDisplayTimer.Start();
            }
            else if (itemIndex != _currentItem)
            {
                // Mouse is over a different item so hide tooltip and restart timer
                _currentItem = itemIndex;
                _toolTipDisplayTimer.Stop();
                _toolTipDisplayTimer.Start();
                _toolTip.Hide(this);
                _toolTipDisplayed = false;
            }
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            // Mouse has left listbox so stop timer (tooltip is automatically hidden)
            _currentItemSet = false;
            _toolTipDisplayed = false;
            _toolTipDisplayTimer.Stop();
        }
        private void OnToolTipDisplayTimerTick(object sender, EventArgs e)
        {
            // Display tooltip text since the mouse has hovered over an item
            if (!_toolTipDisplayed && _currentItem != NoMatches && _currentItem < Items.Count)
            {
                if (Items[_currentItem] is IToolTipDisplayer toolTipDisplayer)
                {
                    _toolTip.SetToolTip(this, toolTipDisplayer.GetToolTipText());
                    _toolTipDisplayed = true;
                }
            }
        }
        private int _currentItem;
        private bool _currentItemSet;
        private bool _toolTipDisplayed;
        private Timer _toolTipDisplayTimer;
        private ToolTip _toolTip;
    }
}
