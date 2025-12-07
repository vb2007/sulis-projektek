using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace DemoBlaze.Helpers;

public static class ExcelReportGenerator
{
    private static readonly List<TestResultModel> TestResults = new();
    private static readonly Dictionary<string, DateTime> TestStartTimes = new();

    public static void StartTest(string testId)
    {
        TestStartTimes[testId] = DateTime.Now;
    }

    public static void EndTest()
    {
        var testContext = TestContext.CurrentContext;
        var testId = GetTestId(testContext);
        var testEndTime = DateTime.Now;
        var testStartTime = TestStartTimes.ContainsKey(testId) ? TestStartTimes[testId] : testEndTime;

        var testResult = new TestResultModel
        {
            TestFixtureName = testContext.Test.ClassName?.Split('.').Last() ?? "Unknown",
            TestCaseName = testContext.Test.MethodName ?? testContext.Test.Name,
            Category = string.Join(", ", testContext.Test.Properties["Category"].Cast<string>()),
            Description = testContext.Test.Properties.Get("Description")?.ToString() ?? "",
            Outcome = GetOutcome(testContext),
            FailReason = testContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed
                ? testContext.Result.Message
                : "",
            StartedOn = testStartTime,
            FinishedOn = testEndTime,
            TotalRuntime = testEndTime - testStartTime
        };

        TestResults.Add(testResult);
        TestStartTimes.Remove(testId);
    }

    private static string GetTestId(TestContext context)
    {
        return $"{context.Test.ClassName}.{context.Test.MethodName}";
    }

    private static string GetOutcome(TestContext context)
    {
        var status = context.Result.Outcome.Status;
        
        //check if test has [Ignore]
        if (context.Test.Properties.ContainsKey("_SKIPREASON"))
        {
            return "Ignored";
        }
        
        return status switch
        {
            NUnit.Framework.Interfaces.TestStatus.Passed => "Passed",
            NUnit.Framework.Interfaces.TestStatus.Failed => "Failed",
            NUnit.Framework.Interfaces.TestStatus.Skipped => "Ignored",
            NUnit.Framework.Interfaces.TestStatus.Inconclusive => "Didn't Run",
            _ => "Unknown"
        };
    }

    public static void GenerateReport(string outputPath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Test Results");

        //header
        worksheet.Cells[1, 1].Value = "Fixture";
        worksheet.Cells[1, 2].Value = "Case";
        worksheet.Cells[1, 3].Value = "Case Category";
        worksheet.Cells[1, 4].Value = "Description";
        worksheet.Cells[1, 5].Value = "Outcome";
        worksheet.Cells[1, 6].Value = "Reason";
        worksheet.Cells[1, 7].Value = "Started On";
        worksheet.Cells[1, 8].Value = "Finished On";
        worksheet.Cells[1, 9].Value = "Total Runtime (sec)";

        using (var range = worksheet.Cells[1, 1, 1, 9])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        int row = 2;
        foreach (var result in TestResults.OrderBy(r => r.TestFixtureName).ThenBy(r => r.TestCaseName))
        {
            worksheet.Cells[row, 1].Value = result.TestFixtureName;
            worksheet.Cells[row, 2].Value = result.TestCaseName;
            worksheet.Cells[row, 3].Value = result.Category;
            worksheet.Cells[row, 4].Value = result.Description;
            worksheet.Cells[row, 5].Value = result.Outcome;
            worksheet.Cells[row, 6].Value = result.FailReason;
            worksheet.Cells[row, 7].Value = result.StartedOn.ToString("yyyy-MM-dd HH:mm:ss");
            worksheet.Cells[row, 8].Value = result.FinishedOn.ToString("yyyy-MM-dd HH:mm:ss");
            worksheet.Cells[row, 9].Value = result.TotalRuntime.TotalSeconds;

            var outcomeCell = worksheet.Cells[row, 5];
            outcomeCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            outcomeCell.Style.Fill.BackgroundColor.SetColor(result.Outcome switch
            {
                "Passed" => Color.LightGreen,
                "Failed" => Color.LightCoral,
                "Ignored" => Color.LightYellow,
                _ => Color.LightGray
            });

            row++;
        }

        //auto-fits like when you double-click on long rows in libreoffice/excel 
        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        package.SaveAs(new FileInfo(outputPath));
    }

    public static void Clear()
    {
        TestResults.Clear();
        TestStartTimes.Clear();
    }
}
