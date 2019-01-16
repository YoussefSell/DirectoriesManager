using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Expand;
using System.Linq;
using System.Windows.Forms;

namespace DirectoriesManager
{
    public partial class RenameFoldersView : UserControl
    {
        RenameViewModel RenameViewModel;
        static RenameFoldersView _instant;

        /// <summary>
        /// get an instant of RenameFoldersView
        /// </summary>
        public static RenameFoldersView Instant
        {
            get
            {
                if (_instant is null)
                    _instant = new RenameFoldersView();

                return _instant;
            }
        }

        private RenameFoldersView()
        {
            InitializeComponent();
            InitializationBinding();
            InitializationContextMenu();
            InitializeToolTip();
        }

        #region Initialization

        /// <summary>
        /// Initialize the Rename ViewModel
        /// </summary>
        private void InitializationBinding()
        {
            RenameViewModel = new RenameViewModel();

            Cmb_Rn_Options.DisplayMember = "Name";
            Cmb_Rn_Options.ValueMember = "Value";

            if (Cmb_Rn_Options.Items.Count <= 0)
                Cmb_Rn_Options.DataSource = RenameOptionObj.GetRenameOptions();

            Txt_Rn_Srcdir.DataBindings.Add("Text", RenameViewModel, nameof(RenameViewModel.SourceFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            Txt_Rn_Filter.DataBindings.Add("Text", RenameViewModel, nameof(RenameViewModel.Filter), false, DataSourceUpdateMode.OnPropertyChanged, "");
            Lbl_Rn_totalFound.DataBindings.Add("Text", RenameViewModel, nameof(RenameViewModel.CountFound), false);
            Cmb_Rn_Options.DataBindings.Add("SelectedValue", RenameViewModel, nameof(RenameViewModel.RenameOptionsValue), false,DataSourceUpdateMode.OnPropertyChanged, "");
            txt_separator.DataBindings.Add("Text", RenameViewModel, nameof(RenameViewModel.Separator), false,DataSourceUpdateMode.OnPropertyChanged, "-");
            txt_startwith.DataBindings.Add("Value", RenameViewModel, nameof(RenameViewModel.Startwith), true,DataSourceUpdateMode.OnPropertyChanged, 1);
            txt_regexpattern.DataBindings.Add("Text", RenameViewModel, nameof(RenameViewModel.RegexPattern), false,DataSourceUpdateMode.OnPropertyChanged, "");
            txt_replacewith.DataBindings.Add("Text", RenameViewModel, nameof(RenameViewModel.ReplaceWith), false,DataSourceUpdateMode.OnPropertyChanged, "");

            txt_separator.DataBindings.Add("Enabled", RenameViewModel, nameof(RenameViewModel.SeparatorEnabled), false, DataSourceUpdateMode.OnPropertyChanged, "");
            txt_startwith.DataBindings.Add("Enabled", RenameViewModel, nameof(RenameViewModel.StartwithEnabled), true, DataSourceUpdateMode.OnPropertyChanged, 0);
            txt_regexpattern.DataBindings.Add("Enabled", RenameViewModel, nameof(RenameViewModel.RegexPatternEnabled), false, DataSourceUpdateMode.OnPropertyChanged, "");
            txt_replacewith.DataBindings.Add("Enabled", RenameViewModel, nameof(RenameViewModel.ReplaceWithEnabled), false, DataSourceUpdateMode.OnPropertyChanged, "");

            CB_Rn_filter_isRegix.DataBindings.Add("Checked", RenameViewModel, nameof(RenameViewModel.IsFilterRegex));

            LB_Rn_output.DataBindings.Add("DataSource", RenameViewModel, nameof(RenameViewModel.ListDirctoryFound), true);

            Btn_Rnm_Clear.Click += (s, e) => RenameViewModel.Clear.Execute(null);
            Btn_Rn_ClearOutput.Click += (s, e) => RenameViewModel.ClearOutput.Execute(null);
            btn_Rn_Search.Click += (s, e) => this.Execute(() => RenameViewModel.Search.Execute(null), $"{nameof(RenameFoldersView)} btn_Rn_Search.Click");
            Btn_Rn_Rename.Click += (s, e) => this.Execute(() => RenameViewModel.RenameAll.Execute(null), $"{nameof(RenameFoldersView)} btn_Rn_Search.Click");
            Btn_Rn_RenameSelected.Click += (s, e) => this.Execute(() =>
            {
                RenameViewModel.ListSelectedDirctories = LB_Rn_output.SelectedItems.Cast<DirectoryInfo>().ToList();
                RenameViewModel.RenameSelected.Execute(null);
            }, $"{nameof(RenameFoldersView)} btn_Rn_Search.Click");
            Btn_Regextester.Click += (s, e) => this.Execute(() => new RegexTesterFrm().ShowDialog(), $"{nameof(RenameFoldersView)} Btn_Regextester");
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
                    RenameViewModel.SourceFolder = ((DirectoryInfo)LB_Rn_output.SelectedItem).FullName;
                }));
                menu.MenuItems.Add(1, new MenuItem("Reveal in File Explorer", (s, e) =>
                {
                    ((DirectoryInfo)LB_Rn_output.SelectedItem).LaunchFolderView();
                }));

                LB_Rn_output.ContextMenu = menu;
            });
        }

        /// <summary>
        ///  Initialize the ToolTip
        /// </summary>
        private void InitializeToolTip()
        {
            Tools.InitializeToolTip(new Dictionary<Control, string>()
            {
                { Txt_Rn_Srcdir, "the directory where the search is performed"},
                { Txt_Rn_Filter, "the keyword to search with, if the Regex checkBox is checked then a Regex pattern is expected"},
                { CB_Rn_filter_isRegix, "check to activate regex search"},
                { Btn_Rnm_Clear, "clear the Source, Destination and Keyword TextBox "},
                { Btn_Rn_ClearOutput, "clear the results"},
                { Btn_Rn_Rename, "perform the rename to all directories"},
                { Btn_Rn_RenameSelected, "perform the rename to selected directories"},
                { btn_Rn_Search, "perform the search"},
                { Cmb_Rn_Options, "choose your rename option"},
                { txt_separator, "specify the separator used in renaming"},
                { txt_startwith, "specify the starting point when using incremented numbers"},
                { txt_replacewith, "specify the text the you will replace your pattern or directory name with"},
                { txt_regexpattern, "specify the regex pattern"},
                { Btn_Regextester, "open an Online regex tester"},
            });
        }

        #endregion

        #region Rename Form Events

        private void PB_Rn_Browse_Click(object sender, EventArgs e)
        {
            Txt_Rn_Srcdir.Text = Tools.SelectedPath();
        }

        private void LB_Rn_output_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var index = LB_Rn_output.IndexFromPoint(e.X, e.Y);
                LB_Rn_output.ClearSelected();
                LB_Rn_output.SelectedItem = LB_Rn_output.Items[index];
            }
        }

        #endregion
    }
}
