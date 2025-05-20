namespace PlantCollection_VB_Lib
{
    public class Herb : IPlant
    {
        public string Name => "Gyógynövény";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public char Display => 'n';
        public string Effect { get; set; }

        public Herb(string type)
        {
            Type = type;
            switch (type)
            {
                case "kamilla":
                    Effect = "gyógyító";
                    break;
                case "borsmenta":
                    Effect = "frissítő";
                    break;
                case "citromfű":
                    Effect = "nyugtató";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Érvénytelen gyógynövénytípus.");
            }
            Description = $"Egy {Effect} hatású {Type} gyógynövény";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
