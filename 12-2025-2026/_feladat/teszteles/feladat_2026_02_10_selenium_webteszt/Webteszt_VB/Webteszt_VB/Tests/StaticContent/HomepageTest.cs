using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.StaticContent;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class HomepageTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);

        _browser = new Browser();
        _browser.Init();
    }

    [TearDown]
    public void TearDown()
    {
        _browser?.Teardown();

        ExcelReportGenerator.EndTest();
    }
}
