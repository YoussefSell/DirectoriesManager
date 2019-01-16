using System;
using System.Linq;
using System.IO;
using System.IO.Expand;

namespace DirectoriesManager
{
    public class SearchViewModel : BaseViewModel
    {
        #region Private Props

        private static string _searchKey;
        private static bool _isRegex;

        #endregion

        #region Public Props

        public string SearchKey
        {
            get => _searchKey;
            set
            {
                _searchKey = value;
                OnPropertyChanged(this);
            }
        }
        public bool IsRegex
        {
            get => _isRegex;
            set
            {
                _isRegex = value;
                OnPropertyChanged(this);
            }
        }

        #endregion

        #region Commands

        public RelayCommand Search;

        #endregion

        public SearchViewModel()
        {
            Search = new RelayCommand(() =>
            {
                if (string.IsNullOrEmpty(_sourceFolder))
                    throw new ArgumentException("invalid source folder, Please provide a source folder");

                var srcF = new DirectoryInfo(_sourceFolder);

                if (!srcF.Exists)
                    throw new ArgumentException($"specified path : { srcF.FullName } is not exist!");

                var searchOption = IsRegex ? SearchOptions.Regex : SearchOptions.Default;
                ListDirctoryFound = srcF.Search(SearchKey, searchOption).ToList();
            });
            Clear = new RelayCommand(() =>
            {
                DistFolder = null;
                SourceFolder = null;
                SearchKey = null;
            });
        }

        #region Private Methods

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
