namespace Viragkoteszet_VB_Lib;

public class Dolgozo
{
    public int Azonosito { get; }
    public string Nev { get; }
    public char Beosztas { get; }
    public List<IDictionary<string, int>> AlapanyagLista { get; }
    
    public bool Gyakorlottsag { get; }
    public int MunkaraForditottIdo { get; set; }

    public Dolgozo(int azonosito, string nev)
    {
        Azonosito = azonosito;
        Nev = nev;
    }
    
}