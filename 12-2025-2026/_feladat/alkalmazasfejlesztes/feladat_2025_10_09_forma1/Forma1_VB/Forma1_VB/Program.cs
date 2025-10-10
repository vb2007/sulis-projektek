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
        
        //4. Feladat
        string name = "Juan-Manuel Fangio";
        Console.WriteLine($"4. feladat: {name} {races.RacerAgeByNameOnFirstRace(name)} éves volt az első versenyén");
        
        //5. Feladat
        string carType = "Ferrari";
        Console.WriteLine($"5. feladat: {carType}knál 3 leggyakoribb hiba:");
        IDictionary<string, int> mostCommonErrorsByCarType = races.MostCommonErrorsByCarType(carType);
        foreach (var error in mostCommonErrorsByCarType)
        {
            Console.WriteLine($"\t{error.Key}: {error.Value} eset");
        }
        
        //6. Feladat
        Console.WriteLine($"{races.RacersWithoutTeam} olyan versenyző volt, akinek valamelyik versenyén nem volt csapata");
        
        //7. Feladat
        //Add meg, hogy mely országok kerültek a rendezők közé az első magyarországi nagydíjat követően!
        //passz, nem volt Magyarországi verseny a forrásfájlban, így nem tudom megoldani
    }
}