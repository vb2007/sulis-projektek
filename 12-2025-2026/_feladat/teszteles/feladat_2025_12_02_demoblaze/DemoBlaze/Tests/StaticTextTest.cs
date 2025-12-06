using DemoBlaze.Helpers;
using OpenQA.Selenium;

namespace DemoBlaze.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StaticTextTest
{
    private static Browser _browser;
    private static WebDriver WebDriver => _browser.WebDriver;

    private IWebElement TitleElement => WebDriver.FindElement(By.Id("nava"));

    [SetUp]
    public void Setup()
    {
        _browser = new Browser();
        _browser.Init();
    }

    [TearDown]
    public void TearDown()
    {
        _browser?.Teardown();
    }

    [Test]
    [Description("Check the page's title on the browser tab (same across all pages).")]
    public void CheckBrowserTitle()
    {
        string actualTitle = WebDriver.Title;
        Assert.That(actualTitle, Is.EqualTo(TestData.Title), "The title is incorrect.");
    }

    [Test]
    [Description("Checks the page's title on the rendered HTML.")]
    public void CheckTitle()
    {
        string actualTitle = TitleElement.Text;
        Assert.That(actualTitle, Is.EqualTo(TestData.StoreName), "The page title is incorrect.");
    }

    [Test]
    [Description("Checks each footer section's title.")]
    public void CheckFooterTitles()
    {
        
    }

    [Test]
    [Description("Checks each footer section's content.")]
    public void CheckFooterContent()
    {
        
    }
}