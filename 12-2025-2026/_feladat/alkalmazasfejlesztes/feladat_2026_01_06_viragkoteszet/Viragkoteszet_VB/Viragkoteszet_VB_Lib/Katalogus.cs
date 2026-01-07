namespace Viragkoteszet_VB_Lib;

public class Katalogus
{
    public List<Alapanyag> Alapanyagok { get; } = new List<Alapanyag>();

    public Katalogus(IEnumerable<Alapanyag> alapanyagok)
    {
        foreach (Alapanyag alapanyag in alapanyagok)
        {
            Alapanyagok.Add(alapanyag);
        }
    }

    public Alapanyag this[int sorszam] => Alapanyagok.ElementAt(sorszam);
}