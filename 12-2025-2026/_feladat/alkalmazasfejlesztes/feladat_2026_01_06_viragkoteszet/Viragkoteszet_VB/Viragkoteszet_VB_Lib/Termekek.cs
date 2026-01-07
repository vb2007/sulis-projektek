namespace Viragkoteszet_VB_Lib;

public class Termekek
{
    public List<Termek> TermekLista { get; } = new List<Termek>();
    
    public Termekek(IEnumerable<Termek> termekek)
    {
        foreach (Termek termek in termekek)
        {
            TermekLista.Add(termek);
        }
    }
    
    public Termek this[int azonosito] 
    {
        get
        {
            return TermekLista.First(t => t.Azonosito == azonosito);
        }
    }

    public override string ToString()
    {
        return string.Join("\n", TermekLista);
    }
}