namespace Kektura_VB_Lib
{
    public class Trips
    {
        private readonly List<Trip> trips = new();

        public Trips(IEnumerable<string> dataLines)
        {
            foreach (var line in dataLines)
            {
                trips.Add(new(line));
            }
        }

        public int Count => trips.Count;

        public double FullLength => trips.Sum(x => x.Length);

        public Trip ShortestTrip => trips.MinBy(x => x.Length);

        private List<string> IncorrectNames =>
            trips
                .Where(x => x.IncorrectName)
                .Select(x => x.EndPoint)
                .ToList();
        public string IncorrectNamesString
            => string.Join("\n\t", IncorrectNames);


    }
}
