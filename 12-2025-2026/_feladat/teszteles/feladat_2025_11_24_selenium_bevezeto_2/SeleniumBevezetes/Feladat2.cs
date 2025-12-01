using OpenQA.Selenium;

namespace SeleniumBevezetes;

[TestFixture]
public class Feladat2 : BrowserSiteHelper
{
    [SetUp]
    public void Setup()
    {
        InitTestFixture();
    }

    [TearDown]
    public void TearDown()
    {
        TeardownTestFixture();
    }

    [Test]
    [Description("Navigates to the 'Fantasy' category.")]
    public void NavigateToFantasy()
    {
        IWebElement fantasyButton = _webDriver.FindElement(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li[18]/a"));
        fantasyButton.Click();
        string foundText = _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/h1")).Text;
        Assert.That(foundText, Is.EqualTo("Fantasy"));
    }
}