namespace Foldrenges_VB_Lib.Tables;

public class Telepules
{
    public int Id { get; init; }
    public string Nev { get; init; }
    public string Varmegye { get; set; }

    internal Telepules(string dataLine)
    {
        string[] split = dataLine.Split("\t");

        Id = int.Parse(split[0]);
        Nev = split[1];
        Varmegye = split[2];
    }
}