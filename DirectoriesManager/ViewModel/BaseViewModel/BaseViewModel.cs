using System.IO.Expand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DirectoriesManager
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region protected fields

        protected string _sourceFolder;
        protected string _distFolder;
        protected IEnumerable<DirectoryInfo> _listDirctoryFound;
        protected IEnumerable<DirectoryInfo> _listSelectedDirctories;
        protected int _countFound;
        protected int _countSelected;
        private string _message = "Total Moved : 0";

        #endregion

        #region Public Props

        public string DistFolder
        {
            get => _distFolder;
            set
            {
                _distFolder = value;
                OnPropertyChanged(this, nameof(DistFolder));
            }
        }
        public string SourceFolder
        {
            get => _sourceFolder;
            set
            {
                _sourceFolder = value;
                ListDirctoryFound = new List<DirectoryInfo>();
                ListSelectedDirctories = new List<DirectoryInfo>();
                OnPropertyChanged(this);
            }
        }
        public IEnumerable<DirectoryInfo> ListDirctoryFound
        {
            get => _listDirctoryFound;
            set
            {
                _listDirctoryFound = value;
                CountFound = value?.Count() ?? 0;
                Message = $"Total Moved  : 0";
                OnPropertyChanged(this, nameof(ListDirctoryFound));
            }
        }
        public IEnumerable<DirectoryInfo> ListSelectedDirctories
        {
            get => _listSelectedDirctories;
            set
            {
                _listSelectedDirctories = value;
                CountSelected = value?.Count() ?? 0;
                OnPropertyChanged(this, nameof(ListSelectedDirctories));
            }
        }
        public int CountFound
        {
            get => _countFound;
            set
            {
                _countFound = value;
                OnPropertyChanged(this, nameof(CountFound));
            }
        }
        public int CountSelected
        {
            get => _countSelected;
            set
            {
                _countSelected = value;
                OnPropertyChanged(this, nameof(CountSelected));
            }
        }
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(this, nameof(Message));
            }
        }

        #endregion

        #region Commands

        public RelayCommand MoveSelected;
        public RelayCommand MoveAll;
        public RelayCommand CopySelected;
        public RelayCommand CopyAll;
        public RelayCommand Clear;
        public RelayCommand ClearOutput;

        #endregion

        public BaseViewModel()
        {
            string DesktopPath = DirectoryManager.GetDesktopPath();
            SourceFolder = DesktopPath;
            DistFolder = DesktopPath;

            MoveSelected = new RelayCommand(() =>
            {
                if (ListSelectedDirctories is null || _countSelected <= 0)
                    throw new ArgumentException("Select one ore more directories to be Moved");

                if (string.IsNullOrEmpty(DistFolder))
                    throw new ArgumentException("you should provide a destination folder!");

                DirectoryManager.MoveAll(ListSelectedDirctories, DistFolder);
                ListDirctoryFound = ListDirctoryFound
                    .Where(dir => !ListSelectedDirctories.Contains(dir))
                    .ToList();

                Message = $"Total Moved : {_countSelected}";
                ListSelectedDirctories = new List<DirectoryInfo>();
            });
            MoveAll = new RelayCommand(() =>
            {
                if (ListDirctoryFound is null || _countFound <= 0)
                    throw new ArgumentException("No directories Founds to be Moved");

                if (string.IsNullOrEmpty(DistFolder))
                    throw new ArgumentException("you should provide a destination folder!");

                DirectoryManager.MoveAll(ListDirctoryFound, DistFolder);

                Message = $"Total Moved : {_countFound}";
                ListDirctoryFound = new List<DirectoryInfo>();
            });
            CopySelected = new RelayCommand(() =>
            {
                if (ListSelectedDirctories is null || _countSelected <= 0)
                    throw new ArgumentException("Select one or more directories to be Copied");

                if (string.IsNullOrEmpty(DistFolder))
                    throw new ArgumentException("you should provide a destination folder!");

                DirectoryManager.CopyAll(ListSelectedDirctories, DistFolder);
                Message = $"Total Copied : {_countSelected}";
            });
            CopyAll = new RelayCommand(() =>
            {
                if (ListDirctoryFound is null || _countFound <= 0)
                    throw new ArgumentException("No directories founds to be Copied");

                if (string.IsNullOrEmpty(DistFolder))
                    throw new ArgumentException("you should provide a destination folder!");

                DirectoryManager.CopyAll(ListDirctoryFound, DistFolder);
                Message = $"Total Copied : {_countFound}";
            });
            Clear = new RelayCommand(() =>
            {
                SourceFolder = null;
                DistFolder = null;
            });
            ClearOutput = new RelayCommand(() =>
            {
                ListDirctoryFound = new List<DirectoryInfo>();
                ListSelectedDirctories = new List<DirectoryInfo>();
            });
        }

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged Event for the given prop
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="propName">the name of the property</param>
        public void OnPropertyChanged(object sender, [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}