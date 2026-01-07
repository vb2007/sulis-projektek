namespace Viragkoteszet_VB_Lib;

public class Viragkoto : Dolgozo
{
    public int Gyakorlottag { get; } = 100;
    public int MunkaraForditottIdo { get; }
    
    public Viragkoto(int azonosito, string nev) : base(azonosito, nev)
    {
    }
}