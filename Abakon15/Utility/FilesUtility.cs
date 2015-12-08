using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Windows.Threading;
using System.Windows;
using System.Collections.ObjectModel;
using AbakonDataModel;
using System.Text.RegularExpressions;
using Abakon15.Infrastructure;
using System.Windows.Forms;

namespace Abakon15.Utility
{
    public static class FilesUtility
    {
        public static string OpenFileDialog(string defaultFileName = "", string initialDir = "", string extensions = "", string filter = "")
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (extensions != "")
            {
                dlg.DefaultExt = extensions;
            }
            if (filter != "")
            {
                dlg.Filter = filter;
            }
            if (initialDir != "")
            {
                dlg.InitialDirectory = initialDir;
            }
            if (defaultFileName != "")
            {
                dlg.FileName = defaultFileName;
            }

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                return dlg.FileName;

            }
            else
            {
                return "";
            }
        }

        public static List<string> FilesInPath(string path)
        {
            List<string> result = new List<string>();

            try
            {
                FileAttributes attr = File.GetAttributes(path);
                FileInfo fileInfo = new FileInfo(path);

                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    var fNames = Directory.GetFiles(fileInfo.FullName);
                    foreach (var item in fNames)
                    {
                        result.Add(FileNameFromFullName(item));
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return result;
        }

        public static ObservableCollection<InfoFile> LoadFileInfo(string path)
        {

            FileAttributes attr = FileAttributes.Offline;
            FileInfo fileInfo;
            ObservableCollection<InfoFile> respose = new ObservableCollection<InfoFile>();
            try
            {
                attr = File.GetAttributes(path);
                fileInfo = new FileInfo(path);



                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    string[] files = Directory.GetFiles(fileInfo.FullName);

                    foreach (string file in files)
                    {
                        InfoFile infoF = new InfoFile();
                        fileInfo = new FileInfo(file);
                        infoF.Attributes = (int)fileInfo.Attributes;
                        infoF.CreationTime = fileInfo.CreationTime;
                        infoF.CreationTimeUtc = fileInfo.CreationTimeUtc;
                        infoF.Directory = fileInfo.Directory.ToString();
                        infoF.DirectoryName = fileInfo.DirectoryName;
                        infoF.Extension = fileInfo.Extension;
                        infoF.FullName = fileInfo.FullName;
                        infoF.LastAccessTime = fileInfo.LastAccessTime;
                        infoF.LastWriteTime = fileInfo.LastWriteTime;
                        infoF.Length = fileInfo.Length;
                        infoF.Name = fileInfo.Name;
                        infoF.IsReadOnly = fileInfo.IsReadOnly;
                        respose.Add(infoF);

                    }
                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }

            return respose;

        }

        public static bool ifFileExist(string path, string fileName)
        {
            string[] files = System.IO.Directory.GetFiles(path, fileName, System.IO.SearchOption.TopDirectoryOnly);
            return files.Any();
            //      return File.Exists(path + @"\" + fileName);
        }

        public static List<string> FilesInPathStringCollection(StringCollection files)
        {
            List<string> filesList = new List<string>();
            if (files.Count > 0)
            {
                FileAttributes attr = File.GetAttributes(files[0]);
                FileInfo fileInfo = new FileInfo(files[0]);

                foreach (string file in files)
                {
                    attr = File.GetAttributes(file);
                    fileInfo = new FileInfo(file);

                    if ((attr & FileAttributes.Directory) != FileAttributes.Directory && (attr & FileAttributes.Offline) != FileAttributes.Offline && (attr & FileAttributes.System) != FileAttributes.System)
                    {
                        filesList.Add(fileInfo.FullName);
                    }
                }
                return filesList;
            }
            else return filesList;
        }

        public static IEnumerable<string> FilesInPathMatched(String directory, string matchPattern)
        {
            if (directory.Trim().Length == 0) yield return null;
            //         var dl = Directory.GetFiles(directory);
            foreach (var item in Directory.GetFiles(directory))
            {
                if (Regex.Match(item, matchPattern).Success)
                {
                    yield return item;
                }
            }
        }

        public static string[] DirectoriesInPath(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            FileInfo fileInfo = new FileInfo(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return Directory.GetDirectories(fileInfo.FullName);
            }
            else
            {
                return new string[] { };
            }
        }

        public static string DirectoryNameFromFullName(string path)
        {
            if (path != "")
            {
                FileInfo fileInfo = new FileInfo(path);
                return fileInfo.DirectoryName;
            }
            else
                return "";
        }

        public static string FileNameFromFullName(string path)
        {
            if (path != "")
            {
                FileInfo fileInfo = new FileInfo(path);
                return fileInfo.Name;
            }
            else
                return "";
        }

        public static string[] DirectoriesInPathStringCollection(StringCollection dir)
        {
            if (dir.Count > 0)
            {
                FileAttributes attr = File.GetAttributes(dir[0]);
                FileInfo fileInfo = new FileInfo(dir[0]);
                List<string> filesList = new List<string>();
                foreach (string file in dir)
                {
                    attr = File.GetAttributes(file);
                    fileInfo = new FileInfo(file);

                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        filesList.Add(fileInfo.FullName);
                    }
                }
                return filesList.ToArray<string>();
            }
            else return new string[0];
        }

        public static string SelectFolderName(string path = null)
        {
            string folderName = string.Empty;
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowser.SelectedPath = path;
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderName = folderBrowser.SelectedPath;
            }

            return folderName;
        }

        public static void DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }

        public static void OpenFile(string fileName)
        {
            System.Diagnostics.ProcessStartInfo prsInfo = new System.Diagnostics.ProcessStartInfo();
            prsInfo.ErrorDialog = true;
            prsInfo.CreateNoWindow = true;
            prsInfo.FileName = fileName;
            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(prsInfo);
            }
            catch (Exception)
            {
            }
        }

        public static string SaveFileDialog(string defaultFileName = "", string initialDir = "", string extensions = "", string filter = "")
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.CreatePrompt = false;
            dlg.OverwritePrompt = true;
            if (extensions != "")
            {
                dlg.DefaultExt = extensions;
            }
            if (filter != "")
            {
                dlg.Filter = filter;
            }
            if (initialDir != "")
            {
                dlg.InitialDirectory = initialDir;
            }
            if (defaultFileName != "")
            {
                dlg.FileName = defaultFileName;
            }

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                return dlg.FileName;

            }
            else
            {
                return "";
            }
        }

        public static string FileCopyWithVersionControl(string surceFullName, string targetPath, string TargetName, string targetExtension)
        {
            string resultName;
            string[] files = System.IO.Directory.GetFiles(targetPath, TargetName + "*." + targetExtension, System.IO.SearchOption.TopDirectoryOnly);
            List<string> filesNameList = new List<string>();

            if (files.Any())
            {
                foreach (var item in files)
                {
                    filesNameList.Add(FileNameFromFullName(item));
                }
                resultName = GetNextFileName(filesNameList);
            }
            else
            {
                resultName = TargetName + "." + targetExtension;
            }

            File.Copy(surceFullName, targetPath + "\\" + resultName);
            return resultName;
        }

        public static StateOfExecution FileCopy(string surceFullName, string targetPath)
        {
            StateOfExecution result = new StateOfExecution();

            try
            {
                File.Copy(surceFullName, targetPath + "\\" + FileNameFromFullName(surceFullName));
            }
            catch (Exception ex)
            {

                result.ExceptionMsg = ex.Message + System.Environment.NewLine + ex.InnerException;
                result.OperationOK = false;
            }

            return result;
        }

        public static string GetNextFileName(List<string> fileNames)
        {
            string result = "";
            string pattern1 = @"(?<prefix>\w+)_(?<id>\d+)_(?<ver>\d+).(?<extension>\w+)";
            string pattern2 = @"(?<prefix>\w+)_(?<id>\d+).(?<extension>\w+)";
            // [\dR-;]+
            string prefix, id, ver, extension;
            int intVer, intVerMax = 0;
            Match match;
            if (fileNames.Any())
            {
                match = Regex.Match(fileNames[0], pattern1);
                if (match.Success)
                {
                    prefix = match.Groups["prefix"].Value;
                    id = match.Groups["id"].Value;
                    ver = match.Groups["ver"].Value; if (ver != "") { intVerMax = int.Parse(ver); }
                    extension = match.Groups["extension"].Value;
                }
                else
                {
                    match = Regex.Match(fileNames[0], pattern2);
                    if (match.Success)
                    {
                        prefix = match.Groups["prefix"].Value;
                        id = match.Groups["id"].Value;
                        ver = match.Groups["ver"].Value; if (ver != "") { intVerMax = int.Parse(ver); }
                        extension = match.Groups["extension"].Value;
                    }
                    else return result;
                }

                foreach (var item in fileNames)
                {
                    match = Regex.Match(item, pattern1);
                    if (match.Success)
                    {
                        ver = match.Groups["ver"].Value;
                        if (ver != "")
                        {
                            intVer = int.Parse(ver); if (intVer > intVerMax) intVerMax = intVer;
                        }
                    }
                }
                result = string.Format("{0}_{1}_{2}.{3}", prefix, id, (intVerMax + 1).ToString(), extension);
            }
            return result;
        }

        internal static List<string> GetXmlFile(PrzyrzadPomiarowy przyrzadPomiarowy, string selPath)
        {
            string matchPattern = string.Format(@"(NRZ|SPRG|SPRH|SPRZ|NP|EX){0}[_.].*(.xls|.xlsx)$", przyrzadPomiarowy.PrzyrzadPomiarowyNrKod.ToString().Trim());
            return FilesInPathMatched(selPath, matchPattern).ToList<string>();
        }

        internal static List<string> GetXmlFiles(string selPath)
        {
            string matchPattern = string.Format(@"(NRZ|SPRG|SPRH|SPRZ|NP|EX).*(.xls)$");
            return FilesInPathMatched(selPath, matchPattern).ToList<string>();
        }

        internal static string GetOmetrisisRptFileName()
        {
            string result = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/OmetrisisRPT";
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
        }


    }


    public class FileFolderDialog : CommonDialog
    {
        private OpenFileDialog dialog = new OpenFileDialog();

        public OpenFileDialog Dialog
        {
            get { return dialog; }
            set { dialog = value; }
        }

        public new DialogResult ShowDialog()
        {
            return this.ShowDialog(null);
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            // Set validate names to false otherwise windows will not let you select "Folder Selection."
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;

            try
            {
                // Set initial directory (used when dialog.FileName is set from outside)
                if (dialog.FileName != null && dialog.FileName != "")
                {
                    if (Directory.Exists(dialog.FileName))
                        dialog.InitialDirectory = dialog.FileName;
                    else
                        dialog.InitialDirectory = Path.GetDirectoryName(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                // Do nothing
            }

            // Always default to Folder Selection.
            dialog.FileName = "Folder Selection.";

            if (owner == null)
                return dialog.ShowDialog();
            else
                return dialog.ShowDialog(owner);
        }

        /// <summary>
        // Helper property. Parses FilePath into either folder path (if Folder Selection. is set)
        // or returns file path
        /// </summary>
        public string SelectedPath
        {
            get
            {
                try
                {
                    if (dialog.FileName != null &&
                        (dialog.FileName.EndsWith("Folder Selection.") || !File.Exists(dialog.FileName)) &&
                        !Directory.Exists(dialog.FileName))
                    {
                        return Path.GetDirectoryName(dialog.FileName);
                    }
                    else
                    {
                        return dialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return dialog.FileName;
                }
            }
            set
            {
                if (value != null && value != "")
                {
                    dialog.FileName = value;
                }
            }
        }

        /// <summary>
        /// When multiple files are selected returns them as semi-colon seprated string
        /// </summary>
        public string SelectedPaths
        {
            get
            {
                if (dialog.FileNames != null && dialog.FileNames.Length > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string fileName in dialog.FileNames)
                    {
                        try
                        {
                            if (File.Exists(fileName))
                                sb.Append(fileName + ";");
                        }
                        catch (Exception ex)
                        {
                            // Go to next
                        }
                    }
                    return sb.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public override void Reset()
        {
            dialog.Reset();
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            return true;
        }
    }
}
