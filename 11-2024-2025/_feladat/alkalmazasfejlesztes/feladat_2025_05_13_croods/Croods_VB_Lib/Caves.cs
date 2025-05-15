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
                .Distinct()
                .ToList();
        public int CavesWithOldNamesCount => CavesWithOldNames.Count();
        public string CavesWithOldNamesString =>
            string.Join("\n\t", CavesWithOldNames);

        public int AverageLengthByCity(string city) =>
            (int)Math.Round(
                caves
                    .Where(x => x.City == city)
                    .Average(x => x.Length),
                0);

        private IEnumerable<Cave> CavesInAbc =>
            caves
                .OrderBy(x => x.Name)
                .ToList();
        public void ExportCorrectedFile(string fileName)
        {
            using StreamWriter sw = new(fileName);

            sw.WriteLine("Név;Hossz;Mélység;Magasság a bejárathoz képest;Település neve;Jártak-e");

            foreach (Cave cave in CavesInAbc)
            {
                sw.WriteLine(cave.ToString() + $"{(cave.IsVisited ? "már jártunk itt" : "")}");
            }
        }
    }
}
