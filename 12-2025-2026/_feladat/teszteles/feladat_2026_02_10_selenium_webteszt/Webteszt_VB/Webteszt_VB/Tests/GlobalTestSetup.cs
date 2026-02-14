using Webteszt_VB.Helpers;

namespace Webteszt_VB.Tests;

[SetUpFixture]
public class GlobalTestSetup
{
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        ExcelReportGenerator.Clear();
        Console.WriteLine("Test execution started...");
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestReports",
            $"TestReport_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx");

        Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
        ExcelReportGenerator.GenerateReport(reportPath);

        Console.WriteLine($"Excel report generated: {reportPath}");
    }
}