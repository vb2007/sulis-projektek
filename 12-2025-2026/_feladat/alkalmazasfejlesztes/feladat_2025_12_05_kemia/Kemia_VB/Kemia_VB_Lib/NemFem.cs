namespace Kemia_VB_Lib;

public sealed class NemFem : KemiaiElem
{
    public NemFem(string vegyjel, int rendszam, int focsoport) : base(vegyjel, rendszam, focsoport)
    {
    }

    public override bool ReakciobaLephet() { return true; }

    public override bool ReakciobaLephet(IReakcioKepes obj)
    {
        if (obj is KemiaiElem elem)
        {
            return (this.Focsoport + elem.Focsoport) % 8 == 0;
        }
        
        return false;
    }
}
