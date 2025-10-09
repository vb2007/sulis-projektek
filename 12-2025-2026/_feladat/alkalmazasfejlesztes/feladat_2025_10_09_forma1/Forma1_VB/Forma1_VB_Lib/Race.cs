using System.Globalization;

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
    
    public static readonly CultureInfo HungarianCulture = CultureInfo.GetCultureInfo("hu-HU");

    public Race(string dataLine)
    {
        string[] splitData = dataLine.Split(';');
        
        Date = DateOnly.Parse(splitData[0], HungarianCulture);
        RaceCountry = splitData[1];
        Name = splitData[2];
        Gender = char.Parse(splitData[3]);
<<<<<<< HEAD
        BirthDate = !string.IsNullOrEmpty(splitData[4]) ? DateOnly.Parse(splitData[4], HungarianCulture) : null;
=======
        BirthDate = !string.IsNullOrEmpty(splitData[4]) ? DateOnly.Parse(splitData[4]) : null;
>>>>>>> a0f6fc580f675a912b086685228a477035cd613b
        Nationality = splitData[5];
        Position = !string.IsNullOrEmpty(splitData[6]) ? int.Parse(splitData[6]) : null;
        Error = !string.IsNullOrEmpty(splitData[7]) ? splitData[7] : null;
        Team = !string.IsNullOrEmpty(splitData[8]) ? splitData[8] : null;
        CarType = splitData[9];
        CarEngine = splitData[10];
    }
}