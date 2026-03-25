namespace ByteFriend_Tests.Helpers;

public class TestResultModel
{
    public required string TestFixtureName { get; init; }
    public required string TestCaseName { get; init; }
    public required string Category { get; init; }
    public required string Description { get; init; }
    public required string Outcome { get; init; }
    public required string FailReason { get; init; }
    public DateTime StartedOn { get; init; }
    public DateTime FinishedOn { get; init; }
    public TimeSpan TotalRuntime { get; init; }
}