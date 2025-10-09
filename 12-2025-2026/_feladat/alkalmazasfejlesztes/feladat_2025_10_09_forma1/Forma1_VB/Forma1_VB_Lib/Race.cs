namespace Forma1_VB_Lib;

public class Race
{
    public DateOnly Date { get; set; }
    public string RaceCountry { get; set; }
    public string Name { get; set; }
    public char Gender { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string Nationality { get; set; }
    public int? Position { get; set; }
    public string? Error { get; set; }
    public string? Team { get; set; }
    public string CarType  { get; set; }
    public string CarEngine { get; set; }

    public Race(string dataLine)
    {
        string[] splitData = dataLine.Split(';');
        
        Date = DateOnly.Parse(splitData[0]);
        RaceCountry = splitData[1];
        Name = splitData[2];
        Gender = char.Parse(splitData[3]);
        BirthDate = splitData[4] != null! ? DateOnly.Parse(splitData[4]) : null;
        Nationality = splitData[5];
        Position = splitData[6] != null! ? int.Parse(splitData[6]) : null;
        Error = splitData[7] != null! ? splitData[7] : null;
        Team = splitData[8] != null! ? splitData[8] : null;
        CarType = splitData[9];
        CarEngine = splitData[10];
    }
}