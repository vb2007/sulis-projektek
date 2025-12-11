using OrszagokTest.Helpers;
using OpenQA.Selenium;

namespace OrszagokTest.Tests;

[TestFixture]
// [Parallelizable(ParallelScope.All)]
public class HTMLStuctureTest
{
    private static Browser _browser;
    private static WebDriver WebDriver => _browser.WebDriver;

    private IWebElement HTMLElement => WebDriver.FindElement(By.CssSelector("html"));
    private IWebElement CharsetElement => WebDriver.FindElement(By.CssSelector("head > meta:nth-child(2)"));
    private By H1Selector => By.TagName("h1");
    private By H2Selector => By.TagName("h2");

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
        string actualLanguage = HTMLElement.GetAttribute("lang")!;
        Assert.That(actualLanguage, Is.EqualTo(TestData.HTMLAttributes.Language), "The site's language is incorrect.");
    }

    [Test]
    [Description("Checks if the page's encoding really is set to UTF-8")]
    public void CheckEncoding()
    {
        string actualEncoding = CharsetElement.GetAttribute("charset")!;
        Assert.That(actualEncoding, Is.EqualTo(TestData.HTMLAttributes.Encoding), "The site's encoding is incorrect.");
    }

    [Test]
    [Description("Checks if the page really has a title.")]
    public void CheckTitlePresence()
    {
        string? title = WebDriver.Title;
        Assert.That(title, Is.Not.Null, "A title should be set for the page.");
    }

    [Test]
    [Description("Checks if an H1 element really is present on the page.")]
    public void CheckH1Presence()
    {
        bool isPresent = _browser.IsElementPresent(H1Selector);
        Assert.That(isPresent, Is.True, "An H1 element should be present on the page");
    }

    [Test]
    [Description("Checks if an H2 element really is present on the page.")]
    public void CheckH2Presence()
    {
        bool isPresent = _browser.IsElementPresent(H2Selector);
        Assert.That(isPresent, Is.True, "An H2 element should be present on the page");
    }
}