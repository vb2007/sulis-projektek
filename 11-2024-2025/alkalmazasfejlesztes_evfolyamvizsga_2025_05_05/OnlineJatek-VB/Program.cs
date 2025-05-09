using OnlineJatek_VB_Lib;

namespace OnlineJatek_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jatekok jatekok = new(File.ReadAllLines("jatekok.csv").Skip(1));

            Console.WriteLine("1. feladat:");
            Console.WriteLine($"Júliusban {jatekok.HanyszorJelentEgyHonapban(07)} db játék jelent meg.");

            Console.WriteLine("\n2. feladat:");
            Jatek legtobbAktivJatekos = jatekok.LegtobbAktivJatekos;
            Console.WriteLine($"A legtöbb aktív játékossal rendelkező játék: {legtobbAktivJatekos.Nev} - {legtobbAktivJatekos.Mufaj} ({legtobbAktivJatekos.MegjelenesIdeje}) - {legtobbAktivJatekos.AktivJatekosok} ezer fő");

            Console.WriteLine("\n3. feladat:");
            Console.WriteLine($"Átlagosan {jatekok.AtlagosMegjelenesiIdoEvekben} év telik el egy játék megjelenése és napjaink között.");

            Console.WriteLine("\n4. feladat:");
            try
            {
                IDictionary<string, int> mufajStatisztika = jatekok.MufajStatisztika();
                using (StreamWriter writer = new StreamWriter("statisztika.txt"))
                {
                    foreach (var mufaj in mufajStatisztika)
                    {
                        writer.WriteLine($"{mufaj.Key}: {mufaj.Value} darab");
                    }
                }

                Console.WriteLine("Adatok sikeresen kiírva statisztika.txt fájlba.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt a fájl írásakor: {ex.Message}");
            }

            Console.WriteLine("\n5. feladat:");
            Console.Write("Kérem adjon meg egy játéknevet: ");
            string jatekNev = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(jatekNev))
            {
                Jatek? talalat = jatekok.JatekKeresesNevAlapjan(jatekNev);

                if (talalat != null)
                {
                    Console.WriteLine($"\tNév: {talalat.Nev}");
                    Console.WriteLine($"\tMűfaj: {talalat.Mufaj}");
                    Console.WriteLine($"\tMegjelenés ideje: {talalat.MegjelenesIdeje}");
                    Console.WriteLine($"\tAktív játékosok: {talalat.AktivJatekosok} ezer fő");
                }
                else
                {
                    Console.WriteLine("\tNincs ilyen játék az adatbázisban!");
                }
            }

            Console.WriteLine("\n6. feladat:");
            Jatek legregebbenMegjelent = jatekok.LegregebbiJatek;
            Console.WriteLine($"A legrégebben megjelent játék: {legregebbenMegjelent.Nev} - {legregebbenMegjelent.Mufaj} ({legregebbenMegjelent.MegjelenesIdeje}) - {legregebbenMegjelent.AktivJatekosok} ezer fő");

            Console.WriteLine("\n7. feladat:");
            Console.WriteLine($"Több, mint 100 ezer aktív játékossal rendelkező játékok: {jatekok.TobbMintXAktivJatekosString(100)}");

            Console.WriteLine("\n9. feladat:");
            Console.Write("Adjon meg egy műfajt: ");
            string aranykorMufaj = Console.ReadLine()!;
            try
            {
                var (kezdoEv, zaroEv) = jatekok.Aranykor(aranykorMufaj);
                Console.WriteLine($"\tA(z) {aranykorMufaj} műfaj aranykora: {kezdoEv} - {zaroEv}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
