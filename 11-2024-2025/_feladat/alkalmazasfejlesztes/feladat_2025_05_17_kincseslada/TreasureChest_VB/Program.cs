using TreasureChest_VB_Lib;

namespace TreasureChest_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreasureFactory treasureFactory = new();
            List<ITreasure> treasures = new();

            for (int i = 0; i < 10; i++)
            {
                treasures.Add(treasureFactory.Create());
            }

            Console.WriteLine("A kincsesláda tartalma:");
            foreach (var treasure in treasures)
            {
                Console.WriteLine($"\t{treasure.Description}");
            }
        }
    }
}
