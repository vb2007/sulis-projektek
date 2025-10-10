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

    private IEnumerable<IGrouping<int, Race>> Top6RacesByYear(string raceCountry) =>
        _races
                .Where(x => x.RaceCountry == raceCountry && x.Position.HasValue && x.Position <= 6)
                .GroupBy(x => x.Date.Year)
                .OrderBy(x => x.Key);

    public string WriteToFile(string fileName, string raceCountry)
    {
         try
         {
              using StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
          
              var racesByYear = Top6RacesByYear(raceCountry);
              bool firstYear = true;
          
              foreach (var yearGroup in racesByYear)
              {
                   if (!firstYear)
                        sw.WriteLine();
               
                   sw.WriteLine(yearGroup.Key);
               
                   foreach (var racer in yearGroup.OrderBy(x => x.Position))
                   {
                        string team = string.IsNullOrEmpty(racer.Team) ? null! : racer.Team;
                        sw.WriteLine($"{racer.Position}. {racer.Name}{(team != null ? $" ({team})" : "")}");
                   }
               
                   firstYear = false;
              }
          
              return $"A \"{raceCountry}\" versenyek adatai sikeresen kiírva a \"{fileName}\" fájlba.";
         }
         catch (Exception ex)
         {
              return $"Hiba történt a \"{fileName}\" fájlba írás közben: {ex.Message}";
         }
    }
}
