namespace Halmazok_VB_Lib.Kerdoiv;

public class Tanar : Szemely
{
    public string Szak { get; set; }
    
    public Tanar(string oktatsiAzonosito, string nev, string szak) : base(oktatsiAzonosito, nev)
    {
        Szak = szak;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Tanár ({Szak})";
    }
}
