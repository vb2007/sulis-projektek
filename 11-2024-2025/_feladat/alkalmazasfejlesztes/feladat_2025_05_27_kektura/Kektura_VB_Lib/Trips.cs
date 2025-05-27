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

    }
}
