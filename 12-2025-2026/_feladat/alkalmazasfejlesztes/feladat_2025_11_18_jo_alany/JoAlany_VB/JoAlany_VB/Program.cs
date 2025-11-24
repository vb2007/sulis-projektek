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

        Nyilvantartas szemelyek = new(SzemelyAdatok());
        for (int i = 1; i <= szemelyek.Elemszam; i++)
        {
            Console.WriteLine(szemelyek[i]);
        }

        Console.WriteLine($"Tanárok száma: {szemelyek.OsszesTaroltTanar().Count()}");
        Console.WriteLine($"Diákok száma: {szemelyek.OsszesTaroltDiak().Count()}");

        Console.WriteLine($"Tanárok átlagos életkora: {szemelyek.OsszesTaroltTanar().Average(x => x.Kor):0.00}");

        foreach (var item in szemelyek.OsszesTaroltDiak().Cast<Diak>().GroupBy(x => x.PuskakSzama))
        {
            Console.WriteLine($"{item.Key} - {item.Count()}");
        }
    }
}