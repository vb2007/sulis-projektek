namespace Viragkoteszet_VB_Lib;

public class Termek : ITermek
{
    public int Azonosito { get; }
    public string Tipus { get; }
    public string Megnevezes { get; }
    private List<(Alapanyag alapanyag, int mennyiseg)> _alapanyagok;
    
    public int ElkeszitesiIdo 
    { 
        get 
        {
            int ossz = 0;
            foreach (var (alapanyag, mennyiseg) in _alapanyagok)
            {
                ossz += alapanyag.ElkeszitesiIdo * mennyiseg;
            }
            return ossz;
        }
    }
    
    public int Ar
    { 
        get 
        {
            int ossz = 0;
            foreach (var (alapanyag, mennyiseg) in _alapanyagok)
            {
                ossz += alapanyag.Ar * mennyiseg;
            }
            return ossz;
        }
    }

    public Termek(int azonosito, string tipus, string megnevezes, List<(Alapanyag alapanyag, int mennyiseg)> alapanyagok)
    {
        Azonosito = azonosito;
        Tipus = tipus;
        Megnevezes = megnevezes;
        _alapanyagok = alapanyagok;
    }

    public override string ToString()
    {
        return $"{Tipus} - {Megnevezes} ({ElkeszitesiIdo} perc, {Ar} Ft)";
    }
}