using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DemoBlaze.Helpers;

public class Browser
{
    public static WebDriver _webDriver;

    public void InitTest()
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
}