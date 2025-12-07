using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoBlaze.Helpers;

public class Browser
{
    public WebDriver WebDriver { get; private set; }

    public void Init()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        
        firefoxOptions.AddArgument("--headless");
        firefoxOptions.AddArgument("--width=1920");
        firefoxOptions.AddArgument("--height=1080");
        
        //about:config
        firefoxOptions.SetPreference("dom.webnotifications.enabled", false);
        firefoxOptions.SetPreference("geo.enabled", false);
        firefoxOptions.SetPreference("media.autoplay.default", 0);
        firefoxOptions.SetPreference("layers.acceleration.disabled", true); //gpu acceleration
        
        WebDriver = new FirefoxDriver(firefoxOptions);
        
        //ha nem headless-ben megy
        // WebDriver.Manage().Window.Maximize();
        
        WebDriver.Navigate().GoToUrl(TestData._baseUrl);
    }

    public void Teardown()
    {
        WebDriver.Quit();
        WebDriver.Dispose();
    }

    public void WaitForMillSec(int waitTimeInMillSec)
    {
        Thread.Sleep(waitTimeInMillSec);
    }
    
    public void WaitUntilElementIsPresent(By locator, int waitTimeInMillSec = 5)
    {
        WebDriverWait webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(waitTimeInMillSec));
        webDriverWait.Until(ExpectedConditions.ElementExists(locator));
    }

    public void WaitUntilPageLoads(int waitTimeInMillSec = 5)
    {
        WebDriverWait webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(waitTimeInMillSec));
        webDriverWait.Until(WebDriver =>
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("return document.readyState")!.Equals("complete"));
    }
}
