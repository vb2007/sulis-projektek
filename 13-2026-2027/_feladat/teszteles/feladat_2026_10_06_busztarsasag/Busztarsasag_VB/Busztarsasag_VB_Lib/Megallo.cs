namespace Busztarsasag_VB_Lib;

public class Megallo
{
    public string Nev { get; }
    public int Felszallt { get; private set; }
    public int Leszallt { get; private set; }
    public int Lentmaradt { get; private set; }

    public Megallo(string nev)
    {
        if (string.IsNullOrWhiteSpace(nev))
        {
            throw new ArgumentException("A megálló neve nem lehet üres.", nameof(nev));
        }

        Nev = nev;
    }

    public void Rogzit(int leszallt, int felszallt, int lentmaradt)
    {
        Leszallt += leszallt;
        Felszallt += felszallt;
        Lentmaradt += lentmaradt;
    }

    public void NapVege()
    {
        Felszallt = 0;
        Leszallt = 0;
        Lentmaradt = 0;
    }
}
