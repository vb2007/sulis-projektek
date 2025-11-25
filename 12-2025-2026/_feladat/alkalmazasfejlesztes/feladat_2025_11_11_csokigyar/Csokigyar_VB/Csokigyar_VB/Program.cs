using Csokigyar_VB_Lib;

namespace Csokigyar_VB;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<IEtel> Feltoltes(string fajlNev)
        {
            if (!File.Exists(fajlNev))
            {
                throw new FileNotFoundException($"A(z) \"{fajlNev}\" állomány nem található!");
            }

            EtelFactory etelFactory = new EtelFactory();
            foreach (var item in File.ReadAllLines(fajlNev).Skip(1))
            {
                yield return etelFactory.Factory(item);
            }
        }

        void CsokiEllenorzes(IEnumerable<IEtel> csokik)
        {
            foreach (IEtel item in csokik)
            {
                try
                {
                    Console.WriteLine($"{item} - {(item.MegfeleloMinoseg ? "jó" : "rossz")} minőségű");
                }
                catch (SilanyMinosegException ex)
                {
                    Console.WriteLine($"Hiba a csokiellenőrzés közben: {ex.Message}");
                }
            }
        }

        try
        {
            List<IEtel> csokik = Feltoltes("input.txt").ToList();
            CsokiEllenorzes(csokik);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Hiba a csokik feldolgozása közben: {ex.Message}");
        }
    }
}