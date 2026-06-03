namespace Alapfilmek_VB_Lib.Tables;

internal class Alkotok
{
    public int AlkotoAzonosito { get; init; }
    public string Nev { get; init; }
    public DateOnly? Szuletett { get; init; }
    public DateOnly? Elhunyt { get; init; }

    internal Alkotok(string dataLine)
    {
        string[] split = dataLine.Split('\t');

        AlkotoAzonosito = int.Parse(split[0]);
        Nev = split[1];
        Szuletett = split[2] != "" ? DateOnly.Parse(split[2]) : null;
        Elhunyt = split[3] != "" ? DateOnly.Parse(split[3]) : null;
    }
}