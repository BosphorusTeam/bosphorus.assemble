namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public interface IFileCopier
    {
        bool Copy(string sourceFilePath, string targetFilePath);
    }
}
