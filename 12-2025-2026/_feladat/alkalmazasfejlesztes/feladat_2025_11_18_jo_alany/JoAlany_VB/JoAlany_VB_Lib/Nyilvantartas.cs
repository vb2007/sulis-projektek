namespace JoAlany_VB_Lib;

public class Nyilvantartas
{
    private readonly List<Szemely> _szemelyek;

    //indexet, sorszám (1-től indul) alapján adja vissza a személy objektumot
    public Szemely this[int i]
    {
        get { return _szemelyek[i - 1]; }
    }

    public Nyilvantartas(IEnumerable<Szemely> szemelyekAdatai)
    {
        this._szemelyek = szemelyekAdatai.ToList();
    }

    public IEnumerable<Szemely> OsszesTaroltDiak()
    {
        return _szemelyek.Where(x => x is Diak);
    }
    
    public IEnumerable<Szemely> OsszesTaroltTanar()
    {
        return _szemelyek.Where(x => x is Tanar);
    }
}