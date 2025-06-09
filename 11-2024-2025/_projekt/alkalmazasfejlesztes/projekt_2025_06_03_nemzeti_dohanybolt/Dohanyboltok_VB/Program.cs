using Dohanyboltok_VB_Lib;

namespace Dohanyboltok_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TobaccoStores tobaccoStores = new(File.ReadAllLines("tobaccostores.txt").Skip(1));

            Console.WriteLine($"7. feladat: Összesen {tobaccoStores.Count} dohánybolt adatai vannak eltárolva.");
        }
    }
}
