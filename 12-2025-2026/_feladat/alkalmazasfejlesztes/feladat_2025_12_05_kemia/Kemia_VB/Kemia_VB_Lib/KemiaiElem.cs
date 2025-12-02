namespace Kemia_VB_Lib;

public class KemiaiElem : IReakcioKepes
{
    public string Vegyjel { get; init; }
    public string Rendszam { get; init; }
    public string Focsoport { get; init; }

    public KemiaiElem(string vegyjel, string rendszam, string focsoport)
    {
        Vegyjel = vegyjel;
        Rendszam = rendszam;
        Focsoport = focsoport;
    }

    public bool ReakciobaLephet()
    {
        throw new NotImplementedException();
    }
    
    public bool ReakciobaLephet(IReakcioKepes obj)
    {
        throw new NotImplementedException();
    }
}