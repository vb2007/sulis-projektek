using OrszagokTest.Helpers;
using OpenQA.Selenium;

namespace OrszagokTest.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HTMLStuctureTest
{
    private static Browser _browser;
    private static WebDriver WebDriver => _browser.WebDriver;

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