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
            Console.WriteLine($"Átlagosan {jatekok.AtlagIdoMegjelenesEsNapjainkKozott} év telik el egy játék megjelenése és napjaink között.");

            //4. feladat
            //void WriteToFile(string fileName)
            //{
            //    StreamWriter streamWriter = new StreamWriter(fileName);


            //}

            Console.WriteLine("\n5. feladat:");
            Console.Write("Kérem adjon meg egy játéknevet: ");
            string jatekNev = Console.ReadLine()!;
            if (jatekNev != String.Empty)
            {
                Jatek talalat = jatekok.JatekKeresesNevAlapjan(jatekNev);

                Console.WriteLine($"\tNév: {talalat.Nev}");
                Console.WriteLine($"\tMűfaj: {talalat.Mufaj}");
                Console.WriteLine($"\tMegjelenés ideje: {talalat.MegjelenesIdeje}");
                Console.WriteLine($"\tAktív játékosok: {talalat.AktivJatekosok} ezer fő");
            }

            Console.WriteLine("\n6. feladat:");
            Jatek legregebbenMegjelent = jatekok.LegregebbiJatekAdatai;
            Console.WriteLine($"A legrégebben megjelent játék: {legregebbenMegjelent.Nev} - {legregebbenMegjelent.Mufaj} ({legregebbenMegjelent.MegjelenesIdeje}) - {legregebbenMegjelent.AktivJatekosok} ezer fő");

            Console.WriteLine("\n7. feladat:");
            Console.WriteLine($"Több, mint 100 ezer aktív játékossal rendelkező játékok: {jatekok.TobbMintXAktivJatekosString(100)}");
        }
    }
}
