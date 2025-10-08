namespace TesztKiertekeles_VB_Lib;

public class Test
{
    public string? Name { get; }
    public int? Score1 { get; }
    public int? Score2 { get; }
    public int? Score3 { get; }
    public int? Score4 { get; }
    public int? Score5 { get; }

    public Test(string dataLine)
    {
        string[] parts = dataLine.Split(';');
        // foreach (string part in parts)
        // {
        //     Console.WriteLine(part);
        // }
        
        Name = parts[0] == "" ? null : parts[0];
        Score1 = int.TryParse(parts[1], out int score1) ? score1 : null;
        Score2 = int.TryParse(parts[2], out int score2) ? score2 : null;
        Score3 = int.TryParse(parts[3], out int score3) ? score3 : null;
        Score4 = int.TryParse(parts[4], out int score4) ? score4 : null;
        Score5 = int.TryParse(parts[5], out int score5) ? score5 : null;
    }

    //minden feladat 5 pont, 25 a max pontszám
    public double? ResultPercentage => ((Score1 != null! ? Score1 : 0) + (Score2 != null! ? Score2 : 0) + (Score3 != null! ? Score3 : 0) + (Score4 != null! ? Score4 : 0) + (Score5 != null! ? Score5 : 0)) / 25.0 * 100;
    public string DidPassed => ResultPercentage > 40 ? "sikeres" : "sikertelen";
    
    private int? ScoreSum => (Score1 != null! ? Score1 : 0) + (Score2 != null! ? Score2 : 0)  + (Score3 != null! ? Score3 : 0)  + (Score4 != null! ? Score4 : 0)  + (Score5 != null! ? Score5 : 0);
    public override string ToString()
    {
        return $"1. Teszt: {(Score1 != null ? Score1 : "-")}\n2. Teszt: {(Score2 != null ? Score2 : "-")}\n3. Teszt: {(Score3 != null ? Score3 : "-")}\n4. Teszt: {(Score4 != null ? Score4 : "-")}\n5. Teszt: {(Score5 != null ? Score5 : "-")}\nÖsszpontszám: {(ScoreSum != 0 ? ScoreSum : "-")}\n";
    }
}