using Footgolf_VB_Lib;

namespace Footgolf_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Competitors competitors = new(File.ReadAllLines("fob2016.txt"));

            Console.WriteLine($"3. feladat: Versenyzők száma: {competitors.Count}");
        }
    }
}
