using System;
using System.Windows.Forms;

namespace DirectoriesManager
{
    public partial class DashBoardView : UserControl
    {
        DashViewModel DashViewModel;
        static DashBoardView _instant;

        /// <summary>
        /// get an instant of SearchFoldersView
        /// </summary>
        public static DashBoardView Instant
        {
            get
            {
                if (_instant is null)
                    _instant = new DashBoardView();

                return _instant;
            }
        }

        private DashBoardView()
        {
            InitializeComponent();
            InitializeBinding();
        }

        private void InitializeBinding()
        {
            DashViewModel = new DashViewModel();

            TxtSrc.DataBindings.Add("Text", DashViewModel, nameof(DashViewModel.SourceFolder), false, DataSourceUpdateMode.OnPropertyChanged, "");
            Lbl_TotalFiles.DataBindings.Add("Text", DashViewModel, nameof(DashViewModel.TotalFiles));
            lbl_TotalSubDir.DataBindings.Add("Text", DashViewModel, nameof(DashViewModel.TotalSubDirs));
            lbl_TotalSize.DataBindings.Add("Text", DashViewModel, nameof(DashViewModel.TotalSize));
            lbl_LstAcsTime.DataBindings.Add("Text", DashViewModel, nameof(DashViewModel.LastAccessTime));

            Btn_GenerateTestFolder.Click += (s, e) => this.Execute(() => DashViewModel.GenerateTestFolder.Execute(null));
            Btn_clear.Click += (s, e) => this.Execute(() => DashViewModel.Clear.Execute(null));
            Btn_Select.Click += (s, e) => this.Execute(() => DashViewModel.Select.Execute(null));
        }

        private void PB_Browse_Click(object sender, EventArgs e)
        {
            var caller = (sender as Control).Name;

            if (caller == PB_BrowseSrcFolder.Name)
                TxtSrc.Text = Tools.SelectedPath();
        }

        public void RemoveGeneratedDirectories()
        {
            try
            {
                DashViewModel.RemoveGeneratedTestFolder.Execute(null);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, try to delete the test folder");
            }
        }
    }
}
