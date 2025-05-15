using System.Globalization;

namespace Croods_VB_Lib
{
    public class Cave
    {
        public string Name { get; init; }
        public double Length { get; init; }
        public double Depth { get; init; }
        public double Height { get; init; }
        public string City { get; init; }
        public bool IsVisited { get; init; }

        public Cave(string dataLine)
        {
            string[] splitted = dataLine.Split(";");

            //CultureInfo.InvariantCulture => "." és "," közötti külöbségeket kezeli le a host gép régiójától függetlenül
            Name = splitted[0];
            Length = double.Parse(splitted[1], CultureInfo.InvariantCulture);
            Depth = double.Parse(splitted[2], CultureInfo.InvariantCulture);
            Height = double.Parse(splitted[3], CultureInfo.InvariantCulture);
            City = splitted[4];
            IsVisited = (splitted[5] == "i");
        }

        private readonly List<string> OldNames = new List<string> { "lyuk", "zsomboly", "lik" };
        public bool HasOldName =>
            OldNames.Any(oldName => Name.ToLower().Contains(oldName));

        public override string ToString()
        {
            return $"{Name};{Length};{Depth};{Height};{City}";
        }
    }
}
