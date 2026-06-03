using System.Globalization;

namespace Foldrenges_VB_Lib.Tables;

public class Naplo
{
    public int Id { get; init; }
    public DateOnly Datum { get; init; }
    public TimeOnly Ido { get; init; }
    public int TelepId { get; init; }
    public float? Magnitudo { get; init; } //lehet null is, bár a feladatban baszták leírni
    public float? Intenzitas { get; init; } //same shit

    internal Naplo(string dataLine)
    {
        string[] split = dataLine.Split("\t");

        Id = int.Parse(split[0]);
        Datum = DateOnly.Parse(split[1]);
        Ido = TimeOnly.Parse(split[2]);
        TelepId = int.Parse(split[3]);
        Magnitudo = string.IsNullOrWhiteSpace(split[4])
            ? null
            : float.Parse(split[4], new CultureInfo("hu-HU"));
        Intenzitas = string.IsNullOrWhiteSpace(split[5]) 
            ? null
            : float.Parse(split[5], new CultureInfo("hu-HU"));
    }
}