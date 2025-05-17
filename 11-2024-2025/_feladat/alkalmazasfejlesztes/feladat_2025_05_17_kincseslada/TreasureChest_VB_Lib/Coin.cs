namespace TreasureChest_VB_Lib
{
    public class Coin : ITreasure
    {
        public string Name => "Érme";
        public string Description { get; }
        public string Type { get; }
        public int Value { get; }

        public Coin(int type)
        {
            switch (type)
            {
                case 0:
                    Type = "arany";
                    Value = 100;
                    break;
                case 1:
                    Type = "ezüst";
                    Value = 10;
                    break;
                case 2:
                    Type = "réz";
                    Value = 1;
                    break;
                default:
                    throw new ArgumentException("Érvénytelen érték. Használj 0, 1, vagy 2 számokat.");
            }

            Description = $"Egy csillió {Type}érme.";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
