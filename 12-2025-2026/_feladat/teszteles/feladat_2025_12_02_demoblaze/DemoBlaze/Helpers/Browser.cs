using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DemoBlaze.Helpers;

public class Browser
{
    public static WebDriver _webDriver;

    public static void InitTestFixture()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        _webDriver = new FirefoxDriver(firefoxOptions);
        _webDriver.Navigate().GoToUrl(TestData._baseUrl);
    }
    
    public static void TeardownTestFixture()
    {
        _webDriver.Quit();
        _webDriver.Dispose();
    }
}