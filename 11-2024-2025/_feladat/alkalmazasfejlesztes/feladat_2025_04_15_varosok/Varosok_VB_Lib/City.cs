namespace Varosok_VB_Lib
{
    public class City
    {
        //Város;Ország;Népesség;Dátum
        public string Name { get; init; }
        public string Country { get; init; }
        public double Population { get; init; }
        public DateOnly Date { get; init; }

        public City(string line)
        {
            string[] splitted = line.Split(';');
            Name = splitted[0];
            Country = splitted[1];
            Population = double.Parse(splitted[2]);
            Date = DateOnly.Parse(splitted[3]);
        }

        public double ThousandPeople => Population * 1000;

        public override string ToString()
        {
            return $"{Name} ({Country}): {ThousandPeople} ezer fő";
        }
    }
}
