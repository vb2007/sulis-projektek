namespace Croods_VB_Lib
{
    public class Cave
    {
        public string Name { get; init; }
        public double Length { get; init; }
        public double Depth { get; init; }
        public double Heigth { get; init; }
        public string City { get; init; }
        public bool IsVisited { get; init; }

        public Cave(string dataLine)
        {
            string[] splitted = dataLine.Split(";");

            Name = splitted[0];
            Length = double.Parse(splitted[1]);
            Depth = double.Parse(splitted[2]);
            Heigth = double.Parse(splitted[3]);
            City = splitted[4];
            IsVisited = (splitted[5] == "i");
        }

        private readonly List<string> OldNames = new List<string> { "lyuk", "zsomboly", "lik" };
        public bool HasOldName =>
            OldNames.Any(oldName => Name.ToLower().Contains(oldName));

        public override string ToString()
        {
            return $"";
        }
    }
}
