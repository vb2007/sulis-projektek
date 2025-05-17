namespace TreasureChest_VB_Lib
{
    public class Gem : ITreasure
    {
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public int Value { get; }
        public int Size { get; }

        public Gem(int type, int size)
        {
            // Type: 0 = Zafír, 1 = Smaragd, 2 = Gyémánt
            // Size: 0 = Kicsi, 1 = Közepes, 2 = Nagy
            string[] typeNames = { "zafír", "smaragd", "gyémánt" };
            int[] baseValues = { 500, 400, 1000 };

            Name = typeNames[type];
            Type = typeNames[type];
            Size = size;

            int smallValue = baseValues[type];
            int multiplier = size switch
            {
                0 => 1, // Kicsi
                1 => 4, // Közepes
                2 => 9, // Nagy
                _ => 1
            };
            Value = smallValue * multiplier;

            Description = $"{(size == 0 ? "kis" : size == 1 ? "közepes" : "nagy")} {Name.ToLower()} worth {Value}";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
