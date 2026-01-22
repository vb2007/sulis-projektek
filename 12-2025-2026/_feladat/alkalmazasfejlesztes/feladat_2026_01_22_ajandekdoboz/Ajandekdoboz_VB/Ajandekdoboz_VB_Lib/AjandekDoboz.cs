namespace Ajandekdoboz_VB_Lib;

public class AjandekDoboz<T> where T : Termek
{
    protected readonly List<T> _lista;

    public int Meret => _lista.Count;
    
    public AjandekDoboz()
    {
        _lista = new List<T>();
    }

    public AjandekDoboz(IEnumerable<T> products)
    {
        _lista = products.ToList();
    }

    public void Add(T product)
    {
        _lista.Add(product);
    }
    
    public void Remove(T item)
    {
        _lista.Remove(item);
    }
    
    public T this[int index] => _lista[index];
    
    public int OsszErtek => _lista.Sum(x => x.Ar);

    public override string ToString()
    {
        return $"Ajándékdoboz ({typeof(T).Name}), {Meret}db, Összérték: {OsszErtek} Ft";
    }
}