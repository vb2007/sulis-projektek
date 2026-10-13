using Busztarsasag_VB_Lib;

namespace Busztarsasag_VB_Console;

internal class Program
{
    static void Main(string[] args)
    {
        string[] megallok = ["Aluljáró", "Piac", "Vasútállomás"];
        BuszFlotta flotta = new BuszFlotta([new Busz("ABC-123", 30), new Busz("DEF-456", 10)], megallok);

        // rendszám, megálló, leszállók, várakozók
        (string, string, int, int)[] esemenyek =
        [
            ("ABC-123", "Aluljáró", 0, 20),
            ("ABC-123", "Piac", 5, 25),
            ("ABC-123", "Vasútállomás", 30, 4),
            ("DEF-456", "Aluljáró", 0, 15),
            ("DEF-456", "Piac", 3, 2),
        ];

        foreach (var (rendszam, megallo, le, varakozok) in esemenyek)
        {
            int lentmaradt = flotta.Megall(rendszam, megallo, le, varakozok);
            Console.WriteLine($"{rendszam} @ {megallo}: leszállt {le}, várakozott {varakozok}, lent maradt {lentmaradt}");
        }

        Console.WriteLine();
        foreach (string megallo in megallok)
        {
            Console.WriteLine($"{megallo}: felszállt {flotta.Felszallt(megallo)}, leszállt {flotta.Leszallt(megallo)}, lent maradt {flotta.Lentmaradt(megallo)}");
        }

        Console.WriteLine();
        foreach (string rendszam in new[] { "ABC-123", "DEF-456" })
        {
            Console.WriteLine($"{rendszam}: összesen {flotta.OsszesSzallitott(rendszam)} utast szállított");
        }

        flotta.NapVege();
    }
}
