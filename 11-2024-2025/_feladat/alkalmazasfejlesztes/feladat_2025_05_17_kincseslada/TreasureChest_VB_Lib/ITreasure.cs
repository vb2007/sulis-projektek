namespace TreasureChest_VB_Lib
{
    public interface ITreasure
    {
        string Name { get; }
        string Description { get; }
        string Type { get; }
        int Value { get; }
    }
}
