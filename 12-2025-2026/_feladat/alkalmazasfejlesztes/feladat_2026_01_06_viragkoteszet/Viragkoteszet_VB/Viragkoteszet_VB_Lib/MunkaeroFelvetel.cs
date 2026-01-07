namespace Viragkoteszet_VB_Lib;

public class MunkaeroFelvetel
{
    public static Dolgozo DolgozoLetrehozasa(string[] adatok)
    {
        int id = int.Parse(adatok[0]);
        string nev = adatok[1];
        char beosztas = adatok[2][0];
        
        Dolgozo dolgozo;
        
        if (beosztas == 'v') // => virágkötő
        {
            dolgozo = new Viragkoto(id, nev);
        }
        else // beosztas == 'gy' => gyakornok
        {
            List<int> termekAzonositok = new List<int>();
            for (int i = 3; i < adatok.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(adatok[i]))
                {
                    termekAzonositok.Add(int.Parse(adatok[i]));
                }
            }
            dolgozo = new Gyakornok(id, nev, termekAzonositok);
        }
        
        dolgozo.Beosztas = beosztas;
        
        if (adatok.Length > 3)
        {
            for (int i = 3; i < adatok.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(adatok[i]))
                {
                    dolgozo.AlapanyagAzonositok.Add(int.Parse(adatok[i]));
                }
            }
        }
        
        return dolgozo;
    }
}