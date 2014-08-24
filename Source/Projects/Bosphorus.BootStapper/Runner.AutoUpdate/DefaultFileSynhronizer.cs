using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public class DefaultFileSynhronizer : IFileSynhronizer
    {
        private readonly IEqualityComparer<FileInfo> fileComparer;
        private readonly IFileCopier fileCopier;

        public DefaultFileSynhronizer(IEqualityComparer<FileInfo> fileComparer, IFileCopier fileCopier)
        {
            this.fileComparer = fileComparer;
            this.fileCopier = fileCopier;
        }

        public bool Synchronize(string sourceDirectory, string targetDirectory, string searchPattern)
        {
            IEnumerable<FileInfo> sourceFiles = GetFiles(sourceDirectory, searchPattern);
            IEnumerable<FileInfo> targetFiles = GetFiles(targetDirectory, searchPattern);
            IEnumerable<FileInfo> files = sourceFiles.Except(targetFiles, fileComparer);

            foreach (var file in files)
            {
                string sourceFilePath = file.FullName;
                string targetFilePath = Path.Combine(targetDirectory, file.Name);
                fileCopier.Copy(sourceFilePath, targetFilePath);
            }

            return true;
        }

        private IEnumerable<FileInfo> GetFiles(string directory, string searchPattern)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            FileInfo[] result = directoryInfo.GetFiles(searchPattern, SearchOption.AllDirectories);
            return result;
        }
    }
}