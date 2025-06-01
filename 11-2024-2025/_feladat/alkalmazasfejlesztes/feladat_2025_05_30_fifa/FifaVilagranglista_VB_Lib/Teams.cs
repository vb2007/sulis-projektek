namespace FifaVilagranglista_VB_Lib
{
    public class Teams
    {
        private readonly List<Team> teams = new();

        public Teams(IEnumerable<string> dataLines)
        {
            foreach (var item in dataLines)
            {
                teams.Add(new(item));
            }
        }

        public int Count => teams.Count;

        public double AveragePoints =>
            Math.Round(
                teams
                    .Average(x => x.Points),
            2);

        public Team BestDiff =>
            teams
                .MaxBy(x => x.Difference);

        public bool IsTeamPresent(string name) =>
            teams.Exists(x => x.Name == name);

        public IDictionary<int, int> DiffStats =>
            teams
                .GroupBy(x => x.Difference)
                .Where(g => g.Count() > 1)
                .ToDictionary(x => x.Key, x => x.Count());
    }
}
