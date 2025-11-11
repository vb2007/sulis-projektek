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
    }
}