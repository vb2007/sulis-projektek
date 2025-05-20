namespace PlantCollection_VB_Lib
{
    public class Mushroom : IPlant
    {
        public string Name => "Mushroom";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value => 50;
        public char Display => 'm';
        public bool Poisonous { get; set; }

        public Mushroom(string type)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
