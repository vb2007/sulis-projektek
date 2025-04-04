using GroupByLib;

namespace GroupBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Diakok vizsga = new(File.ReadLines("input.txt"));

            foreach (var item in vizsga.Lista)
            {
                Console.WriteLine($"{item.Osztaly}");
            }

            foreach (var item in vizsga.OsztalyLetszam)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
