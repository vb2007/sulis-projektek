namespace Viragkoteszet_VB_Lib;

public class Alapanyag
{
    public string Azonosito { get; set; }
    public string Nev { get; set; }
    public int Ar { get; set; }
    public int ElkeszitesiIdo { get; set; } //percben

    public Alapanyag(string azonosito, string nev, int ar, int elkeszitesiIdo)
    {
        Azonosito = azonosito;
        Nev = nev;
        Ar = ar;
        ElkeszitesiIdo = elkeszitesiIdo;
    }
}