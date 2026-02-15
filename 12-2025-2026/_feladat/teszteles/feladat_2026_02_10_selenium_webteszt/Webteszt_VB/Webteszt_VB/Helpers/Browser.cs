using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Webteszt_VB.Helpers;

public class Browser
{
    public WebDriver WebDriver { get; private set; }

    public void Init()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();

        //firefoxOptions.AddArgument("--headless");
        firefoxOptions.AddArgument("--width=1920");
        firefoxOptions.AddArgument("--height=1080");

        //about:config
        firefoxOptions.SetPreference("dom.webnotifications.enabled", false);
        firefoxOptions.SetPreference("geo.enabled", false);
        firefoxOptions.SetPreference("media.autoplay.default", 0);
        firefoxOptions.SetPreference("layers.acceleration.disabled", true); //gpu acceleration

        WebDriver = new FirefoxDriver(firefoxOptions);

        //ha nem headless-ben megy
        WebDriver.Manage().Window.Maximize();

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

    public void WaitUntilElementIsPresent(By locator, int waitTimeInMillSec = 5000)
    {
        WebDriverWait webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(waitTimeInMillSec));
        webDriverWait.Until(ExpectedConditions.ElementExists(locator)); //requires DotNetSeleniumExtras.WaitHelpers package
    }

    public void WaitUntilPageLoads(int waitTimeInMillSec = 5000)
    {
        WebDriverWait webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(waitTimeInMillSec));
        webDriverWait.Until(WebDriver =>
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("return document.readyState")!.Equals("complete"));
    }

    public void CheckAlertMessage(string expectedAlertText)
    {
        IAlert alert = WebDriver.SwitchTo().Alert();
        string actualAlertText = alert.Text!;

        Assert.That(actualAlertText, Is.EqualTo(expectedAlertText), "The alert's text is incorrect.");
    }

    public bool IsElementPresent(By locator)
    {
        try
        {
            WebDriver.FindElement(locator);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    // public IWebElement? FindElementSafe(By locator)
    // {
    //     try
    //     {
    //         return WebDriver.FindElement(locator);
    //     }
    //     catch (NoSuchElementException)
    //     {
    //         return null;
    //     }
    // }
    //
    // public void AssertElementPresent(By locator, string errorMessage = "Element should be present on the page.")
    // {
    //     bool isPresent = IsElementPresent(locator);
    //     Assert.That(isPresent, Is.True, errorMessage);
    // }
}
