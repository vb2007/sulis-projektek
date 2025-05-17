using TreasureChest_VB_Lib;

namespace TreasureChest_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //10 kincset generál a paraméter alapján
            TreasureFactory treasureFactory = new TreasureFactory(10);

            Console.WriteLine("A kincsesláda tartalma:");
            foreach (var treasure in treasureFactory)
            {
                Console.WriteLine($"\t{treasure.Description}");
            }

            Console.WriteLine($"A kincsesláda értéke: {treasureFactory.TotalValue}");

            Console.WriteLine("A kincsesláda tartalma, név szerinte csoportosítva:");
            foreach (var kvp in treasureFactory.ContentByName)
            {
                Console.WriteLine($"\t{kvp.Key}: {kvp.Value} db");
            }

            Console.WriteLine();
        }
    }
}
