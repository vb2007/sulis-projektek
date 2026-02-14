using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.StaticContent;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class HomepageTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    private IWebElement TitleElement => _webDriver.FindElement(By.CssSelector("h1"));

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
    [Category("StaticContent")]
    [Description("Check the homepage's title on the browser tab.")]
    public void CheckPageTitle()
    {
        string actualTitle = _webDriver.Title;
        Assert.That(actualTitle, Is.EqualTo(TestData.BrowserTitle), "The page's title is incorrect.");
    }

    [Test]
    [Category("StaticContent")]
    [Description("Checks the page's title on the rendered HTML.")]
    public void CheckTitle()
    {
        string actualTitle = TitleElement.Text;
        Assert.That(actualTitle, Is.EqualTo(TestData.HeaderTitle), "The homepage title is incorrect.");
    }
}
