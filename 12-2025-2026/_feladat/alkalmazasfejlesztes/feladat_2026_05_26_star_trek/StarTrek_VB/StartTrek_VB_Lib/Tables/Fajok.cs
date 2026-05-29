namespace StartTrek_VB_Lib.Tables;

internal class Fajok
{
    public int FajId { get; init; }
    public string FajNev { get; init; }

    internal Fajok(string dataLines)
    {
        string[] split = dataLines.Split(';');

        FajId = int.Parse(split[0]);
        FajNev = split[1];
    }
}