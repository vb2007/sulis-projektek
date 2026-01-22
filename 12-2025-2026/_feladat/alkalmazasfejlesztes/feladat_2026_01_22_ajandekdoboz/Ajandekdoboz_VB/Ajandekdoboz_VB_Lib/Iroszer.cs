namespace Ajandekdoboz_VB_Lib;

public class Iroszer : Termek
{
    public string TintaSzine { get; set; }
    
    public Iroszer(string nev, int ar, string tintaSzine) : base(nev, ar)
    {
        TintaSzine = tintaSzine;
    }
}