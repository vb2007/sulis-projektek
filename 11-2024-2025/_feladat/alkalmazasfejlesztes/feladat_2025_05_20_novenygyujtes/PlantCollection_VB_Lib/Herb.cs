namespace PlantCollection_VB_Lib
{
    public class Herb : IPlant
    {
        public string Name => "Gyógynövény";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value => 80;
        public char Display => 'n';
        public string Effect { get; set; }

        public Herb(string type)
        {
            switch (type)
            {
                case "kamilla":
                    Effect = "gyógyító";
                    Description = $"Egy {Effect} hatású kamilla";
                    break;
                case "borsmenta":
                    Effect = "frissítő";
                    Description = $"Egy {Effect} hatású borsmenta";
                    break;
                case "citromfű":
                    Effect = "nyugtató";
                    Description = $"Egy {Effect} hatású citromfű";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Érvénytelen gyógynövénytípus.");
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
