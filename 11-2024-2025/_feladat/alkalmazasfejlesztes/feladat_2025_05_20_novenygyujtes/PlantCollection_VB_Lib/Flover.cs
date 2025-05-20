namespace PlantCollection_VB_Lib
{
    public class Flover : IPlant
    {
        public string Name => "Flover";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value => 20;
        public char Display => 'f';

        public Flover(string type)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
