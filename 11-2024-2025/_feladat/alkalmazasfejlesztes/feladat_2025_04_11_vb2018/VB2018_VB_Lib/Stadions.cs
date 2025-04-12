namespace VB2018_VB_Lib
{
    public class Stadions
    {
        public readonly List<Stadion> stadions = new List<Stadion>();

        public Stadions(IEnumerable<string> dataRows)
        {
            foreach (string item in dataRows)
            {
                stadions.Add(new Stadion(item));
            }
        }

        public int NumberOfStadions => stadions.Count;

        public Stadion StadionWithLeastCapacity => stadions.MinBy(x => x.Capacity);

        public double StadionsAverageCapacity => Math.Round(stadions.Average(x => x.Capacity), 1);

        public int NumberOfStadionsWithAlernativeNames => stadions.Count(x => !string.IsNullOrEmpty(x.Name2));

        public int NumberOfStadionsThatContainAName(string name) => stadions.Count(x => x.Name1.ToLower().Contains(name.ToLower())); //task told to not check 2nd names, but: || x.Name2.Contains(name)

        private List<string> CitiesOfStadions => stadions.Select(x => x.City).Distinct().OrderBy(x => x).ToList();
        public string CitiesOfStadionsString => string.Join("; ", CitiesOfStadions);

        public IEnumerable<Stadion> StadionsOrdered => stadions.OrderBy(x => x.Name1).ThenBy(x => x.Capacity);
    }
}
