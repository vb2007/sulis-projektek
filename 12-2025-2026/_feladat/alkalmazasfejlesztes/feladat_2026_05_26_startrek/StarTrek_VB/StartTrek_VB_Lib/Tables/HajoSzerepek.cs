namespace StartTrek_VB_Lib.Tables;

internal class HajoSzerepek
{
    public int SzerepId { get; init; }
    public string SzerepNev { get; init; }

    internal HajoSzerepek(string dataLines)
    {
        string[] split = dataLines.Split(';');

        SzerepId = int.Parse(split[0]);
        SzerepNev = split[1];
    }
}