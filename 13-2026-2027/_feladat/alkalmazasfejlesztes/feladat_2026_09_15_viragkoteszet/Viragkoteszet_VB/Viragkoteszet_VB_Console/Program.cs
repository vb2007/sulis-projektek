using Viragkoteszet_VB_Lib;

namespace Viragkoteszet_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a. forrásállományok beolvasása és feldolgozása
            string forras = Path.Combine(AppContext.BaseDirectory, "source");

            Katalogus katalogus = AdatBeolvaso.AlapanyagokBeolvasasa(
                File.ReadAllLines(Path.Combine(forras, "alapanyagok.txt")));
            Termekek termekek = AdatBeolvaso.TermekekBeolvasasa(
                File.ReadAllLines(Path.Combine(forras, "termekek.txt")), katalogus);
            Dolgozok dolgozok = new MunkaeroFelvetel().Felvesz(
                File.ReadAllLines(Path.Combine(forras, "dolgozok.txt")));

            new FeladatKiosztas(dolgozok, termekek).Kioszt(
                File.ReadAllLines(Path.Combine(forras, "feladatkiosztas.txt")),
                Path.Combine(AppContext.BaseDirectory, "hibalista.txt"));

            // b. elkészíthető termékek
            Console.WriteLine("Elkészíthető termékek:");
            Console.WriteLine(termekek);

            // c. dolgozónként a munkával töltött idő
            Console.WriteLine();
            Console.WriteLine($"Dolgozók ({dolgozok.Darabszam} fő):");
            foreach (Dolgozo dolgozo in dolgozok)
            {
                Console.WriteLine(dolgozo);
            }
        }
    }
}
