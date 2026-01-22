namespace Ajandekdoboz_VB_Lib;

public abstract class Termek
{
    public string Nev { get; set; }
    public int Ar { get; set; }
    
    public Termek(string nev, int ar)
    {
        Nev = nev;
        Ar = ar;
    }

    public override string ToString()
    {
        return $"{Nev} - {Ar} Ft";
    }
}