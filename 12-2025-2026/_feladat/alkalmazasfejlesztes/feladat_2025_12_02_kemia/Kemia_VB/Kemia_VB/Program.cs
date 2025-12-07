using Kemia_VB_Lib;

namespace Kemia_VB;

class Program
{
    static void Main(string[] args)
    {
        string[] nemesgazok = { "He", "Ne", "Ar", "Kr", "Xe", "Rn" };

        string[] fajlok = { "viz.txt", "szolocukor.txt" };
        foreach (string fajl in fajlok)
        {
            try
            {
                Vegyulet vegyulet = new Vegyulet();

                if (!File.Exists(fajl))
                {
                    Console.WriteLine($"HIBA: A(z) '{fajl}' fájl nem található!");
                    continue;
                }

                string[] sorok = File.ReadAllLines(fajl);
                foreach (string sor in sorok)
                {
                    string[] reszek = sor.Split('\t');

                    if (reszek.Length != 4)
                    {
                        Console.WriteLine($"HIBA: Hibás sor formátum: {sor}");
                        continue;
                    }

                    string vegyjel = reszek[0].Trim();
                    int rendszam = int.Parse(reszek[1].Trim());
                    int focsoport = int.Parse(reszek[2].Trim());
                    int mennyiseg = int.Parse(reszek[3].Trim());

                    KemiaiElem elem;
                    if (Array.Exists(nemesgazok, x => x == vegyjel))
                    {
                        elem = new NemesGaz(vegyjel, rendszam, focsoport);
                    }
                    else
                    {
                        elem = new NemFem(vegyjel, rendszam, focsoport);
                    }

                    vegyulet.ElemHozzaad(elem, mennyiseg);
                }

                Console.WriteLine(vegyulet.ToString());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"HIBA: A fájl nem található: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"HIBA: Hibás számformátum a fájlban: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"HIBA: Érvénytelen argument: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HIBA: Ismeretlen hiba történt: {ex.Message}");
            }
        }
    }
}
