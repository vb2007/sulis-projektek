namespace Kemia_VB_Lib;

public class NemesGaz : KemiaiElem
{
    public string Vegyjel { get; init; }
    public string Rendszam { get; init; }
    public string Focsoport { get; init; } 
    
    public NemesGaz(string vegyjel, string rendszam, string focsoport) : base(vegyjel, rendszam, focsoport)
    {
    }
    
    public bool ReakciobaLephet()
    {
        return false;
    }
    
    public bool ReakciobaLephet(IReakcioKepes obj)
    {
        return false;
    }
}