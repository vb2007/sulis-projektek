namespace Dohanyboltok_VB_Lib
{
    public class TobaccoStore
    {
        public string City { get; init; }
        public string Street { get; init; }
        public int MonthlyIncome { get; set; }
        public int Traffic { get; set; }
        public string MostPopularProduct { get; set; }

        public TobaccoStore(string dataLine)
        {
            string[] split = dataLine.Split(';');

            City = split[0];
            Street = split[1];
            MonthlyIncome = int.Parse(split[2]);
            Traffic = int.Parse(split[3]);
            MostPopularProduct = split[4];
        }
    }
}
