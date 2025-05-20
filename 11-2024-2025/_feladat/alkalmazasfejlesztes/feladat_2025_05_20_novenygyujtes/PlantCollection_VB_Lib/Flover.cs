namespace PlantCollection_VB_Lib
{
    public class Flover : IPlant
    {
        public string Name => "Virág";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public char Display => 'v';

        public Flover(string type)
        {
            Type = type;
            switch (type)
            {
                case "tulipán":
                    Value = 10;
                    break;
                case "rózsa":
                    Value = 15;
                    break;
                case "hóvirág":
                    Value = 20;
                    break;
                case "muskátli":
                    Value = 25;
                    break;
                case "nárcisz":
                    Value = 30;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Érvénytelen virágtípus.");
            }
            Description = $"Egy {Value} értékű {Type} virág";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
