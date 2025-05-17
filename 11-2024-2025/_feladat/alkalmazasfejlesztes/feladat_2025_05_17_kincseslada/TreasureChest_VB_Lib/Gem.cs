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
            // Type: 0 = Sapphire, 1 = Emerald, 2 = Diamond
            // Size: 0 = Small, 1 = Medium, 2 = Large
            string[] typeNames = { "Sapphire", "Emerald", "Diamond" };
            int[] baseValues = { 500, 400, 1000 };

            Name = typeNames[type];
            Type = typeNames[type];
            Size = size;

            int smallValue = baseValues[type];
            int multiplier = size switch
            {
                0 => 1, // Small
                1 => 4, // Medium
                2 => 9, // Large
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
