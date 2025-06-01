namespace Footgolf_VB_Lib
{
    public class Competitors
    {
        private readonly List<Competitor> competitors = new();

        public Competitors(IEnumerable<string> dataLines)
        {
            foreach (var competitor in dataLines)
            {
                competitors.Add(new(competitor));
            }
        }

        public int Count => competitors.Count;

        public double FemaleRatioPercent
        {
            get
            {
                int femaleCount = competitors.Count(c => c.Category == "Noi");
                double ratio = (double)femaleCount / competitors.Count * 100;
                return Math.Round(ratio, 2);
            }
        }

        public Competitor GetFemaleChampion =>
            competitors
                .Where(c => c.Category == "Noi")
                .OrderByDescending(c => c.TotalScore)
                .First();

        public void WriteToFile(string fileName)
        {
            var lines = competitors
                .Where(c => c.Category == "Felnott ferfi")
                .Select(c => $"{c.Name};{c.TotalScore}");

            File.WriteAllLines(fileName, lines);
        }

        public Dictionary<string, int> GetTeamStatistics =>
            competitors
            .Where(c => c.Team != "n.a.")
            .GroupBy(c => c.Team)
            .Where(g => g.Count() > 2)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}
