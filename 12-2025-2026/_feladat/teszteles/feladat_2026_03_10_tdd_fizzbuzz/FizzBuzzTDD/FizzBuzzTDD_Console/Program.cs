using FizzBuzzTDD_Lib;

namespace FizzBuzzTDD_Console;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Szám: ");
        int input = int.Parse(Console.ReadLine()!);

        string result = FizzBuzz.FizzBuzzCheck(input);
        Console.WriteLine($"Eredmény: {result}");
    }
}