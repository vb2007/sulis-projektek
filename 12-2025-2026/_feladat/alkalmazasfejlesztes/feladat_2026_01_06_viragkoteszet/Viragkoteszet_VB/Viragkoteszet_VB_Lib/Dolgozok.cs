namespace Viragkoteszet_VB_Lib;

public class Dolgozok
{
    public List<Dolgozo> DolgozoLista { get; } = new List<Dolgozo>();
    
    public Dolgozok(IEnumerable<Dolgozo> dolgozok)
    {
        foreach (Dolgozo dolgozo in dolgozok)
        {
            DolgozoLista.Add(dolgozo);
        }
    }
    
    public Dolgozo this[int azonosito] 
    {
        get
        {
            return DolgozoLista.First(d => d.Azonosito == azonosito);
        }
    }
    
    public int Darabszam => DolgozoLista.Count;
}