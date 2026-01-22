namespace Ajandekdoboz_VB_Lib;

public class Husaru : Termek
{
    public bool Fustolt { get; set; }
    
    public Husaru(string nev, int ar, bool fustolt) : base(nev, ar)
    {
        Fustolt = fustolt;
    }
}