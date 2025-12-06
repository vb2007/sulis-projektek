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
    private IWebElement FooterContainerElement = WebDriver.FindElement(By.Id("fotcont"));
    private IWebElement FooterAboutUsHeaderElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(1) h4 b"));
    private IWebElement FooterAboutUsContentElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(1) h4 p"));
    private IWebElement FooterGetInTouchHeaderElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(2) h4 b"));
    private IWebElement FooterGetInTouchAddressContentElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(2) h4 p:nth-of-type(1)"));
    private IWebElement FooterGetInTouchPhoneContentElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(2) h4 p:nth-of-type(2)"));
    private IWebElement FooterGetInTouchEmailContentElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(2) h4 p:nth-of-type(3)"));
    private IWebElement FooterProductStoreHeaderElement => FooterContainerElement.FindElement(By.CssSelector("div.col-*:nth-of-type(3) h4"));

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
        string actualAboutUsHeader = FooterAboutUsHeaderElement.Text;
        string actualGetInTouchHeader = FooterGetInTouchHeaderElement.Text;
        string actualProductStoreHeader = FooterProductStoreHeaderElement.Text;
        
        Assert.Multiple(() =>
        {
            Assert.That(actualAboutUsHeader, Is.EqualTo(TestData.FooterData.Titles.AboutUs), "The about us header is incorrect.");
            Assert.That(actualGetInTouchHeader, Is.EqualTo(TestData.FooterData.Titles.GetInTouch), "The get in touch header is incorrect.");
            Assert.That(actualProductStoreHeader, Is.EqualTo(TestData.StoreName), "The product store header is incorrect.");
        });
    }

    [Test]
    [Description("Checks each footer section's content.")]
    public void CheckFooterContent()
    {

    }
}
