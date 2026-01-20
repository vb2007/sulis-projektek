using Password_VB_Lib;

namespace Password_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Adj meg egy jelszót: ");
        string input = Console.ReadLine()!;
        
        bool isValid = Password.IsValid(input);

        Console.WriteLine($"A megadott jelszó {(isValid ? "érvényes" : "érvénytelen")}.");
    }
}