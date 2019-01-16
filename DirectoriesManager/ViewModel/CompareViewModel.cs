using System;
using System.Linq;
using System.IO;
using System.IO.Expand;

namespace DirectoriesManager
{
    public class CompareViewModel : BaseViewModel
    {
        #region Private fields

        private static string _CompareToFolder;
        private static bool _matching;
        private static CompareOptions _compareOptions;

        #endregion

        #region Public Props

        public string CompareToFolder
        {
            get => _CompareToFolder;
            set

            {
                _CompareToFolder = value;
                OnPropertyChanged(this, nameof(CompareToFolder));
            }
        }
        public bool Matching
        {
            get => _matching;
            set
            {
                _matching = value;
                OnPropertyChanged(this, nameof(Matching));
            }
        }
        public CompareOptions CompareOptions
        {
            get => _compareOptions;
            set
            {
                _compareOptions = value;
                OnPropertyChanged(this, nameof(CompareOptions));
            }
        }

        public RelayCommand Compare;

        #endregion

        public CompareViewModel()
        {
            CompareToFolder = SourceFolder;
            Matching = true;

            Compare = new RelayCommand(() =>
            {
                var outputOptions = Matching ? OutputOptions.Matching : OutputOptions.NonMatching;

                if (string.IsNullOrEmpty(SourceFolder))
                    throw new ArgumentException("you should provide a source folder!");

                if (string.IsNullOrEmpty(CompareToFolder))
                    throw new ArgumentException("you should provide a Compare folder!");

                var SrcDir = new DirectoryInfo(SourceFolder);

                ListDirctoryFound = SrcDir
                    .Compare(new DirectoryInfo(CompareToFolder), outputOptions, CompareOptions)
                    .ToList();
            });
            Clear = new RelayCommand(() =>
            {
                SourceFolder = null;
                CompareToFolder = null;
            });
        }

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion
    }
}
