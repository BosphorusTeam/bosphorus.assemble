namespace Bosphorus.BootStapper.Runner.Common
{
    internal class WorkingDirectoryAssemblyProvider : DirectoryAssemblyProvider
    {
        public WorkingDirectoryAssemblyProvider() 
            : base(".")
        {
        }
    }
}