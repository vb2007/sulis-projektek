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
                MesterEmber mesterEmber = MesterFactory.Factory(adatSor);
                mesterek.Add(mesterEmber);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HIBA futás közben: {ex.Message}");
            Console.WriteLine($"Hibatípus: {ex.GetType().Name}");
        }
        
    }
}