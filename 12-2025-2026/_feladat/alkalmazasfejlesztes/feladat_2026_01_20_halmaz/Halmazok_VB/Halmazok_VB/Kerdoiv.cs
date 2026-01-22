using Halmazok_VB_Lib.Kerdoiv;
using Halmazok_VB_Lib.Sorsolas;

namespace Halmazok_VB;

public class Kerdoiv
{
    public void Execute()
    {
        KerdoivSorsolas sorsolas = new KerdoivSorsolas();
        
        try
        {
            sorsolas.AdatokBetoltese("adatok.txt");
            Console.WriteLine($"Tanárok: {sorsolas.TanarokSzama()}, Diákok: {sorsolas.DiakoSzama()}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba az adatok betöltésekor: {ex.Message}");
            return;
        }

        Console.WriteLine("Lehetőségek:");
        Console.WriteLine("1: Új sorsolás");
        Console.WriteLine("0: Kilépés");
        Console.Write("\nVálasztás: ");
        
        string valasztas = Console.ReadLine()!;
        Console.WriteLine();

        switch (valasztas)
        {
            case "1":
                UjSorsolas(sorsolas);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Érvénytelen választás!\n");
                return;
        }
    }

    private void UjSorsolas(KerdoivSorsolas sorsolas)
    {
        Console.WriteLine("Mit szeretnél sorsolni?");
        Console.WriteLine("1: Tanárokat");
        Console.WriteLine("2: Diákokat");
        Console.Write("\nVálasztás: ");
        
        string tipus = Console.ReadLine()!;

        Console.Write("Hány személyt szeretnél sorsolni? ");
        if (!int.TryParse(Console.ReadLine(), out int darab) || darab <= 0)
        {
            Console.WriteLine("Érvénytelen szám!\n");
            return;
        }

        try
        {
            if (tipus == "1")
            {
                var sorsoltak = sorsolas.Sorsol<Tanar>(darab);
                MegjelenitesSorsolas("Tanárok", sorsoltak);
                MentesFelajanlas(sorsolas, sorsoltak);
            }
            else if (tipus == "2")
            {
                var sorsoltak = sorsolas.Sorsol<Diak>(darab);
                MegjelenitesSorsolas("Diákok", sorsoltak);
                MentesFelajanlas(sorsolas, sorsoltak);
            }
            else
            {
                Console.WriteLine("Érvénytelen választás!\n");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Hiba: {ex.Message}\n");
        }
    }

    private void MegjelenitesSorsolas<T>(string tipusNev, Halmaz<T> sorsoltak) where T : Szemely
    {
        Console.WriteLine($"\nKisorsolt {tipusNev.ToLower()}:");
        Console.WriteLine(new string('-', 50));
        
        foreach (var szemely in sorsoltak)
        {
            Console.WriteLine(szemely);
        }
        
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"Összesen: {sorsoltak.Elemszam} fő\n");
    }

    private void MentesFelajanlas<T>(KerdoivSorsolas sorsolas, Halmaz<T> sorsoltak) where T : Szemely
    {
        Console.Write("Szeretnéd elmenteni a sorsolást? (i/n): ");
        string valasz = Console.ReadLine()!.ToLower();
        
        if (valasz == "i")
        {
            Console.Write("Add meg a fájl nevét (pl. sorsolas.json): ");
            string fajlNev = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(fajlNev))
            {
                fajlNev = "sorsolas.json";
            }
            
            if (!fajlNev.EndsWith(".json"))
            {
                fajlNev += ".json";
            }

            try
            {
                sorsolas.MentesJsonba(sorsoltak, fajlNev);
                Console.WriteLine($"Sorsolás sikeresen elmentve: {fajlNev}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a mentés során: {ex.Message}");
            }
        }
    }
}