using Halmazok_VB_Lib;

namespace Halmazok_VB;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("A sorsolás (1), vagy a kérdőív (2) programot szeretnéd futtatni? ");
        string valasztas = Console.ReadLine()!;

        switch (valasztas)
        {
            case "1":
                new Sorsolas().Execute();
                break;
            case "2":
                new Kerdoiv().Execute();
                break;
            default:
                Console.WriteLine("Érvénytelen választás!");
                break;
        }
    }
}