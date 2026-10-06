using MikulasCukraszdaja_VB_Lib;

namespace MikulasCukraszdaja_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeszitesAdatok keszitesAdatok = new KeszitesAdatok(File.ReadAllLines("keszites.txt").Skip(1));

            Console.WriteLine("Elérhető sütemény készítési azonosítók:" +
                string.Join("; ", keszitesAdatok.ElerhetoKeszitesAzonositok));
        }
    }
}
