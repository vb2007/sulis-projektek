namespace Kemia_VB_Lib;

public abstract class KemiaiElem : IReakcioKepes
{
    public string Vegyjel { get; init; }
    public int Rendszam { get; init; }
    public int Focsoport { get; init; }

    public KemiaiElem(string vegyjel, int rendszam, int focsoport)
    {
        Vegyjel = vegyjel;
        Rendszam = rendszam;
        Focsoport = focsoport;
    }

    public abstract bool ReakciobaLephet();

    public abstract bool ReakciobaLephet(IReakcioKepes obj);
}
