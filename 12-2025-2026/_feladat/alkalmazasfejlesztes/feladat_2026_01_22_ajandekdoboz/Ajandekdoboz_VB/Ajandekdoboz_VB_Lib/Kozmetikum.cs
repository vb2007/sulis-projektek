namespace Ajandekdoboz_VB_Lib;

public class Kozmetikum : Termek
{
    public string Marka { get; set; }
    
    public Kozmetikum(string nev, int ar, string marka) : base(nev, ar)
    {
        Marka = marka;
    }
}