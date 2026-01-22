namespace Halmazok_VB_Lib.Kerdoiv;

public abstract class Szemely
{
    public string OktatsiAzonosito { get; set; }
    public string Nev { get; set; }

    protected Szemely(string oktatsiAzonosito, string nev)
    {
        OktatsiAzonosito = oktatsiAzonosito;
        Nev = nev;
    }

    public override string ToString()
    {
        return $"{OktatsiAzonosito} - {Nev}";
    }
}