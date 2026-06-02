namespace Alapfilmek_VB_Lib.Tables;

internal class Filmstab
{
    public int FilmAzonosito { get; init; }
    public int MunkakorAzonosito { get; init; }
    public int AlkotoAzonosito { get; init; }

    internal Filmstab(string dataLine)
    {
        string[] split = dataLine.Split('\t');

        FilmAzonosito = int.Parse(split[0]);
        MunkakorAzonosito = int.Parse(split[1]);
        AlkotoAzonosito = int.Parse((split[2]));
    }
}