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
    private static int? Task1Count => tests.Count(x => x.Score1 != null);
    private static int? Task2Count => tests.Count(x => x.Score2 != null);
    private static int? Task3Count => tests.Count(x => x.Score3 != null);
    private static int? Task4Count => tests.Count(x => x.Score4 != null);
    private static int? Task5Count => tests.Count(x => x.Score5 != null);
    private static int? Task1Average => tests.Sum(x => x.Score1) / testCount;
    private static int? Task2Average => tests.Sum(x => x.Score2) / testCount;
    private static int? Task3Average => tests.Sum(x => x.Score3) / testCount;
    private static int? Task4Average => tests.Sum(x => x.Score4) / testCount;
    private static int? Task5Average => tests.Sum(x => x.Score5) / testCount;

    private static int? Task1NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private static int? Task2NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private static int? Task3NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private static int? Task4NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    private static int? Task5NullCount =>
        tests
            .Where(x => x.Score1 != null || x.Score2 != null || x.Score3 != null || x.Score4 != null ||
                        x.Score5 != null)
            .Count(x => x.Score1 == null);

    public readonly string TaskDataString =
        $"1. Teszt\nEnnyien oldották meg: {Task1Count}\nEnnyi az átlagos pontszám: {Task1Average}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task1NullCount}\n\n" +
        $"2. Teszt\nEnnyien oldották meg: {Task2Count}\nEnnyi az átlagos pontszám: {Task2Average}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task2NullCount}\n\n" +
        $"3. Teszt\nEnnyien oldották meg: {Task3Count}\nEnnyi az átlagos pontszám: {Task3Average}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task3NullCount}\n\n" +
        $"4. Teszt\nEnnyien oldották meg: {Task4Count}\nEnnyi az átlagos pontszám: {Task4Average}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task4NullCount}\n\n" +
        $"5. Teszt\nEnnyien oldották meg: {Task5Count}\nEnnyi az átlagos pontszám: {Task5Average}\nEnnyi tanuló nem adott be semmit, de megírta a tesztet: {Task5NullCount}\n\n";
}