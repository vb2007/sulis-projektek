using System.Text.Json;
using Halmazok_VB_Lib.Sorsolas;

namespace Halmazok_VB_Lib.Kerdoiv;

public class KerdoivSorsolas
{
    private Halmaz<Szemely> _szemelyLista;

    public KerdoivSorsolas()
    {
        _szemelyLista = new Halmaz<Szemely>();
    }

    public void AdatokBetoltese(string fajlNev)
    {
        string[] sorok = File.ReadAllLines(fajlNev);
        
        foreach (string sor in sorok)
        {
            string[] reszek = sor.Split(';');
            
            string oktatsiAzonosito = reszek[0];
            string nev = reszek[1];
            string tipus = reszek[2];
            string egyeb = reszek[3];

            if (tipus == "T")
            {
                _szemelyLista.Hozzaad(new Tanar(oktatsiAzonosito, nev, egyeb));
            }
            else if (tipus == "D")
            {
                _szemelyLista.Hozzaad(new Diak(oktatsiAzonosito, nev, egyeb));
            }
        }
    }

    public Halmaz<T> Sorsol<T>(int darab) where T : Szemely
    {
        List<T> tipusSzemelyek = _szemelyLista.Elemek.OfType<T>().ToList();
        
        if (tipusSzemelyek.Count < darab)
        {
            throw new InvalidOperationException(
                $"Nincs elég {typeof(T).Name} típusú személy! Kért: {darab}, Elérhető: {tipusSzemelyek.Count}");
        }

        Halmaz<T> sorsoltak = new Halmaz<T>();
        Random random = new Random();

        while (sorsoltak.Elemszam < darab)
        {
            int index = random.Next(tipusSzemelyek.Count);
            sorsoltak.Hozzaad(tipusSzemelyek[index]);
        }

        return sorsoltak;
    }

    public void MentesJsonba<T>(Halmaz<T> sorsoltak, string fajlNev) where T : Szemely
    {
        JsonSerializerOptions options = new JsonSerializerOptions 
        { 
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        
        string json = JsonSerializer.Serialize(sorsoltak.Elemek, options);
        File.WriteAllText(fajlNev, json);
    }

    public int TanarokSzama() => _szemelyLista.Elemek.OfType<Tanar>().Count();

    public int DiakoSzama() => _szemelyLista.Elemek.OfType<Diak>().Count();
}
