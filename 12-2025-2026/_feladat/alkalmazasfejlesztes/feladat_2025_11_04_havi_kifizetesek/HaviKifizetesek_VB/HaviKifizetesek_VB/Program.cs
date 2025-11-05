using HaviKifizetesek_VB_Lib;

namespace HaviKifizetesek_VB;

class Program
{
    static void Main(string[] args)
    {
        Payouts payouts = new(File.ReadAllLines("lista.csv"));

        Console.WriteLine("3. feladat:");
        foreach (Payout roundedPayout in payouts.RoundedUniquePayouts)
        {
            Console.WriteLine($"\t{roundedPayout.Amount} havi fizetése: {roundedPayout.Amount} Ft.");
        }
        
        Console.WriteLine("\n5. feladat:");
        Console.WriteLine("A dolgozók kifizetéséhez a következő címletekre van szükség:");
        
        Dictionary<int, int> totalDenominations = payouts.GetTotalDenominations();
        foreach (var denomination in totalDenominations.OrderByDescending(x => x.Key))
        {
            Console.WriteLine($"\t{denomination.Value} db {denomination.Key} Ft-os");
        }

        File.WriteAllLines("listaki.csv", payouts.RoundedUniquePayouts.Select(x => $"{x.Monogram};{x.Amount}"));
    }
}
