using Bosphorus.Common.Clr.Diagnostic;

namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public class DebugDecorator : IFileCopier
    {
        private readonly IFileCopier decorated;

        public DebugDecorator(IFileCopier decorated)
        {
            this.decorated = decorated;
        }

        public bool Copy(string sourceFilePath, string targetFilePath)
        {
            bool result = decorated.Copy(sourceFilePath, targetFilePath);
            DebugEx.Log("Auto Update: File Copied: {0}", targetFilePath);
            return result;
        }
    }
}