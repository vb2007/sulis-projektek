using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumBevezetes;

public class Tests
{
    private WebDriver _webDriver;
    private readonly string _baseUrl = "https://books.toscrape.com/";

    [SetUp]
    public void Setup()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        _webDriver = new FirefoxDriver(firefoxOptions);
        _webDriver.Navigate().GoToUrl(_baseUrl);
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver?.Quit();
        _webDriver?.Dispose();
    }

    [Test]
    public void CheckTitle()
    {
        Assert.That("All products | Books to Scrape - Sandbox", Is.EqualTo(_webDriver.Title));
    }
}
