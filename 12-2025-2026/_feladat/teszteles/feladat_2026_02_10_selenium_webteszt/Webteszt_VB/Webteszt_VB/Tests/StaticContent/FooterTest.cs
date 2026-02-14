using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.StaticContent;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class FooterTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    public IWebElement FooterTextElement => _webDriver.FindElement(By.CssSelector("footer div"));

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
    [Description("Checks the footer's content.")]
    public void CheckFooterContent()
    {
        string expectedFooterText = TestData.FooterData.FooterText;
        Assert.That(FooterTextElement.Text, Is.EqualTo(expectedFooterText), "The footer text is incorrect.");
    }
}
