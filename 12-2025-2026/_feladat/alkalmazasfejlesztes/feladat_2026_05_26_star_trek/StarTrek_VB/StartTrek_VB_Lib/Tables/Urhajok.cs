namespace StartTrek_VB_Lib.Tables;

internal class Urhajok
{
    public int UrhajoId { get; init; }
    public string Azonosito { get; init; }
    public string UrhajoNev { get; init; }
    public int OsztalyId { get; init; }
    public int FajId { get; init; }

    internal Urhajok(string dataLines)
    {
        string[] split = dataLines.Split(';');

        UrhajoId = int.Parse(split[0]);
        Azonosito = split[1];
        UrhajoNev = split[2];
        OsztalyId = int.Parse(split[3]);
        FajId = int.Parse(split[4]);
    }
}