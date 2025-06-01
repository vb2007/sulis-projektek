using Footgolf_VB_Lib;

namespace Footgolf_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Competitors competitors = new(File.ReadAllLines("fob2016.txt"));

            Console.WriteLine($"3. feladat: Versenyzők száma: {competitors.Count}");

            Console.WriteLine($"4. feladat: A női versenyzők aránya: {competitors.FemaleRatioPercent}%");

            Competitor femaleChampion = competitors.GetFemaleChampion;
            Console.WriteLine($"6. feladat: A bajnok női versenyző");
            Console.WriteLine($"\tNév: {femaleChampion.Name}");
            Console.WriteLine($"\tEgyesület: {femaleChampion.Team}");
            Console.WriteLine($"\tÖsszpont: {femaleChampion.TotalScore}");

            //7. feladat
            competitors.WriteToFile("osszpontFF.txt");

            //8. feladat
            Dictionary<string, int> teamStats = competitors.GetTeamStatistics;
            Console.WriteLine("8. feladat: Egyesület statisztika");
            foreach (var team in teamStats)
            {
                Console.WriteLine($"\t{team.Key} - {team.Value} fő");
            }
        }
    }
}
