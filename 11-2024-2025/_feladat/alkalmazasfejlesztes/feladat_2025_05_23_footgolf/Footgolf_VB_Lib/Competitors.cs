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
    }
}
