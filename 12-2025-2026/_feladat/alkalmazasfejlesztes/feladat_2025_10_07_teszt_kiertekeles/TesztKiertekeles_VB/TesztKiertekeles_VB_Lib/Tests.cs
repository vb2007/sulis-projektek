namespace TesztKiertekeles_VB_Lib;

public class Tests
{
    private readonly List<Test> tests = new List<Test>();

    public Tests(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            tests.Add(new Test(line));
        }
    }
    
    //2. Feladat
    public Test TestData(string studentName) => tests.Any(x => x.Name == studentName) ? tests.First(x => x.Name == studentName) : null!;
}