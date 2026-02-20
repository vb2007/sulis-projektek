namespace SuperBowl_VB_Library;

public class Dontok
{
    private readonly List<Donto> dontok = new List<Donto>();
    
    public Dontok(IEnumerable<string> adatSorok)
    {
        foreach (string adatSor in adatSorok)
        {
            dontok.Add(new Donto(adatSor));
        }
    }

    public int DontokSzama => dontok.Count;
    public double AtlagosPontkulonbseg => dontok.Average(d => Math.Abs(d.GyoztesEredmeny - d.VesztesEredmeny));

    public Donto LegnezettebbDonto => dontok.MaxBy(d => d.Nezoszam)!;

    public void Mentes(string fajlnev)
    {
        List<string> kimenet = new List<string> { "Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám" };
        List<string> szereplesek = new List<string>();

        foreach (var d in dontok)
        {
            szereplesek.Add(d.Gyoztes);
            int gyoztesSzereples = szereplesek.Count(s => s == d.Gyoztes);

            szereplesek.Add(d.Vesztes);
            int vesztesSzereples = szereplesek.Count(s => s == d.Vesztes);

            int arabSsz = new RomaiSorszam(d.SorszamRomai).ArabSorszam;
            kimenet.Add($"{arabSsz};{d.Datum:yyyy.MM.dd};{d.Gyoztes} ({gyoztesSzereples});{d.GyoztesEredmeny}-{d.VesztesEredmeny};{d.Vesztes};{d.Nezoszam}");
        }

        File.WriteAllLines(fajlnev, kimenet, System.Text.Encoding.UTF8);
    }
}