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
        
        
    }
}