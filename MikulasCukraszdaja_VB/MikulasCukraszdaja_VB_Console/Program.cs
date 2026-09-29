using MikulasCukraszdaja_VB_Lib;

namespace MikulasCukraszdaja_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeszitesiAdatok keszitesiAdatok = new KeszitesiAdatok(File.ReadAllLines("keszites.txt").Skip(1));

            Console.WriteLine($"Elérhető sütemény készítési azonosítók: { string.Join("; ", keszitesiAdatok.ElerhetoKeszitesAzonositok)}");
        }
    }
}
