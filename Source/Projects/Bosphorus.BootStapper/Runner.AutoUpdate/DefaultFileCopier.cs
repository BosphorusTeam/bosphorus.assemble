using System.IO;

namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public class DefaultFileCopier : IFileCopier
    {
        public bool Copy(string sourceFilePath, string targetFilePath)
        {
            File.Copy(sourceFilePath, targetFilePath, true);
            return true;
        }
    }
}