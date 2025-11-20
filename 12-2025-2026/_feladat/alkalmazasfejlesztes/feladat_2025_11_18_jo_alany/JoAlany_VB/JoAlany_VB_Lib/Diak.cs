namespace JoAlany_VB_Lib;

public sealed class Diak : Szemely, IVizsgalat
{
    public int PuskakSzama { get; init; }
    public Diak(string szemelyNev, DateTime szuletesiDatum, int puskak) : base(szemelyNev, szuletesiDatum)
    {
        this.PuskakSzama = puskak;
    }

    public bool JoAlanyE()
    {
        return PuskakSzama == 0 ? true : false;
    }

    public override string ToString()
    {
        return $"{SzemelyNev} ({kor} éves), {(JoAlanyE() == true ? "Jó diák!" : "Rossz diák!")}";
    }
}