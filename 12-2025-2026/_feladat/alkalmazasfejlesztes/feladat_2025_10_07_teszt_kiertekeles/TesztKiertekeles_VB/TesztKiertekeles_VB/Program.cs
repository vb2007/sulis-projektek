namespace TesztKiertekeles_VB;

using TesztKiertekeles_VB_Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        Tests tests = null!;
        
        bool validInput = false;
        while (!validInput)
        {
            Console.Write("Adja meg hanyadik csoport eredményeire kíváncsi (1/2): ");
            
            string input = Console.ReadLine()!;
            if (input != "1" && input != "2")
            {
                Console.WriteLine("Nincs ilyen azónosítójú csoport.");
            }
            else
            {
                validInput = true;
                tests = new Tests(File.ReadAllLines($"csoport{input}.csv").Skip(1));
            }
        }
    }
}