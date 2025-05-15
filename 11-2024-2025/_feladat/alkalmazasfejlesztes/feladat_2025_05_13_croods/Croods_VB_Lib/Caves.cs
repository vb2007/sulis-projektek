using System.Collections.Immutable;

namespace Croods_VB_Lib
{
    public class Caves
    {
        private readonly List<Cave> caves = new();

        public Caves(IEnumerable<string> dataLines)
        {
            foreach (var line in dataLines)
            {
                caves.Add(new(line));
            }
        }

        public Cave GetCaveByIndex(int index) =>
            caves[index - 1];

        public double TotalLengthInKm =>
            Math.Round(
                caves
                    .Where(x => x.IsVisited)
                    .Sum(x => x.Length / 1000),
                2);

        public Cave DeepestCave =>
            caves
                .MaxBy(x => x.Depth);

        private IEnumerable<string> CavesWithOldNames =>
            caves
                .Where(x => x.HasOldName)
                .Select(x => x.Name)
                .OrderBy(x => x)
                .Distinct();
        public int CavesWithOldNamesCount => CavesWithOldNames.Count();
        public string CavesWithOldNamesString =>
            string.Join("\n\t", CavesWithOldNames);

        public int AverageLengthByCity(string city) =>
            (int)Math.Round(
                caves
                    .Where(x => x.City == city)
                    .Average(x => x.Length),
                0);

        //9. + 12. feladat
        private IEnumerable<Cave> CavesInAbc =>
            caves
                .OrderBy(x => x.Name)
                .ToList();
        private IEnumerable<Cave> UnvisitedCavesDescendingByCityThenName =>
            caves
                .Where(x => !x.IsVisited)
                .OrderByDescending(x => x.City)
                    .ThenBy(x => x.Name);
        public void ExportFile(string fileName, bool visited)
        {
            using StreamWriter sw = new(fileName);

            if (visited)
            {
                sw.WriteLine("Név;Hossz;Mélység;Magasság a bejárathoz képest;Település neve;Jártak-e");
                foreach (Cave cave in CavesInAbc)
                {
                    sw.WriteLine(cave.ToString() + $"{(cave.IsVisited ? ";már jártunk itt" : "")}");
                }
                return;
            }

            sw.WriteLine("Település neve;Barlang neve");
            foreach (var cave in UnvisitedCavesDescendingByCityThenName)
            {
                sw.WriteLine(cave.ToString());
            }
        }

        public IEnumerable<string> GetCavesByCity()
        {
            var grouped = caves
                .GroupBy(x => x.City)
                .OrderBy(x => x.Key); //még név alapján is rendezve van

            foreach (var group in grouped)
            {
                yield return $"{group.Key}: {group.Count()} darab";
                string names = string.Join(", ", group.OrderBy(x => x.Name).Select(x => x.Name)); //itt is
                yield return $"\t{names}";
            }
        }

        public IEnumerable<Cave> LongestCaves(int numberOfCaves) =>
            caves
                .OrderByDescending(x => x.Length)
                .Take(numberOfCaves)
                .ToList();
    }
}
