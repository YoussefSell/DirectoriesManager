using System;
using System.IO;
using System.IO.Expand;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DirectoriesManager
{
    static class Tools
    {
        /// <summary>
        /// clear the panel and add the control to it
        /// </summary>
        /// <param name="container">the container</param>
        /// <param name="control">the control to be added</param>
        internal static void Add(this Panel container, Control control)
        {
            control.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(control);
        }

        /// <summary>
        /// get the path from the FolderBrowserDialog
        /// </summary>
        /// <returns>selected path</returns>
        internal static string SelectedPath()
        {
            var path = "";

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
            }

            return path;
        }

        /// <summary>
        /// method for Initializing the ToolTip
        /// </summary>
        /// <param name="controls"></param>
        internal static void InitializeToolTip(IDictionary<Control, string> controls)
        {
            var toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 500,
                ShowAlways = true
            };

            foreach (var item in controls)
            {
                toolTip.SetToolTip(item.Key, item.Value);
            }
        }

        /// <summary>
        /// logging the Error to the log file
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="erorrLocation">the location where the Error accrue</param>
        internal static void LogError(Exception exception, string errorLocation)
        {
            //logic for logging
        }

        /// <summary>
        /// the execute method allows for a safe handled exception execution
        /// </summary>
        /// <param name="userControl">the caller of the function</param>
        /// <param name="action">the action to execute</param>
        /// <param name="callerName">the member that call the function</param>
        internal static void Execute(this UserControl userControl, Action action, string callerName = null)
        {
            Execute(action, callerName);
        }

        /// <summary>
        /// the execute method allows for a safe handled exception execution
        /// </summary>
        /// <param name="action">the action to execute</param>
        /// <param name="callerName">the member that call the function</param>
        internal static void Execute(Action action, string callerName = null)
        {
            try
            {
                action?.Invoke();
            }
            catch (System.Security.SecurityException ex)
            {
                MessageBox.Show("we can't access the Directory, we need Admin privilege"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("we can't access the Directory, there is a Security Access related problem"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (InvalidFolderNameException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show("the specified path is too long to be processed"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"there is an error accessing the Directory, {ex.Message}"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (RegexMatchTimeoutException ex)
            {
                MessageBox.Show("your Regex pattern is to complicated to be processed TimeOut Exception has been raised, try to simplify your pattern ",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
            catch (ArgumentException ex)
            {
                var msg = ex.TargetSite.Name == "ScanRegex" 
                    ? "Please provide a valid Regex pattern" : ex.Message;

                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(ex, callerName);
            }
        }

        /// <summary>
        /// validate the string
        /// </summary>
        /// <param name="val">the string to validate</param>
        /// <returns>true if valid</returns>
        internal static bool IsValid(this string val)
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return false;

            return true;
        }

        /// <summary>
        /// this solution is inspired from a stack-overflow answer at :
        /// https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
        /// </summary>
        /// <param name="value">the value to transfer</param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        internal static string SizeSuffix(long value, int decimalPlaces = 2)
        {
            string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",adjustedSize,SizeSuffixes[mag]);
        }
    }
    
    public class RenameOptionObj
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public static List<RenameOptionObj> GetRenameOptions()
        {
            return new List<RenameOptionObj>()
            {
                new RenameOptionObj() {Name = "Default",                              Value = 0 },
                new RenameOptionObj() {Name = "Add Incremental Numbers To Beginning", Value = 1 },
                new RenameOptionObj() {Name = "Add Incremental Numbers To End",       Value = 2 },
                new RenameOptionObj() {Name = "Replace Matched Regex Pattern",        Value = 3 },
                new RenameOptionObj() {Name = "Remove Matched Regex Pattern",         Value = 4 },
                new RenameOptionObj() {Name = "Add Random Letters To End",            Value = 5 },
                new RenameOptionObj() {Name = "Generate Random Names",                Value = 6 },
                new RenameOptionObj() {Name = "Use Unique Name",                      Value = 7 },
            };
        }
    }
}
