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
               .FirstOrDefault()?.BirthDate?.Year is not null and var year
                    ? DateOnly.FromDateTime(DateTime.Now).Year - year 
                    : null;
}
