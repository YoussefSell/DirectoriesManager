using System;
using System.IO;
using System.Linq;
using System.IO.Expand;

namespace DirectoriesManager
{
    public class RenameViewModel : BaseViewModel
    {
        #region Private fields

        private static bool _isFilterRegex;
        private static string _Filter;
        private static RenameOptions _renameOptions;
        private static char _separator;
        private static int _startwith;
        private static string _regexpatern;
        private static string _replacewith;

        private static bool _separator_Enabled;
        private static bool _startwith_Enabled;
        private static bool _regexpatern_Enabled;
        private static bool _replacewith_Enabled;

        #endregion

        #region Public props

        public string Filter
        {
            get => _Filter;
            set
            {
                _Filter = value;
                OnPropertyChanged(this, nameof(SourceFolder));
            }
        }
        public bool IsFilterRegex
        {
            get => _isFilterRegex;
            set
            {
                _isFilterRegex = value;
                OnPropertyChanged(this, nameof(IsFilterRegex));
            }
        }
        public int RenameOptionsValue
        {
            get => (int)_renameOptions;
            set
            {
                _renameOptions = (RenameOptions)value;
                SetVisibility();
                ClearOptions();

                OnPropertyChanged(this);
            }
        }

        public char Separator
        {
            get => _separator;
            set
            {
                _separator = value;
                OnPropertyChanged(this);
            }
        }
        public int Startwith
        {
            get => _startwith;
            set
            {
                _startwith = value;
                OnPropertyChanged(this);
            }
        }
        public string RegexPattern
        {
            get => _regexpatern;
            set
            {
                _regexpatern = value;
                OnPropertyChanged(this);
            }
        }
        public string ReplaceWith
        {
            get => _replacewith;
            set
            {
                _replacewith = value;
                OnPropertyChanged(this);
            }
        }

        public bool SeparatorEnabled
        {
            get => _separator_Enabled;
            set
            {
                _separator_Enabled = value;
                OnPropertyChanged(this);
            }
        }
        public bool StartwithEnabled
        {
            get => _startwith_Enabled;
            set
            {
                _startwith_Enabled = value;
                OnPropertyChanged(this);
            }
        }
        public bool RegexPatternEnabled
        {
            get => _regexpatern_Enabled;
            set
            {
                _regexpatern_Enabled = value;
                OnPropertyChanged(this);
            }
        }
        public bool ReplaceWithEnabled
        {
            get => _replacewith_Enabled;
            set
            {
                _replacewith_Enabled = value;
                OnPropertyChanged(this);
            }
        }

        public RelayCommand Search;
        public RelayCommand RenameSelected;
        public RelayCommand RenameAll;

        #endregion

        public RenameViewModel()
        {
            RenameOptionsValue = (int)RenameOptions.Default;

            Clear = new RelayCommand(() =>
            {
                SourceFolder = "";
                Filter = "";
                Separator = '\0';
                Startwith = 1;
                RegexPattern = "";
                ReplaceWith = "";
                RenameOptionsValue = (int)RenameOptions.Default;
            });
            Search = new RelayCommand(() =>
            {
                if (string.IsNullOrEmpty(_sourceFolder))
                    throw new ArgumentException("invalid source folder, is null or empty");

                var srcF = new DirectoryInfo(_sourceFolder);

                if (!srcF.Exists)
                    throw new ArgumentException($"specified path : { srcF.FullName } not exist!");

                var searchOption = IsFilterRegex ? SearchOptions.Regex : SearchOptions.Default;
                ListDirctoryFound = srcF.Search(Filter, searchOption).ToList();
            });
            RenameSelected = new RelayCommand(() =>
            {
                if (ListSelectedDirctories is null || CountSelected <= 0)
                    throw new ArgumentException("Select one or more directories");

                switch (_renameOptions)
                {
                    case RenameOptions.Default:
                        DirectoryManager.RenameAll(ListSelectedDirctories);
                        break;
                    default:
                        DirectoryManager.RenameAll(ListSelectedDirctories,
                                                   options: _renameOptions,
                                                   separator: _separator,
                                                   pattern: _regexpatern,
                                                   startFrom: _startwith,
                                                   Replacewith: _replacewith);
                        break;
                }

                Search.Execute(null);
                ClearOptions();
            });
            RenameAll = new RelayCommand(() =>
            {
                if (ListDirctoryFound is null || CountFound <= 0)
                    throw new ArgumentException("Select one or more directories");

                switch (_renameOptions)
                {
                    case RenameOptions.Default:
                        DirectoryManager.RenameAll(ListDirctoryFound);
                        break;
                    case RenameOptions.UseUniqueName:
                        throw new ArgumentException("if the rename option is set to unique name you have to select only one Directory and use the 'Rename' button");
                    default:
                        DirectoryManager.RenameAll(ListDirctoryFound,
                                                   options: _renameOptions,
                                                   separator: _separator,
                                                   pattern: _regexpatern,
                                                   startFrom: _startwith,
                                                   Replacewith: _replacewith);
                        break;
                }

                Search.Execute(null);
                ClearOptions();
            });
        }

        private void SetVisibility()
        {
            switch (_renameOptions)
            {
                case RenameOptions.ReplaceMatchedRegexPattern:
                    SeparatorEnabled = false;
                    StartwithEnabled = false;
                    RegexPatternEnabled = true;
                    ReplaceWithEnabled = true;
                    break;
                case RenameOptions.RemoveMatchedRegexPattern:
                    SeparatorEnabled = false;
                    StartwithEnabled = false;
                    RegexPatternEnabled = true;
                    ReplaceWithEnabled = false;
                    break;
                case RenameOptions.AddRandomLettersToEnd:
                    SeparatorEnabled = true;
                    StartwithEnabled = false;
                    RegexPatternEnabled = false;
                    ReplaceWithEnabled = false;
                    break;
                case RenameOptions.UseUniqueName:
                    SeparatorEnabled = false;
                    StartwithEnabled = false;
                    RegexPatternEnabled = false;
                    ReplaceWithEnabled = true;
                    break;
                case RenameOptions.Default:
                    SeparatorEnabled = false;
                    StartwithEnabled = false
    ;
                    RegexPatternEnabled = false;
                    ReplaceWithEnabled = false;
                    break;
                case RenameOptions.AddIncrementalNumbersToEnd:
                case RenameOptions.AddIncrementalNumbersToBeginning:
                default:
                    SeparatorEnabled = true;
                    StartwithEnabled = true;
                    RegexPatternEnabled = false;
                    ReplaceWithEnabled = false;
                    break;
            }
        }

        private void ClearOptions()
        {
            Separator = '\0';
            Startwith = 1;
            RegexPattern = "";
            ReplaceWith = "";
        }
    }
}
