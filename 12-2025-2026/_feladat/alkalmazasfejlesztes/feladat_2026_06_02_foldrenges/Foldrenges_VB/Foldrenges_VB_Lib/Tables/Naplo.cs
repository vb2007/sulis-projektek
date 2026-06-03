namespace Foldrenges_VB_Lib.Tables;

public class Naplo
{
    public int Id { get; init; }
    public DateOnly Datum { get; init; }
    public TimeOnly Ido { get; init; }
    public int TelepId { get; init; }
    public float Magnitudo { get; init; }
    public float Intenzitas { get; init; }

    internal Naplo(string dataLine)
    {
        string[] split = dataLine.Split("\t");

        Id = int.Parse(split[0]);
        Datum = DateOnly.Parse(split[1]);
        Ido = TimeOnly.Parse(split[2]);
        TelepId = int.Parse(split[3]);
        Magnitudo = float.Parse(split[4]);
        Intenzitas = float.Parse(split[5]);
    }
}