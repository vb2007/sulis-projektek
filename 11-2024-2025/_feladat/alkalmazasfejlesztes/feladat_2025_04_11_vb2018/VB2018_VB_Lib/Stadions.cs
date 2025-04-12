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
    }
}
