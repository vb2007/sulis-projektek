using System.Text.Json;
using Alma_VB_Lib;

namespace Alma_VB;

class Program
{
    static void Main(string[] args)
    {
        Alma alma;
        
        string fajlNev = "alma.json";
        try
        {
            alma = JsonSerializer.Deserialize<Alma>(File.ReadAllText(fajlNev))!;
        }
        catch
        {
            alma = new Alma();
        }

        //1. szimuláció verzió
        ConsoleKey keyChar;
        do
        {
            alma.Kor();
            Console.Clear();
            Console.WriteLine(alma.ToString());
            Thread.Sleep(100); //10 mp
            keyChar = Console.ReadKey().Key;
        } while (keyChar != ConsoleKey.Spacebar && alma.EletbenVan); //escape Riderben nem működik

        if (alma.EletbenVan)
        {
            File.WriteAllText(fajlNev, JsonSerializer.Serialize(alma));
        }
        else
        {
            if (File.Exists(fajlNev))
            {
                File.Delete(fajlNev);
            }
        }
    }
}