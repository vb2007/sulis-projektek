using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBevezetes;

public class BrowserSiteHelper
{
    public static WebDriver _webDriver;
    public readonly string _baseUrl = "https://books.toscrape.com/";

    public void InitTestFixture()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        _webDriver = new FirefoxDriver(firefoxOptions);
        _webDriver.Navigate().GoToUrl(_baseUrl);
    }

    public void TeardownTestFixture()
    {
        _webDriver.Quit();
        _webDriver.Dispose();
    }

    public static WebDriverWait WaitForMillSec(int milSecs) => new WebDriverWait(_webDriver, new  TimeSpan(0, 0, 0, 0, milSecs));
}
