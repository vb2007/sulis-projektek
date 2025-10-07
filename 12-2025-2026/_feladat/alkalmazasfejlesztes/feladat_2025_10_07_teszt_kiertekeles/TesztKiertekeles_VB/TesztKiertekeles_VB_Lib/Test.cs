namespace TesztKiertekeles_VB_Lib;

public class Test
{
    public string? Name { get; set; }
    public int? Score1 { get; set; }
    public int? Score2 { get; set; }
    public int? Score3 { get; set; }
    public int? Score4 { get; set; }
    public int? Score5 { get; set; }

    public Test(string dataLine)
    {
        string[] parts = dataLine.Split(';');
        // foreach (string part in parts)
        // {
        //     Console.WriteLine(part);
        // }
        
        Name = parts[0];
        Score1 = int.TryParse(parts[1], out int score1) ? score1 : null;
        Score2 = int.TryParse(parts[2], out int score2) ? score2 : null;
        Score3 = int.TryParse(parts[3], out int score3) ? score3 : null;
        Score4 = int.TryParse(parts[4], out int score4) ? score4 : null;
        Score5 = int.TryParse(parts[5], out int score5) ? score5 : null;
    }
}