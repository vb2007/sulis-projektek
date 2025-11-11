namespace Csokigyar_VB_Lib;

public interface IEtel
{
    IEnumerable<string> MibolKeszul();
    bool MegfeleloMinoseg { get; }
}