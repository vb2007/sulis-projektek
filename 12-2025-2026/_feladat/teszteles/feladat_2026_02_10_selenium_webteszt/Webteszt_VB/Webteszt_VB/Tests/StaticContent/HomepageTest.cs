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
    private IWebElement SloganElement => _webDriver.FindElement(By.CssSelector("p.lead"));
    private IWebElement NoLoginContainer => _webDriver.FindElement(By.CssSelector("div.alert.alert-info"));

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
        Assert.That(actualTitle, Is.EqualTo(TestData.HomepageData.BrowserTitle), "The page's title is incorrect.");
    }

    [Test]
    [Category("StaticContent")]
    [Description("Checks the page's title on the rendered HTML.")]
    public void CheckTitle()
    {
        string actualTitle = TitleElement.Text;
        Assert.That(actualTitle, Is.EqualTo(TestData.HomepageData.HeaderTitle), "The homepage title is incorrect.");
    }

    [Test]
    [Category("StaticContent")]
    [Description("Checks the page's slogan.")]
    public void CheckSlogan()
    {
        string actualSlogan = SloganElement.Text;
        Assert.That(actualSlogan, Is.EqualTo(TestData.HomepageData.Slogan), "The homepage slogan is incorrect.");
    }

    [Test]
    [Category("StaticContent")]
    [Description("Checks the container that's visible when the user isn't logged in.")]
    public void CheckNoLoginContainer()
    {
        string actualText = NoLoginContainer.GetDomProperty("innerText")!;
        Assert.That(actualText, Is.EqualTo(TestData.HomepageData.NoLoginContainer), "The no-login container text is incorrect.");
    }
}
