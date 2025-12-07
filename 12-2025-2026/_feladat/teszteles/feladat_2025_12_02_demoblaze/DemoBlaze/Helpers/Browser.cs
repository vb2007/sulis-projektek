using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DemoBlaze.Helpers;

public class Browser
{
    public WebDriver WebDriver { get; private set; }

    public void Init()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        firefoxOptions.AddArgument("--disabled-gpu");
        firefoxOptions.AddArgument("--disable-notifications");
        firefoxOptions.AddArgument("--disable-geolocation");
        firefoxOptions.AddArgument("--start-maximized");
        firefoxOptions.AddArgument("--no-sandbox");
        firefoxOptions.AddArgument("--disable-setuid-sandbox");
        firefoxOptions.AddArgument("--autoplay-policy=no-user-gesture-required");
        firefoxOptions.AddArgument("--allow-running-insecure-content");
        
        firefoxOptions.AddArguments("--headless=new");
        firefoxOptions.AddArguments("--window-size=1920,1080");
        
        WebDriver = new FirefoxDriver(firefoxOptions);
        WebDriver.Navigate().GoToUrl(TestData._baseUrl);
    }

    public void Teardown()
    {
        WebDriver.Quit();
        WebDriver.Dispose();
    }
}
