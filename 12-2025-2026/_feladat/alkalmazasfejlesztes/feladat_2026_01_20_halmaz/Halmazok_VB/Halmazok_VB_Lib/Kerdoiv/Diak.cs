namespace Halmazok_VB_Lib.Kerdoiv;

public class Diak : Szemely
{
    public string Osztaly { get; set; }

    public Diak(string oktatsiAzonosito, string nev, string osztaly) : base(oktatsiAzonosito, nev)
    {
        Osztaly = osztaly;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Diák ({Osztaly})";
    }
}
