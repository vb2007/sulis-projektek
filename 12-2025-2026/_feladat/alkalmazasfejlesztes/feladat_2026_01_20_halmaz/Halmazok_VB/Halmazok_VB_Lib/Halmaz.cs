using System.Collections;

namespace Halmazok_VB_Lib;
    
public class Halmaz<T> : IEnumerable<T>
{
    protected List<T> _elemek;

    public Halmaz()
    {
        _elemek = new List<T>();
    }

    public Halmaz(IEnumerable<T> gyujtemeny) : this()
    {
        foreach (T elem in gyujtemeny)
        {
            Hozzaad(elem);
        }
    }

    public int Elemszam => _elemek.Count;

    public virtual bool Tartalmazza(T elem)
    {
        return _elemek.Contains(elem);
    }

    public virtual void Hozzaad(T elem)
    {
        if (!Tartalmazza(elem))
        {
            _elemek.Add(elem);
        }
    }

    public void Torol(T elem)
    {
        _elemek.Remove(elem);
    }

    public IEnumerable<T> Elemek => _elemek;

    public static Halmaz<T> operator +(Halmaz<T> a, Halmaz<T> b)
    {
        Halmaz<T> ujHalmaz = new Halmaz<T>();
        
        foreach (T elem in a._elemek)
        {
            ujHalmaz.Hozzaad(elem);
        }
        foreach (T elem in b._elemek)
        {
            ujHalmaz.Hozzaad(elem);
        }
        
        return ujHalmaz;
    }

    public static Halmaz<T> operator *(Halmaz<T> a, Halmaz<T> b)
    {
        Halmaz<T> ujHalmaz = new Halmaz<T>();
        foreach (T elem in a._elemek)
        {
            if (b.Tartalmazza(elem))
            {
                ujHalmaz.Hozzaad(elem);
            }
        }
        return ujHalmaz;
    }

    public static Halmaz<T> operator -(Halmaz<T> a, Halmaz<T> b)
    {
        Halmaz<T> ujHalmaz = new Halmaz<T>();
        foreach (T elem in a._elemek)
        {
            if (!b.Tartalmazza(elem))
            {
                ujHalmaz.Hozzaad(elem);
            }
        }
        return ujHalmaz;
    }

    public override string ToString()
    {
        return string.Join(", ", _elemek);
    }

    public IEnumerator<T> GetEnumerator() => _elemek.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}