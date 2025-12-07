using TortOsztaly_VB_Lib;

namespace TortOsztaly_VB;

class Program
{
    static void Main(string[] args)
    {
        Tort t1 = new Tort();
        Console.WriteLine($"Paraméter nélküli konstruktor: t1 = {t1}");
        
        Console.WriteLine("\nParaméteres konstruktor:");
        Tort t2 = new Tort(3, 4);
        Tort t3 = new Tort(6, 8); //egyszerűsítés ->3/4
        Console.WriteLine($"t2 = {t2}");
        Console.WriteLine($"t3 = {t3} (egyszerűsítve 6/8-ból)");

        Console.WriteLine("\nNegatív érték kezelés:");
        Tort t4 = new Tort(-2, 3);
        Tort t5 = new Tort(2, -3);
        Tort t6 = new Tort(-2, -3);
        Console.WriteLine($"t4 = {t4} (-2/3)");
        Console.WriteLine($"t5 = {t5} (2/-3)");
        Console.WriteLine($"t6 = {t6} (-2/-3 = 2/3)");

        Console.WriteLine("\nTizedestört alak:");
        Console.WriteLine($"t2 tizedestört alakban: {t2.TizedesErtek}");

        Console.WriteLine("Alapműveletek [tört - tört]:");
        Console.WriteLine($"{t2} + {t3} = {t2 + t3}");
        Console.WriteLine($"{t2} - {t3} = {t2 - t3}");
        Console.WriteLine($"{t2} * {t3} = {t2 * t3}");
        Console.WriteLine($"{t2} / {t3} = {t2 / t3}");

        Console.WriteLine("\nAlapműveletek [tört - egész]:");
        Console.WriteLine($"{t2} + 2 = {t2 + 2}");
        Console.WriteLine($"2 + {t2} = {2 + t2}");
        Console.WriteLine($"{t2} - 1 = {t2 - 1}");
        Console.WriteLine($"{t2} * 3 = {t2 * 3}");
        Console.WriteLine($"{t2} / 2 = {t2 / 2}");

        Console.WriteLine("\nÖsszehasonlítás:");
        Console.WriteLine($"{t2} == {t3}: {t2 == t3}");
        Console.WriteLine($"{t2} != {t3}: {t2 != t3}");
        Console.WriteLine($"{t2} > {t4}: {t2 > t4}");
        Console.WriteLine($"{t2} < {t4}: {t2 < t4}");

        Console.WriteLine("\nImplicit koverziók:");
        Tort t7 = 5; //int -> tört
        Console.WriteLine($"Tort t7 = 5: {t7}");
        
        Tort t8 = 0.5; //double -> tört
        Console.WriteLine($"Tort t8 = 0.5: {t8}");
        
        double d = t2; //tört -> double
        Console.WriteLine($"double d = t2: {d}");
        
        Console.WriteLine($"\nExplicit konverzió:");
        Tort t9 = new Tort(7, 3); //7/3 = 2.3..
        int egeszErtek = (int)t9;
        Console.WriteLine($"{t9} egésszé kerekítve: {egeszErtek}");

        Console.WriteLine($"\nHibakezelés:");
        try
        {
            Tort hibas = new Tort(1, 0);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"HIBA: {e.Message}");
        }

        try
        {
            Tort nulla = new Tort(0, 1);
            Tort eredmeny = t2 / nulla;
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"HIBA: {e.Message}");
        }
    }
}
