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
}