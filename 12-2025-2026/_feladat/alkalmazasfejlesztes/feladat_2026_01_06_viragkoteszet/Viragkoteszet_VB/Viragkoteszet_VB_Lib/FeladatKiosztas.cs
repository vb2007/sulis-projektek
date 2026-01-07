namespace Viragkoteszet_VB_Lib;

public class FeladatKiosztas
{
    public static void FeladatokKiosztasa(Dolgozok dolgozok, Termekek termekek, string feladatkiosztasFajl, string hibalistaFajl)
    {
        List<string> hibalista = new List<string>();
        
        string[] sorok = File.ReadAllLines(feladatkiosztasFajl);
        
        for (int i = 1; i < sorok.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(sorok[i])) continue;
            
            string[] adatok = sorok[i].Split(';');
            int dolgozoId = int.Parse(adatok[0]);
            int termekId = int.Parse(adatok[1]);
            
            try
            {
                Dolgozo dolgozo = dolgozok[dolgozoId];
                Termek termek = termekek[termekId];
                dolgozo.UjFeladatHozzaadasa(termek);
            }
            catch (HibasFeladatException ex)
            {
                hibalista.Add($"{ex.Message} DolgozoID: {dolgozoId}, TermekID: {termekId}");
            }
        }
        
        if (hibalista.Count > 0)
        {
            File.WriteAllLines(hibalistaFajl, hibalista);
        }
    }
}