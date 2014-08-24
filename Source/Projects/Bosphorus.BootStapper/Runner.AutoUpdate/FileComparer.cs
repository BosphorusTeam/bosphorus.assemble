using System.Collections.Generic;
using System.IO;

namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public class FileComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo file1, FileInfo file2)
        {
            return file1.Name == file2.Name;
        }

        public int GetHashCode(FileInfo file)
        {
            return file.LastWriteTime.GetHashCode();
       }
    }
}