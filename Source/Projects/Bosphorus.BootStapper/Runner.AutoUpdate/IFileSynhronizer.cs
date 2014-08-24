namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public interface IFileSynhronizer
    {
        bool Synchronize(string sourceDirectory, string targetDirectory, string searchPattern);
    }
}
