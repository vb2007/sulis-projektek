using TreasureChest_VB_Lib;

namespace TreasureChest_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //így 10 kincset generál a paraméter alapján
            TreasureFactory treasureFactory = new TreasureFactory(10);

            Console.WriteLine("A kincsesláda tartalma:");
            foreach (var treasure in treasureFactory)
            {
                Console.WriteLine($"\t{treasure.Description}");
            }

            Console.WriteLine($"A kincsesláda értéke: {treasureFactory.TotalValue}");

            Console.WriteLine("A kincsesláda tartalma, név szerinte csoportosítva:");
            foreach (var treasureDict in treasureFactory.ContentByName)
            {
                Console.WriteLine($"\t{treasureDict.Key}: {treasureDict.Value} db");
            }

            Console.WriteLine("A kincsesláda tartalma típus szerint csoportosítva:");
            foreach (var treasureDict in treasureFactory.ContentByType)
            {
                Console.WriteLine($"\t{treasureDict.Key}: {treasureDict.Value} db");
            }
        }
    }
}
