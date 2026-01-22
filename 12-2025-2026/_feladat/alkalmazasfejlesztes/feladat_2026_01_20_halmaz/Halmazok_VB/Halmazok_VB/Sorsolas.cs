using Halmazok_VB_Lib;

namespace Halmazok_VB;

public class Sorsolas
{
    public virtual void Execute()
    {
        Console.WriteLine("Milyen típusú sorsolást szeretnél?");
        Console.WriteLine("1: Ötös lottó");
        Console.WriteLine("2: Hatos lottó");
        Console.WriteLine("3: Skandináv lottó");
        
        Console.Write("\n1-3: ");
        string valasztas = Console.ReadLine()!;

        int darab;
        int maximum;
        string tipusNev;

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

        while (nyeroszamok.Elemszam < darab)
        {
            int huzottSzam = Random.Shared.Next(1, maximum + 1);
            
            nyeroszamok.Hozzaad(huzottSzam);
        }

        Console.WriteLine($"A \"{tipusNev}\" kisorsolt nyerőszámai növekvő sorrendben:");
        Console.WriteLine(nyeroszamok.ToString());
    }
}