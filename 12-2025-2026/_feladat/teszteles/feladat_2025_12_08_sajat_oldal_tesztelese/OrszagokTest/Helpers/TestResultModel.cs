namespace OrszagokTest.Helpers;

public class TestResultModel
{
    public string TestFixtureName { get; set; }
    public string TestCaseName { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Outcome { get; set; }
    public string FailReason { get; set; }
    public DateTime StartedOn { get; set; }
    public DateTime FinishedOn { get; set; }
    public TimeSpan TotalRuntime { get; set; }
}