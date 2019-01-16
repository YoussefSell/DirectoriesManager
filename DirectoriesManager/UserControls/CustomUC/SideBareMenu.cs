using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DirectoriesManager
{
    [DefaultEvent(nameof(OnMenuClicked))]
    public partial class SideBareMenu : UserControl
    {
        public event EventHandler<OnMenuClickedEventArgs> OnMenuClicked;

        public SideBareMenu()
        {
            InitializeComponent();
            Tools.InitializeToolTip(new Dictionary<Control, string>()
            {
                { PB_Dashboard, "Dashboard" },
                { PB_Search, "Search" },
                { PB_Compare, "Compare Folders" },
                {PB_Rename, "Rename Folders" }
            });
        }

        private void SideBareMenu_Click(object sender, EventArgs e)
        {
            var caller = (sender as Control).Name;

            if (caller == PB_Compare.Name)
            {
                ShowView(IsCompareView: true);
                OnMenuClicked?.Invoke(this, new OnMenuClickedEventArgs(MenuItemClicked.Compare));
            }
            else if (caller == PB_Search.Name)
            {
                ShowView(IsSearchView: true);
                OnMenuClicked?.Invoke(this, new OnMenuClickedEventArgs(MenuItemClicked.Search));
            }
            else if (caller == PB_Rename.Name)
            {
                ShowView(IsRenameView: true);
                OnMenuClicked?.Invoke(this, new OnMenuClickedEventArgs(MenuItemClicked.Rename));
            }
            else if (caller == PB_Dashboard.Name)
            {
                ShowView(IsDashView: true);
                OnMenuClicked?.Invoke(this, new OnMenuClickedEventArgs(MenuItemClicked.Dash));
            }

            void ShowView(
                bool IsCompareView = false,
                bool IsSearchView = false,
                bool IsRenameView = false,
                bool IsDashView = false)
            {
                PB_Search.BackColor = IsSearchView ? Color.DodgerBlue : Color.Transparent;
                PB_Compare.BackColor = IsCompareView ? Color.DodgerBlue : Color.Transparent;
                PB_Rename.BackColor = IsRenameView ? Color.DodgerBlue : Color.Transparent;
                PB_Dashboard.BackColor = IsDashView ? Color.DodgerBlue : Color.Transparent;
            }
        }
    }

    public enum MenuItemClicked
    {
        Dash,
        Search,
        Compare,
        Rename
    }

    public class OnMenuClickedEventArgs : EventArgs
    {
        public MenuItemClicked MenuItem { get; set; }

        public OnMenuClickedEventArgs(MenuItemClicked menuItem)
        {
            MenuItem = menuItem;
        }
    }
}
