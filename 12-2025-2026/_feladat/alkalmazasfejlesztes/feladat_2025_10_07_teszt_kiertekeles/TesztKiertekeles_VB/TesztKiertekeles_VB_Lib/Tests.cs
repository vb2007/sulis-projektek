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
}