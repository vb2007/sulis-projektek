using JoAlany_VB_Lib;

namespace JoAlany_VB;

class Program
{
    static void Main(string[] args)
    {
        static IEnumerable<Szemely> SzemelyAdatok()
        {
            if (!File.Exists("input.txt"))
            {
                throw new FileNotFoundException("A fájl nem található!");
            }
            else
            {
                foreach (var item in File.ReadAllLines("input.txt"))
                {
                    Szemely? szemely = null;
                    
                    try
                    {
                        szemely = SzemelyFactory.CreateSzemely(item);
                    }
                    catch (HibasEletkorException ex)
                    {
                        Console.WriteLine($"Hiba a személy feldolgozása közben: {ex.Message}");
                    }

                    if (szemely != null)
                    {
                        //yield = addig returnöl, amíg van adat aka. "többszörös return"
                        yield return szemely;
                    }
                }
            }
        }

        Nyilvantartas szemelyek = new(SzemelyAdatok());
        
    }
}