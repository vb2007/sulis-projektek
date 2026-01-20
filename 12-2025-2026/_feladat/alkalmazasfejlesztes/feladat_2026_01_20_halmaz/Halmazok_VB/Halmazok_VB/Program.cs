using Halmazok_VB_Lib;

namespace Halmazok_VB;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Milyen típusú sorsolást szeretnél?");
        Console.WriteLine("1: Ötös lottó");
        Console.WriteLine("2: Hatos lottó");
        Console.WriteLine("3: Skandináv lottó");
        
        Console.Write("\nVálasztásod (1-3): ");
        string valasztas = Console.ReadLine()!;

        int darab = 0;
        int maximum = 0;
        string tipusNev = "";

        switch (valasztas)
        {
            case "1":
                darab = 5;
                maximum = 90;
                tipusNev = "Ötös lottó";
                break;
            case "2":
                darab = 6;
                maximum = 45;
                tipusNev = "Hatos lottó";
                break;
            case "3":
                darab = 7;
                maximum = 35;
                tipusNev = "Skandináv lottó";
                break;
            default:
                Console.WriteLine("Érvénytelen választás!");
                return;
        }

        RendezettHalmaz<int> nyeroszamok = new RendezettHalmaz<int>();
        Random rnd = new Random();

        while (nyeroszamok.Elemszam < darab)
        {
            int huzottSzam = rnd.Next(1, maximum + 1);
            
            nyeroszamok.Hozzaad(huzottSzam);
        }

        Console.WriteLine($"A \"{tipusNev}\" kisorsolt nyerőszámai növekvő sorrendben:");
        Console.WriteLine(nyeroszamok.ToString());
        
        Console.ReadKey();
    }
}