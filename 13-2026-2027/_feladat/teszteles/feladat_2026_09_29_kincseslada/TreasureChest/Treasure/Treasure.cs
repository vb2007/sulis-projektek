namespace TreasureChest
{
    public class Treasure
    {
        private int _volume;
        public string Name { get; init; }

        public int Volume
        {
            get => _volume;
            init
            {
                _volume = value;
            }
        }

        public Treasure(string name, int volume)
        {
            //Ez lenne a fix a bug-ra, de ignore-ban vannak a tesztek:

            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    throw new ArgumentException("Treasure name cannot be empty.", nameof(name));
            //}

            //if (volume <= 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(volume), "Treasure volume must be greater than 0.");
            //}

            Volume = volume;
            Name = name;
        }
    }
}
