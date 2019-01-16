namespace DirectoriesManager
{
    using System.Windows.Forms;

    public partial class Main : Form
    {
        public CompareFoldersView CompareFoldersView = CompareFoldersView.Instant;
        public RenameFoldersView RenameFoldersView = RenameFoldersView.Instant;
        public SearchFoldersView SearchFoldersView = SearchFoldersView.Instant;
        public DashBoardView DashBoardView = DashBoardView.Instant;

        public Main()
        {
            InitializeComponent();
            Pnl_Container.Add(DashBoardView);
        }

        private void OnMenuClicked(object sender, OnMenuClickedEventArgs e)
        {
            if (e.MenuItem == MenuItemClicked.Dash) Pnl_Container.Add(DashBoardView);
            else if (e.MenuItem == MenuItemClicked.Search) Pnl_Container.Add(SearchFoldersView);
            else if (e.MenuItem == MenuItemClicked.Compare) Pnl_Container.Add(CompareFoldersView);
            else if (e.MenuItem == MenuItemClicked.Rename) Pnl_Container.Add(RenameFoldersView);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DashBoardView.RemoveGeneratedDirectories();
        }
    }
}
