using System;
using System.Windows.Forms;

namespace DirectoriesManager
{
    public partial class RegexTesterFrm : Form
    {
        string OnlineRegexTesterWebsite = @"http://regexstorm.net/tester";

        public RegexTesterFrm()
        {
            InitializeComponent();
        }

        private void RegexTesterFrm_Load(object sender, EventArgs e)
        {
            webBrowser1.AllowNavigation = false;
            webBrowser1.Navigate(OnlineRegexTesterWebsite);
        }
    }
}
