namespace TreasureChest_VB_Lib
{
    public interface ITreasure
    {
        string Name { get; init; }
        string Description { get; init; }
        string Type { get; init; }
        int Value { get; init; }
    }
}
