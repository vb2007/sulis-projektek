namespace PlantCollection_VB_Lib
{
    public interface IPlant
    {
        string Name { get; }
        string Description { get; }
        string Type { get; }
        int Value { get; }
        char Display { get; }
    }
}
