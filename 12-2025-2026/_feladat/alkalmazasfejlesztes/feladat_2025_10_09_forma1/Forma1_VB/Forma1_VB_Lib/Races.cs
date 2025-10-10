using System.Text;

namespace Forma1_VB_Lib;

public class Races
{
     private readonly List<Race> _races = new();

     public Races(IEnumerable<string> races)
     {
          foreach (var race in races)
          {
               _races.Add(new Race(race));
          }
     }

     public IEnumerable<Race> RacersByName(string name) =>
          _races
               .FindAll(x => x.Name.Contains(name))
               .DistinctBy(x => x.Name)
               .OrderBy(x => x.BirthDate);

     public IEnumerable<string> RaceWinners =>
          _races
               .FindAll(x => x.Position == 1)
               .Select(x => x.Name)
               .Distinct()
               .OrderBy(x => x);

     public int? RacerAgeByNameOnFirstRace(string name) =>
          _races
               .Where(x => x.Name.Contains(name) && x.BirthDate.HasValue)
               .OrderBy(x => x.Date)
               .FirstOrDefault() is var firstRace && firstRace?.BirthDate?.Year is not null and var birthYear
                    ? firstRace.Date.Year - birthYear
                    : null;

     public IDictionary<string, int> MostCommonErrorsByCarType(string carType) =>
          _races
               .Where(x => x.CarType == carType && !string.IsNullOrEmpty(x.Error))
               .GroupBy(x => x.Error)
               .Select(x => new { Error = x.Key!, Count = x.Count() })
               .OrderByDescending(x => x.Count)
               .Take(3)
               .ToDictionary(x => x.Error, x => x.Count);

     public int RacersWithoutTeam =>
          _races
               .GroupBy(x => x.Name)
               .Count(group => group.All(race => string.IsNullOrEmpty(race.Team)));

     private IEnumerable<Race> Top6PositionsByRaceName(string raceCountry) =>
          _races
               .FindAll(x => x.RaceCountry == raceCountry)
               .OrderBy(x => x.Position)
               .Take(6);

     public string WriteToFile(string fileName, string raceCounty)
     {
          try
          {
               using StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);

               IEnumerable<Race> top6Positions = Top6PositionsByRaceName(raceCounty);
               int pos = 1;
               foreach (var racer in top6Positions)
               {
                    sw.WriteLine($"{pos}. {racer.Name} ({racer.CarType})");
                    pos++;
               }

               return $"A \"{raceCounty}\" versenyek adatai sikeresen kiírva a \"{fileName}\" fájlba.";
          }
          catch (Exception ex)
          {
               return $"Hiba történt a \"{fileName}\" fájlba írás közben.";
          }
     }
}
