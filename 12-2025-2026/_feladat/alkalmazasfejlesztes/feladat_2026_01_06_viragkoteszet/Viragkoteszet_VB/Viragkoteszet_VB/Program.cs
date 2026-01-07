using Viragkoteszet_VB_Lib;

namespace Viragkoteszet_VB;

class Program
{
    static void Main(string[] args)
    {
        List<Alapanyag> alapanyagLista = new List<Alapanyag>();
        string[] alapanyagSorok = File.ReadAllLines("alapanyagok.txt");
        
        for (int i = 1; i < alapanyagSorok.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(alapanyagSorok[i])) continue;
            
            string[] adatok = alapanyagSorok[i].Split(';');
            Alapanyag alapanyag = new Alapanyag(
                adatok[0], 
                adatok[1], 
                int.Parse(adatok[2]), 
                int.Parse(adatok[3])
            );
            alapanyagLista.Add(alapanyag);
        }
        
        Katalogus katalogus = new Katalogus(alapanyagLista);
        
        List<Termek> termekLista = new List<Termek>();
        string[] termekSorok = File.ReadAllLines("termekek.txt");
        
        for (int i = 1; i < termekSorok.Length; i++)
        {
            string[] adatok = termekSorok[i].Split(';');
            int id = int.Parse(adatok[0]);
            string tipus = adatok[1];
            string megnevezes = adatok[2];
            
            List<(Alapanyag, int)> alapanyagok = new List<(Alapanyag, int)>();
            for (int j = 3; j < adatok.Length; j += 2)
            {
                if (j + 1 < adatok.Length)
                {
                    string alapanyagAzonosito = adatok[j];
                    int mennyiseg = int.Parse(adatok[j + 1]);
                    Alapanyag alapanyag = katalogus[alapanyagAzonosito];
                    alapanyagok.Add((alapanyag, mennyiseg));
                }
            }
            
            Termek termek = new Termek(id, tipus, megnevezes, alapanyagok);
            termekLista.Add(termek);
        }
        
        Termekek termekek = new Termekek(termekLista);
        
        List<Dolgozo> dolgozoLista = new List<Dolgozo>();
        string[] dolgozoSorok = File.ReadAllLines("dolgozok.txt");
        for (int i = 1; i < dolgozoSorok.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(dolgozoSorok[i])) continue;
            
            string[] adatok = dolgozoSorok[i].Split(';');
            Dolgozo dolgozo = MunkaeroFelvetel.DolgozoLetrehozasa(adatok);
            dolgozoLista.Add(dolgozo);
        }
        Dolgozok dolgozok = new Dolgozok(dolgozoLista);
        
        FeladatKiosztas.FeladatokKiosztasa(dolgozok, termekek, "feladatkiosztas.txt", "hibalista.txt");
        
        Console.WriteLine("Elkészíthető termékek:");
        Console.WriteLine(termekek.ToString());
        Console.WriteLine();
        
        Console.WriteLine("Dolgozók munkaideje:");
        foreach (Dolgozo dolgozo in dolgozok.DolgozoLista)
        {
            Console.WriteLine(dolgozo.ToString());
        }
    }
}