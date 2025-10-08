using System.Diagnostics;

namespace TesztKiertekeles_VB;

using TesztKiertekeles_VB_Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = null!;
        Tests tests = null!;
        
        //1. Feladat
        bool validInput = false;
        while (!validInput)
        {
            Console.Write("Adja meg hanyadik csoport eredményeire kíváncsi (1/2): ");
            
            input = Console.ReadLine()!;
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

        if (!tests.WasTheTestWritten)
        {
            Console.WriteLine("A fájl létezik, de a csoport még nem írta meg a tesztet.");
            return;
        }
        else
        {
            Console.WriteLine($"{tests.Count} tanuló volt tervezve a tesztre, ebből {tests.AbsenceCount} nem írta meg a tesztet.");
        }
        
        //2. Feladat
        Console.Write("Adj meg egy nevet: ");
        string studentNameInput = Console.ReadLine()!;
        Test testData = tests.TestDataByStudentName(studentNameInput);
        Console.WriteLine(testData == null! ? $"Nem volt \"{studentNameInput}\" nevű tanuló a csoportban, aki tesztet írt volna.": testData.ToString() + "\n");
        
        //3. Feladat
        Console.WriteLine(tests.TaskDataString);
        
        //4. Feladat
        Console.WriteLine(tests.WriteToFile($"szazalek{input}.csv"));
    }
}