namespace VB2018_VB_Lib
{
    public class Stadion
    {
        public string City { get; init; }
        public string Name1 { get; init; }
        public string Name2 { get; init; }
        public int Capacity { get; init; }

        public Stadion(string dataLines)
        {
            string[] splitted = dataLines.Split(';');

            City = splitted[0];
            Name1 = splitted[1];
            Name2 = splitted[2];
            Capacity = int.Parse(splitted[3]);
        }
    }
}
