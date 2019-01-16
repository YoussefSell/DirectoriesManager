using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Expand;

namespace DirectoriesManager
{
    public partial class CompareOptionsControl : UserControl, INotifyPropertyChanged
    {
        private CompareOptions _compareOptions;

        public CompareOptions SelectedCompareOption
        {
            get { return _compareOptions; }
            set
            {
                _compareOptions = value;
                SetRadioButton();
                OnPropertyChanged();
            }
        }

        private void SetRadioButton()
        {
            switch (_compareOptions)
            {
                case CompareOptions.Default:
                case CompareOptions.Name: RadioName.Checked = true;
                    break;
                case CompareOptions.FullName: RD_fullName.Checked = true;
                    break;
                case CompareOptions.DateOfCreation: RD_DateCreation.Checked = true;
                    break;
                case CompareOptions.Size: RD_TotalSize.Checked = true;
                    break;
            }
        }

        public CompareOptionsControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RadioName_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioName.Checked)
            {
                _compareOptions = CompareOptions.Name;
                OnPropertyChanged();
            }
        }

        private void RD_fullName_CheckedChanged(object sender, EventArgs e)
        {
            if (RD_fullName.Checked)
            {
                _compareOptions = CompareOptions.FullName;
                OnPropertyChanged();
            }
        }

        private void RD_DateCreation_CheckedChanged(object sender, EventArgs e)
        {
            if (RD_DateCreation.Checked)
            {
                _compareOptions = CompareOptions.DateOfCreation;
                OnPropertyChanged();
            }
        }

        private void RD_TotalSize_CheckedChanged(object sender, EventArgs e)
        {
            if (RD_TotalSize.Checked)
            {
                _compareOptions = CompareOptions.Size;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCompareOption)));
        }
    }
}
