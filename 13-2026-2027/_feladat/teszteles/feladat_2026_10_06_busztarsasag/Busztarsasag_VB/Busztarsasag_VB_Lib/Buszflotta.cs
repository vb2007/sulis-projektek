namespace Busztarsasag_VB_Lib;

public class Buszflotta
{
    private readonly Dictionary<string, IBusz> _buszok;
    private readonly Dictionary<string, Megallo> _megallok;

    public Buszflotta(IEnumerable<IBusz> buszok, IEnumerable<string> megallok)
    {
        _buszok = buszok.ToDictionary(x => x.Rendszam);
        _megallok = megallok.ToDictionary(nev => nev, nev => new Megallo(nev));

        if (_buszok.Count < 1)
        {
            throw new ArgumentException("Legalább egy busz kell.", nameof(buszok));
        }
    }

    // egy busz, egy megálló: 1. leszállnak 2. felszállnak
    public int Megall(string rendszam, string megallo, int leszallok, int varakozok)
    {
        IBusz busz = _buszok[rendszam];
        Megallo allomas = _megallok[megallo];

        busz.Leszall(leszallok);
        int felszallt = busz.Felszall(varakozok);
        int lentmaradt = varakozok - felszallt;

        allomas.Rogzit(leszallok, felszallt, lentmaradt);
        return lentmaradt; // lent maradt utasok száma
    }

    public int Felszallt(string megallo) => _megallok[megallo].Felszallt;

    public int Leszallt(string megallo) => _megallok[megallo].Leszallt;

    public int Lentmaradt(string megallo) => _megallok[megallo].Lentmaradt;

    public int OsszesSzallitott(string rendszam) => _buszok[rendszam].OsszesSzallitott;

    public void NapVege()
    {
        foreach (IBusz busz in _buszok.Values) busz.NapVege();
        foreach (Megallo megallo in _megallok.Values) megallo.NapVege();
    }
}
