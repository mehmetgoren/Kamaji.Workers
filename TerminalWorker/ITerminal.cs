namespace TerminalWorker
{
    using System.Threading.Tasks;

    internal interface ITerminal
    {
        Task<string> Run(string asset, object args);
    }
}
