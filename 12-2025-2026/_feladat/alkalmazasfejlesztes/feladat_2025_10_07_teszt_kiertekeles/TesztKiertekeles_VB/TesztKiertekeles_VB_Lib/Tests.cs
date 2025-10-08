namespace TesztKiertekeles_VB_Lib;

public class Tests
{
    private static readonly List<Test> tests = new();

    public Tests(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            tests.Add(new Test(line));
        }
    }

    private static int testCount = tests.Count;

    //2. Feladat
    public Test TestDataByStudentName(string studentName) =>
        tests.Any(x => x.Name == studentName) ? tests.First(x => x.Name == studentName) : null!;

    //3. feladat
    private int? Task1Count => tests.Count(x => x.Score1 != null);
    private int? Task2Count => tests.Count(x => x.Score2 != null);
    private int? Task3Count => tests.Count(x => x.Score3 != null);
    private int? Task4Count => tests.Count(x => x.Score4 != null);
    private int? Task5Count => tests.Count(x => x.Score5 != null);
    
    private double? Task1Average => Task1Count > 0 ? (double)tests.Where(x => x.Score1 != null).Sum(x => x.Score1!.Value) / Task1Count : null;
    private double? Task2Average => Task2Count > 0 ? (double)tests.Where(x => x.Score2 != null).Sum(x => x.Score2!.Value) / Task2Count : null;
    private double? Task3Average => Task3Count > 0 ? (double)tests.Where(x => x.Score3 != null).Sum(x => x.Score3!.Value) / Task3Count : null;
    private double? Task4Average => Task4Count > 0 ? (double)tests.Where(x => x.Score4 != null).Sum(x => x.Score4!.Value) / Task4Count : null;
    private double? Task5Average => Task5Count > 0 ? (double)tests.Where(x => x.Score5 != null).Sum(x => x.Score5!.Value) / Task5Count : null;

    private int? Task1NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private int? Task2NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private int? Task3NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private int? Task4NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private int? Task5NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    public string TaskDataString =>
        $"1. Teszt\nEnnyien oldották meg: {Task1Count}\nEnnyi az átlagos pontszám: {Task1Average:F2}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task1NullCount}\n\n" +
        $"2. Teszt\nEnnyien oldották meg: {Task2Count}\nEnnyi az átlagos pontszám: {Task2Average:F2}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task2NullCount}\n\n" +
        $"3. Teszt\nEnnyien oldották meg: {Task3Count}\nEnnyi az átlagos pontszám: {Task3Average:F2}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task3NullCount}\n\n" +
        $"4. Teszt\nEnnyien oldották meg: {Task4Count}\nEnnyi az átlagos pontszám: {Task4Average:F2}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task4NullCount}\n\n" +
        $"5. Teszt\nEnnyien oldották meg: {Task5Count}\nEnnyi az átlagos pontszám: {Task5Average:F2}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task5NullCount}\n\n";
}