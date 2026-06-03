using LeapYearTDD_VB_Library;

namespace LeapYearTDD_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Adjon meg egy évet: ");
        
        int year = int.Parse(Console.ReadLine() ?? "0");
        
        if (LeapYear.IsLeapYear(year))
        {
            Console.WriteLine($"{year}: szökőév.");
        }
        else
        {
            Console.WriteLine($"{year}: NEM szökőév.");
        }
    }
}