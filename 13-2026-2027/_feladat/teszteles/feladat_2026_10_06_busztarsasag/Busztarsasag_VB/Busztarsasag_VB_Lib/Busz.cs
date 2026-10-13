namespace Busztarsasag_VB_Lib;

public class Busz : IBusz
{
    public string Rendszam { get; }
    public int Ferohely { get; }
    public int Utasok { get; private set; }
    public int OsszesSzallitott { get; private set; }

    public Busz(string rendszam, int ferohely)
    {
        if (string.IsNullOrWhiteSpace(rendszam))
        {
            throw new ArgumentException("A rendszám nem lehet üres.", nameof(rendszam));
        }

        if (ferohely < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(ferohely));
        }

        Rendszam = rendszam;
        Ferohely = ferohely;
    }

    public void Leszall(int db)
    {
        if (db < 0 || db > Utasok)
        {
            throw new ArgumentOutOfRangeException(nameof(db));   
        }

        Utasok -= db;
    }

    public int Felszall(int db)
    {
        if (db < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(db));
        }

        int felszallt = Math.Min(db, Ferohely - Utasok);
        Utasok += felszallt;
        OsszesSzallitott += felszallt;
        return felszallt;
    }

    public void NapVege()
    {
        Utasok = 0;
        OsszesSzallitott = 0;
    }
}
