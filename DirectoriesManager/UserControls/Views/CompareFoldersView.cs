using System;
using System.IO;
using System.Linq;
using System.IO.Expand;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DirectoriesManager
{
    public partial class CompareFoldersView : UserControl
    {
        CompareViewModel CompareViewModel;
        static CompareFoldersView _instant;

        /// <summary>
        /// get an instant of CompareFoldersView
        /// </summary>
        public static CompareFoldersView Instant
        {
            get
            {
                if (_instant is null)
                    _instant = new CompareFoldersView();

                return _instant;
            }
        }

        private CompareFoldersView()
        {
            InitializeComponent();
            InitializeBinding();
            InitializationContextMenu();
            InitializeToolTip();
        }

        #region Initializations

        /// <summary>
        /// Initialize the Search ViewModel
        /// </summary>
        private void InitializeBinding()
        {
            CompareViewModel = new CompareViewModel();

            Txt_Cmp_src.DataBindings.Add("Text", CompareViewModel, nameof(CompareViewModel.SourceFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            Txt_cmp_FolderToCompare.DataBindings.Add("Text", CompareViewModel, nameof(CompareViewModel.CompareToFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            Txt_Cmp_Destination.DataBindings.Add("Text", CompareViewModel, nameof(CompareViewModel.DistFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            LblTotalCompareFound.DataBindings.Add("Text", CompareViewModel, nameof(CompareViewModel.CountFound), false);
            RD_Matching.DataBindings.Add("Checked", CompareViewModel, nameof(CompareViewModel.Matching));

            COB.DataBindings.Add("SelectedCompareOption", CompareViewModel, nameof(CompareViewModel.CompareOptions));

            LB_outputCompare.DataBindings.Add("DataSource", CompareViewModel, nameof(CompareViewModel.ListDirctoryFound), true);

            Btn_Compare.Click += (s, e) => this.Execute(() => CompareViewModel.Compare.Execute(null), "Btn_Compare.Click");
            Btn_Cmp_MoveAll.Click += (s, e) => this.Execute(() => CompareViewModel.MoveAll.Execute(null), "Btn_Compare.Click");
            Btn_copyAll.Click += (s, e) => this.Execute(() => CompareViewModel.CopyAll.Execute(null), "Btn_copyAll.Click");
            Btn_Cmp_MoveSelected.Click += (s, e) => this.Execute(() =>
            {
                CompareViewModel.ListSelectedDirctories = LB_outputCompare.SelectedItems.Cast<DirectoryInfo>().ToList();
                CompareViewModel.MoveSelected.Execute(null);
            }, "Btn_Cmp_MoveSelected.Click");
            Btn_CopySelected.Click += (s, e) => this.Execute(() =>
            {
                CompareViewModel.ListSelectedDirctories = LB_outputCompare.SelectedItems.Cast<DirectoryInfo>().ToList();
                CompareViewModel.CopySelected.Execute(null);
            }, "Btn_CopySelected.Click");

            Btn_Clear_Cmp.Click += (s, e) => CompareViewModel.Clear.Execute(null);
            Btn_Cmp_Clearoutput.Click += (s, e) => CompareViewModel.ClearOutput.Execute(null);
        }

        /// <summary>
        /// Initialize ContextMenu
        /// </summary>
        private void InitializationContextMenu()
        {
            this.Execute(() =>
            {
                var menu = new ContextMenu();

                menu.MenuItems.Add(0, new MenuItem("Select as Source Folder", (s, e) =>
                {
                    CompareViewModel.SourceFolder = ((DirectoryInfo)LB_outputCompare.SelectedItem).FullName;
                }));
                menu.MenuItems.Add(1, new MenuItem("Select as Folder To compare", (s, e) =>
                {
                    CompareViewModel.CompareToFolder = ((DirectoryInfo)LB_outputCompare.SelectedItem).FullName;
                }));
                menu.MenuItems.Add(1, new MenuItem("Select as Destination Folder", (s, e) =>
                {
                    CompareViewModel.DistFolder = ((DirectoryInfo)LB_outputCompare.SelectedItem).FullName;
                }));
                menu.MenuItems.Add(1, new MenuItem("Reveal in File Explorer", (s, e) =>
                {
                    ((DirectoryInfo)LB_outputCompare.SelectedItem).LaunchFolderView();
                }));

                LB_outputCompare.ContextMenu = menu;
            });
        }

        /// <summary>
        /// Initialize the ToolTip
        /// </summary>
        private void InitializeToolTip()
        {
            Tools.InitializeToolTip(new Dictionary<Control, string>() {
                { Txt_Cmp_src, "the primary directory for comparison"},
                { Txt_Cmp_Destination, "the destination directory for the Move and Copy actions"},
                { Txt_cmp_FolderToCompare, "the directory that you will Compare the primary directory with"},
                { COB, "choose the compare option"},
                { OutputOptions, "choose the output option"},
                { RD_Matching, "show the matching result between the two directories"},
                { RD_NonMatching, "show results that exist in the primary directory but don't exist in Folder To Compare"},

                { Btn_Reverse_Cmp, "Reverse the path in the 'Source Folder' and 'Folder To Compare'"},
                { Btn_Compare, "start the comparison"},
                { Btn_Clear_Cmp, "clear the 'Source Folder' and 'Folder To Compare'"},
                { Btn_Cmp_Clearoutput, "clear the results"},
                { Btn_CopySelected, "Copy Selected directories to the destination directory"},
                { Btn_Cmp_MoveSelected, "Move Selected directories to the destination directory"},
                { Btn_copyAll, "copy all directories to the destination directory"},
                { Btn_Cmp_MoveAll, "Move all directories to the destination directory"},
            });
        }

        #endregion

        #region Compare Form Events

        private void Btn_Reverse_Cmp_Click(object sender, EventArgs e)
        {
            var temp = Txt_cmp_FolderToCompare.Text;
            Txt_cmp_FolderToCompare.Text = Txt_Cmp_src.Text;
            Txt_Cmp_src.Text = temp;
        }

        private void PB_Browes_Click(object sender, EventArgs e)
        {
            var caller = ((Control)sender).Name;

            if (caller == PB_Browes_Src_Cmp.Name)
                Txt_Cmp_src.Text = Tools.SelectedPath();
            else if (caller == PB_Browes_FolderToCompaire.Name)
                Txt_cmp_FolderToCompare.Text = Tools.SelectedPath();
            else if (caller == PB_Browse_Destination.Name)
                Txt_Cmp_Destination.Text = Tools.SelectedPath();
        }

        private void RD_NonMatching_CheckedChanged(object sender, EventArgs e)
        {
            if (RD_NonMatching.Checked)
                CompareViewModel.Matching = false;
            else
                CompareViewModel.Matching = true;
        }

        private void LB_outputCompare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var index = LB_outputCompare.IndexFromPoint(e.X, e.Y);
                LB_outputCompare.ClearSelected();
                LB_outputCompare.SelectedItem = LB_outputCompare.Items[index];
            }
        }

        #endregion
    }
}
