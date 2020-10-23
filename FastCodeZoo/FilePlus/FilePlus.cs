using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FastCodeZoo.FilePlus
{
    public class FilePlus
    {
        public static void CopyDirectory(string sourceDirName, string destDirName, bool overwrite = false)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirName);
            DirectoryInfo target = new DirectoryInfo(destDirName);

            if (target.FullName.StartsWith(source.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("The parent directory cannot be copied to the child directory！");
            }

            if (!source.Exists)
            {
                return;
            }

            if (!target.Exists)
            {
                target.Create();
            }

            FileInfo[] files = source.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i].FullName, Path.Combine(target.FullName, files[i].Name), overwrite);
            }

            DirectoryInfo[] dirs = source.GetDirectories();

            for (int j = 0; j < dirs.Length; j++)
            {
                CopyDirectory(dirs[j].FullName, Path.Combine(target.FullName, dirs[j].Name));
            }
        }

        public static void CopyDirectorIgnore(string sourceDirName, string destDirName, string ignore = "",
            bool overwrite = false)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo target = new DirectoryInfo(destDirName);

            if (target.FullName.StartsWith(dir.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("The parent directory cannot be copied to the child directory！");
            }

            if (!dir.Exists)
                return;

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (!string.IsNullOrEmpty(ignore) && Regex.IsMatch(file.Name, ignore))
                {
                    continue;
                }

                string tempPath = Path.Combine(destDirName, file.Name);
                if (overwrite && File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                file.CopyTo(tempPath, overwrite);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                CopyDirectorIgnore(subdir.FullName, tempPath, ignore);
            }
        }
    }
}