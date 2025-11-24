namespace JoAlany_VB_Lib;

public sealed class Tanar : Szemely, IVizsgalat
{
    public double EvVegiAtlag { get; init; }

    public Tanar(string szemelyNev, DateTime szuletesiDatum, double evVegiAtlag) : base(szemelyNev, szuletesiDatum)
    {
        this.EvVegiAtlag = evVegiAtlag;
    }

    public bool JoAlanyE()
    {
        //return EvVegiAtlag >= 3.5 && Kor < 30 ? true : false;
        return EvVegiAtlag >= 3.5 && Kor < 30;
    }
    
    public override string ToString()
    {
        return $"{SzemelyNev} ({Kor} éves), {(JoAlanyE() == true ? "Jó tanár!" : "Rossz tanár!")}";
    }
}