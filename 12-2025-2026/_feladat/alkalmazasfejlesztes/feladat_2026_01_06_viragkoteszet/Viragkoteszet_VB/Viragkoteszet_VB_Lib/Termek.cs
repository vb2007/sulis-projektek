namespace Viragkoteszet_VB_Lib;

public class Termek : ITermek
{
    public int Azonosito { get; }
    public string Tipus { get; }
    public string Megnevezes { get; }
    public int ElkeszitesiIdo { get; }
    public List<IDictionary<string, int>> AlapanyagLista { get; }
    public int Ar { get; }

    public Termek(int azonosito, string tipus, string megnevezes, List<IDictionary<string, int>> alapanyagLista)
    {
        
    }

    public override string ToString()
    {
        return base.ToString();
    }
}