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
    }
}
