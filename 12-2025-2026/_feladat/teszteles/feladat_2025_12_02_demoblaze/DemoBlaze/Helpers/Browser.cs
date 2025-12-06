using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DemoBlaze.Helpers;

public class Browser
{
    public WebDriver WebDriver { get; private set; }

    public void Init()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        WebDriver = new FirefoxDriver(firefoxOptions);
        WebDriver.Navigate().GoToUrl(TestData._baseUrl);
    }

    public void Teardown()
    {
        WebDriver.Quit();
        WebDriver.Dispose();
    }
}
