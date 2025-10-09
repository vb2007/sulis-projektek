namespace Forma1_VB;
using Forma1_VB_Lib;

class Program
{
    static void Main(string[] args)
    {
        Races races = new Races(File.ReadAllLines("eredmenyek.csv").Skip(1));
        
        //2. Feladat
        Console.WriteLine("2. feladat: Hill Vezetéknevűek:");
        IEnumerable<Race> hillRacers = races.RacersByName(" Hill");
        foreach (var racer in hillRacers)
        {
            Console.WriteLine($"\t{racer.Name} ({racer.Nationality}) {racer.BirthDate?.ToString(Race.HungarianCulture)}");
        }
        
        //3. Feladat
        Console.WriteLine("3. feladat: futamgyőztesek:");
        IEnumerable<string> raceWinners = races.RaceWinners;
        foreach (var racerName in raceWinners)
        {
            Console.WriteLine($"\t{racerName}");
        }
    }
}