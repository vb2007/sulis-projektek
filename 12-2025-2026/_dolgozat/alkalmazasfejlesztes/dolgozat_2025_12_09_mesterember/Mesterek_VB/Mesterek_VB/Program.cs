using Mesterek_VB_Lib;

namespace Mesterek_VB;

class Program
{
    static void Main(string[] args)
    {
        List<MesterEmber> mesterek = new List<MesterEmber>();

        try
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("HIBA: A(z) input.txt fájl nem található!");
                return;
            }
            
            IEnumerable<string> adatSorok = File.ReadAllLines("input.txt");

            foreach (string adatSor in adatSorok)
            {
                try
                {
                    MesterEmber mesterEmber = MesterFactory.Factory(adatSor);
                    mesterek.Add(mesterEmber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"HIBA az adatsor feldolgozása során: {adatSor}");
                }
            }
            
            using (StreamWriter sw = new StreamWriter("megrendelesek.txt"))
            {
                foreach (MesterEmber mester in mesterek)
                {
                    int megrendelesekSzama = mester is Burkolo ? 25 : 10;

                    for (int i = 1; i <= megrendelesekSzama; i++)
                    {
                        int veletlenNap = Random.Shared.Next(1, 32);

                        try
                        {
                            bool eredmeny = mester.MunkatVallal(veletlenNap);
                            
                            if (eredmeny)
                            {
                                sw.WriteLine($"Megrendelés #{i}: {veletlenNap}. nap - SIKERES");
                            }
                            else
                            {
                                sw.WriteLine($"Megrendelés #{i}: {veletlenNap}. nap - A NAP MÁR FOGLALT");
                            }
                        }
                        catch (TulSokElfoglaltsagException ex)
                        {
                            sw.WriteLine($"Megrendelés #{i}: {veletlenNap}. nap - KIVÉTEL: {ex.Message}");
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            sw.WriteLine($"Megrendelés #{i}: {veletlenNap}. nap - HIBA: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            sw.WriteLine($"Megrendelés #{i}: {veletlenNap}. nap - VÁRATLAN HIBA: {ex.Message}");
                        }
                    }

                    sw.WriteLine();
                    sw.WriteLine($"Végső állapot: {mester.ToString()}");
                    sw.WriteLine(new string('-', 50));
                    sw.WriteLine();
                }

                Console.WriteLine("Adatok sikeresen kiírva a fájlba.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HIBA futás közben: {ex.Message}");
            Console.WriteLine($"Hibatípus: {ex.GetType().Name}");
        }
        
    }
}