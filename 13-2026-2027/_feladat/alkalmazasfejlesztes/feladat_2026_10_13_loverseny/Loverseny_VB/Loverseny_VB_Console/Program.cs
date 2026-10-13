using Loverseny_VB_Lib;

namespace Loverseny_VB_Console
{
    internal class Program
    {
        static IEnumerable<string> Beolvas(string fajlnev) =>
            File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "sources", fajlnev)).Skip(1);

        static void Main(string[] args)
        {
            AdatFactory adatok = new AdatFactory(
                Beolvas("helyszin.csv"),
                Beolvas("lo.csv"),
                Beolvas("verseny.csv"),
                Beolvas("verseny_tipus.csv")
            );
        }
    }
}
