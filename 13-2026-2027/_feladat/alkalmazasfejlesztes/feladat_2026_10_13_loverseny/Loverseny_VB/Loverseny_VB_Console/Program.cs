using Loverseny_VB_Lib;

namespace Loverseny_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdatFactory adatok = new AdatFactory(
                File.ReadAllLines("helyszin.csv"),
                File.ReadAllLines("lo.csv"),
                File.ReadAllLines("verseny.csv"),
                File.ReadAllLines("verseny_tipus.csv")
            );
        }
    }
}
