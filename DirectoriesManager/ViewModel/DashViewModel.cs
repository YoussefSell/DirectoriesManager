using System;
using System.Linq;
using System.IO;
using System.IO.Expand;

namespace DirectoriesManager
{
    public class DashViewModel : BaseViewModel
    {
        #region Private Props

        DirectoryManager manager;
        readonly string TestFolderDir;
        string _totalSize;
        string _totalFiles;
        string _totalSubDirs;
        string _lastAccessTime;

        #endregion

        #region Public Props

        public string TotalSize
        {
            get => _totalSize;
            set
            {
                _totalSize = value;
                OnPropertyChanged(this);
            }
        }
        public string TotalFiles
        {
            get => _totalFiles;
            set
            {
                _totalFiles = value;
                OnPropertyChanged(this);
            }
        }
        public string TotalSubDirs
        {
            get => _totalSubDirs;
            set
            {
                _totalSubDirs = value;
                OnPropertyChanged(this);
            }
        }
        public string LastAccessTime
        {
            get => _lastAccessTime;
            set
            {
                _lastAccessTime = value;
                OnPropertyChanged(this);
            }
        }

        #endregion

        #region Commands

        public RelayCommand GenerateTestFolder;
        public RelayCommand RemoveGeneratedTestFolder;
        public RelayCommand Select;

        #endregion

        public DashViewModel()
        {
            TestFolderDir = Path.Combine(DirectoryManager.GetDesktopPath(), "DirectoriesManagerTestFolder");
            GenerateTestFolder = new RelayCommand(() => GenerateTestDirectories());
            RemoveGeneratedTestFolder = new RelayCommand(() => RemoveGeneratedDirectories());
            Select = new RelayCommand( () =>
            {
                var Manager = new DirectoryManager(SourceFolder);
                TotalFiles = (Manager.TotalFiles).ToString() + " Sub File";
                TotalSubDirs = Manager.TotalDirectories.ToString() + " Sub Directory";
                LastAccessTime = Manager.LastAccessTime.ToString();
                TotalSize = "Calculating the size ...";
                GetTotalSize(Manager);

                //cleaning
                Manager.Dispose();
                Manager = null;
            });
        }

        #region Private Methods

        private void GenerateTestDirectories()
        {
            manager = new DirectoryManager(TestFolderDir, true);
            manager.CreateSubdirectory(@"folder1\SubFolder1");
            manager.CreateSubdirectory(@"folder2\SubFolder2");
            manager.CreateSubdirectory(@"folder3\SubFolder3");
            manager.CreateSubdirectory(@"folder4\SubFolder4");
        }

        private void RemoveGeneratedDirectories()
        {
            if (manager is null)
                return;

            if (manager.Exists)
            {
                manager.Delete(true);
                manager.Dispose();
                manager = null;
            }
        }

        private async void GetTotalSize(DirectoryManager manager)
        {
            var size = await manager.GetTotalSizeAsync();
            TotalSize = Tools.SizeSuffix(size);
        }

        private void CheakIfValidPath(string value)
        {
            if (value == null)
                throw new ArgumentNullException($"the path is not specified!");

            if (!Directory.Exists(value))
                throw new ArgumentException($"the path : { value } is invalid, the directory not exist");
        }

        #endregion
    }
}
