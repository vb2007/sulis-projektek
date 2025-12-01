using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumBevezetes;

public class BrowserSiteHelper
{
    public WebDriver _webDriver;
    public readonly string _baseUrl = "https://books.toscrape.com/";

    public void InitTest()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        _webDriver = new FirefoxDriver(firefoxOptions);
        _webDriver.Navigate().GoToUrl(_baseUrl);
    }
}