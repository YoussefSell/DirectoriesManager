using System;
using System.IO;
using System.Linq;
using System.IO.Expand;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DirectoriesManager
{
    public partial class SearchFoldersView : UserControl
    {
        SearchViewModel SearchViewModel;
        static SearchFoldersView _instant;

        /// <summary>
        /// get an instant of SearchFoldersView
        /// </summary>
        public static SearchFoldersView Instant
        {
            get
            {
                if (_instant is null)
                    _instant = new SearchFoldersView();

                return _instant;
            }
        }

        /// <summary>
        /// the constructor
        /// </summary>
        private SearchFoldersView()
        {
            InitializeComponent();
            InitializeBinding();
            InitializeContextMenu();
            InitializeToolTip();
        }

        #region Initialization

        /// <summary>
        ///  Initialize the ToolTip
        /// </summary>
        private void InitializeToolTip()
        {
            Tools.InitializeToolTip(new Dictionary<Control, string>()
            {
                { TxtSrc, "the directory where the search is performed"},
                { TxtDist, "the destination directory for the Move and Copy actions"},
                { TxtKeyword, "the keyword to search with, if the Regex checkBox is checked then a Regex pattern is expected"},
                { CbRegx, "check to activate regex search"},
                { BtnClear, "clear the Source, Destination and Keyword TextBox "},
                { Btn_Reverse, "reverse the paths in the Source and Destination TextBox"},
                { Btn_Search, "perform the search"},
                { BtnClearAll, "clear the results"},
                { BtnMoveAll, "Move all directories to the destination directory"},
                { BtnCopyAll, "copy all directories to the destination directory"},
                { BtnMoveSelected, "Move Selected directories to the destination directory"},
                { BtnCopySelected, "Copy Selected directories to the destination directory"},
            });
        }

        /// <summary>
        /// Initialize the context Menus
        /// </summary>
        private void InitializeContextMenu()
        {
            try
            {
                var menu = new ContextMenu();
                menu.MenuItems.Add(0, new MenuItem("Select as Source Folder", (s, e) =>
                {
                    TxtSrc.Text = ((DirectoryInfo)DirsFound.SelectedItem).FullName;
                }));
                menu.MenuItems.Add(1, new MenuItem("Select as Destination Folder", (s, e) =>
                {
                    TxtDist.Text = ((DirectoryInfo)DirsFound.SelectedItem).FullName;
                }));
                menu.MenuItems.Add(1, new MenuItem("Reveal in File Explorer", (s, e) =>
                {
                    ((DirectoryInfo)DirsFound.SelectedItem).LaunchFolderView();
                }));
                DirsFound.ContextMenu = menu;
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("the selected directory path is to long to be processed");
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("we need administrator rights to access the selected directory");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("the selected directory not exist");
            }
            catch (UnknownOperatingSystemException)
            {
                MessageBox.Show("cannot perform this action on unknown operation system");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                Tools.LogError(ex, nameof(SearchFoldersView));
            }
        }

        /// <summary>
        /// Initialize the Search ViewModel
        /// </summary>
        private void InitializeBinding()
        {
            //DirsFound.ValueMember = "FullName";
            //DirsFound.DisplayMember = "Name";

            SearchViewModel = new SearchViewModel();

            TxtDist.DataBindings.Add("Text", SearchViewModel, nameof(SearchViewModel.DistFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            TxtSrc.DataBindings.Add("Text", SearchViewModel, nameof(SearchViewModel.SourceFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            TxtKeyword.DataBindings.Add("Text", SearchViewModel, nameof(SearchViewModel.SearchKey), false, DataSourceUpdateMode.OnPropertyChanged, "");
            LblTotalFound.DataBindings.Add("Text", SearchViewModel, nameof(SearchViewModel.CountFound), false);
            LblMovedCount.DataBindings.Add("Text", SearchViewModel, nameof(SearchViewModel.Message), false);
            CbRegx.DataBindings.Add("Checked", SearchViewModel, nameof(SearchViewModel.IsRegex));

            DirsFound.DataBindings.Add("DataSource", SearchViewModel, nameof(SearchViewModel.ListDirctoryFound), true);

            Btn_Search.Click += (s, e) => this.Execute(() => SearchViewModel.Search.Execute(null), "Btn_Search.Click");
            BtnMoveAll.Click += (s, e) => this.Execute(() => SearchViewModel.MoveAll.Execute(null), "BtnMoveAll.Click");
            BtnCopyAll.Click += (s, e) => this.Execute(() => SearchViewModel.CopyAll.Execute(null), "BtnCopyAll.Click");
            BtnMoveSelected.Click += (s, e) => this.Execute(() =>
            {
                SearchViewModel.ListSelectedDirctories = DirsFound.SelectedItems.Cast<DirectoryInfo>().ToList();
                SearchViewModel.MoveSelected.Execute(null);
            }, "BtnMove.Click");
            BtnCopySelected.Click += (s, e) => this.Execute(() =>
            {
                SearchViewModel.ListSelectedDirctories = DirsFound.SelectedItems.Cast<DirectoryInfo>().ToList();
                SearchViewModel.CopySelected.Execute(null);
            }, "BtnCopySelected.Click");

            BtnClear.Click += (s, e) => SearchViewModel.Clear.Execute(null);
            BtnClearAll.Click += (s, e) => SearchViewModel.ClearOutput.Execute(null);
        }

        #endregion

        #region Search Form Events

        private void PB_Browse_Click(object sender, EventArgs e)
        {
            var caller = (sender as Control).Name;

            if (caller == PB_BrowseSrcFolder.Name)
                TxtSrc.Text = Tools.SelectedPath();
            else if (caller == PB_BrowseDistFolder.Name)
                TxtDist.Text = Tools.SelectedPath();
        }

        private void Btn_Reverse_Click(object sender, EventArgs e)
        {
            var temp = TxtDist.Text;
            TxtDist.Text = TxtSrc.Text;
            TxtSrc.Text = temp;
        }

        private void DirsFound_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var index = DirsFound.IndexFromPoint(e.X, e.Y);
                DirsFound.ClearSelected();
                DirsFound.SelectedItem = DirsFound.Items[index];
            }
        }

        #endregion
    }
}
