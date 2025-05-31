using System.Globalization;

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
            => IncorrectNames.Count > 0
                ? string.Join("\n\t", IncorrectNames)
                : "Nincs hiányos állomásnév!";

        public (string EndPoint, int Elevation) GetHighestEndPoint(int startElevation)
        {
            int currentElevation = startElevation;
            int maxElevation = startElevation;
            string maxEndPoint = trips[0].StartPoint;

            foreach (Trip trip in trips)
            {
                currentElevation += trip.Increments - trip.Decrements;
                if (currentElevation > maxElevation)
                {
                    maxElevation = currentElevation;
                    maxEndPoint = trip.EndPoint;
                }
            }
            return (maxEndPoint, maxElevation);
        }

        public void WriteToCsv(string filePath, int startElevation)
        {
            using StreamWriter writer = new(filePath, false, System.Text.Encoding.UTF8);
            writer.WriteLine(startElevation);

            foreach (Trip trip in trips)
            {
                string endPoint = trip.EndPoint;
                if (trip.IsPostmarkPoint && !endPoint.Contains("pecsetelohely"))
                {
                    endPoint += " pecsetelohely";
                }

                //StartPoint;EndPoint;Length;Increments;Decrements;IsPostmarkPoint
                writer.WriteLine(
                    $"{trip.StartPoint};{endPoint};{trip.Length.ToString(CultureInfo.InvariantCulture)};{trip.Increments};{trip.Decrements};{(trip.IsPostmarkPoint ? 1 : 0)}"
                );
            }
        }
    }
}
