namespace PlantCollection_VB_Lib
{
    public class Mushroom : IPlant
    {
        public string Name => "Gomba";
        public string Description { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public char Display => 'g';
        public bool Poisonous { get; set; }

        public Mushroom(string type)
        {
            Type = type;
            switch (type)
            {
                case "rókagomba":
                    Value = 30;
                    Poisonous = false;
                    break;
                case "döggomba":
                    Value = 50;
                    Poisonous = true;
                    break;
                case "csiperke":
                    Value = 70;
                    Poisonous = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Érvénytelen gombatípus.");
            }
            Description = $"Egy {Value} értékű {type} gomba, {(Poisonous ? "mérgező" : "nem mérgező")}";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
