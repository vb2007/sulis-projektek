using SuperBowl_VB_Library;

namespace SuperBowl_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        Dontok dontok = new Dontok(File.ReadAllLines("SuperBowl.txt").Skip(1));

        Console.WriteLine($"4. feladat: Döntők száma: {dontok.DontokSzama}");

        Console.WriteLine($"5. feladat: Átlagos pontkülönbség: {dontok.AtlagosPontkulonbseg:0.0}");

        Donto legnezettebb = dontok.LegnezettebbDonto;
        Console.WriteLine("6. feladat: Legmagasabb nézőszám a döntők során:");
        Console.WriteLine($"\tSorszám (dátum): {new RomaiSorszam(legnezettebb.SorszamRomai).ArabSorszam}. ({legnezettebb.Datum})");
        Console.WriteLine($"\tGyőztes csapat: {legnezettebb.Gyoztes}, szerzett pontok: {legnezettebb.GyoztesEredmeny}");
        Console.WriteLine($"\tVesztes: {legnezettebb.Vesztes}, szerzett pontok: {legnezettebb.VesztesEredmeny}");
        Console.WriteLine($"\tHelyszín: {legnezettebb.Helyszin}");
        Console.WriteLine($"\tVáros, állam: {legnezettebb.VarosAllam}");
        Console.WriteLine($"\tNézőszám: {legnezettebb.Nezoszam}");

        dontok.Mentes("SuperBowlNew.txt");
    }
}