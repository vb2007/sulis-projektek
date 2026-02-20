namespace SuperBowl_VB_Library;

public class Donto
{
    public string SorszamRomai { get; set; }
    public DateOnly Datum { get; set; }
    public string Gyoztes { get; set; }
    public int VesztesEredmeny { get; set; }
    public int GyoztesEredmeny { get; set; }
    public string Vesztes { get; set; }
    public string Helyszin { get; set; }
    public string VarosAllam { get; set; }
    public int Nezoszam { get; set; }

    public Donto(string adatSor)
    {
        string[] adatok = adatSor.Split(';');
        string[] eredmenyek = adatok[3].Split("-");

        SorszamRomai = adatok[0];
        Datum = DateOnly.Parse(adatok[1]);
        Gyoztes = adatok[2];
        VesztesEredmeny = int.Parse(eredmenyek[0]);
        GyoztesEredmeny = int.Parse(eredmenyek[1]);
        Vesztes = adatok[4];
        Helyszin = adatok[5];
        VarosAllam = adatok[6];
        Nezoszam = int.Parse(adatok[7]);
    }
}