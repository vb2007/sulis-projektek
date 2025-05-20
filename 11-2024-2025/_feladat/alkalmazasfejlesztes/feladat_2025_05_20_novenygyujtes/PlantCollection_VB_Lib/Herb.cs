namespace PlantCollection_VB_Lib
{
    public class Herb : IPlant
    {
        public string Name => "Herb";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value => 80;
        public char Display => 'h';
        public string Effect { get; set; }

        public Herb(string type)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
