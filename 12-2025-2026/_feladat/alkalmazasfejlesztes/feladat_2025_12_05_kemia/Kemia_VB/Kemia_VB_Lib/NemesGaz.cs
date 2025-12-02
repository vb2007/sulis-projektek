namespace Kemia_VB_Lib;

public sealed class NemesGaz : KemiaiElem
{
    public NemesGaz(string vegyjel, int rendszam, int focsoport) : base(vegyjel, rendszam, focsoport)
    {
        if (focsoport != 8)
        {
            throw new ArgumentException("A nemesgáz főcsoportja csak 8 lehet!");
        }
    }

    public override bool ReakciobaLephet() { return false; }

    public override bool ReakciobaLephet(IReakcioKepes obj) { return false; }
}
