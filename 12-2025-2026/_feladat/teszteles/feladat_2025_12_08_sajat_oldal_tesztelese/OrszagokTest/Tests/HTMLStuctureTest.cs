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

    [Test]
    [Description("Checks if the page's language really is set to Hungarian.")]
    public void CheckLanguage()
    {
        
    }

    [Test]
    [Description("Checks if the page's encoding really is set to UTF-8")]
    public void CheckEncoding()
    {
        
    }

    [Test]
    [Description("Checks if the page really has a title.")]
    public void CheckTitlePresence()
    {
        
    }

    [Test]
    [Description("Checks if a H1 element really is present on the page.")]
    public void CheckH1Presence()
    {
        
    }

    [Test]
    [Description("Checks if a H1 element really is present on the page.")]
    public void CheckH2Presence()
    {
        
    }
}