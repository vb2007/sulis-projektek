using FifaVilagranglista_VB_Lib;

namespace FifaVilagranglista_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teams teams = new(File.ReadLines("fifa.txt").Skip(1));

            Console.WriteLine($"3. feladat: A világranglistán {teams.Count} csapat szerepel");

            Console.WriteLine($"4. feladat: A csapatok átlagos pontszáma: {teams.AveragePoints} pont");

            Team bestDiffTeam = teams.BestDiff;
            Console.WriteLine($"5. feladat: A legtöbbet javító csapat:");
            Console.WriteLine($"\tHelyezés: {bestDiffTeam.Rank}");
            Console.WriteLine($"\tCsapat: {bestDiffTeam.Name}");
            Console.WriteLine($"\tPontszám: {bestDiffTeam.Points}");

            Console.WriteLine($"6. feladat: A csapatok között {(teams.IsTeamPresent("Magyarország") ? "van" : "nincs")} Magyarország");

            IDictionary<int, int> diffStats = teams.DiffStats;
            Console.WriteLine($"7. feladat: Statisztika");
            foreach( var item in diffStats )
            {
                Console.WriteLine($"\t{item.Key} helyet változott: {item.Value} csapat");
            }
        }
    }
}
