namespace StartTrek_VB_Lib.Tables;

internal class HajoOsztalyok
{
    public int OsztalyId { get; init; }
    public string OsztalyNev { get; init; }
    public int SzerepId { get; init; }

    internal HajoOsztalyok(string dataLines)
    {
        string[] split = dataLines.Split(';');

        OsztalyId = int.Parse(split[0]);
        OsztalyNev = split[1];
        SzerepId = int.Parse(split[2]);
    }
}