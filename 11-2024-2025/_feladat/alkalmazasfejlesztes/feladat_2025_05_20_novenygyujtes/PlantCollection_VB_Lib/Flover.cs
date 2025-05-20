namespace PlantCollection_VB_Lib
{
    public class Flover : IPlant
    {
        public string Name => "Virág";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value => 20;
        public char Display => 'v';

        public Flover(string type)
        {
            switch (type)
            {
                case "tulipán":
                    break;
                case "rózsa":
                    break;
                case "hóvirág":
                    break;
                case "muskátli":
                    break;
                case "nárcisz":
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Érvénytelen virágtípus.");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
