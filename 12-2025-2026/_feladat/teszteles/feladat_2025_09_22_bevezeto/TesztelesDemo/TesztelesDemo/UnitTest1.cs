using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TesztelesDemo;

[TestClass]
public class UnitTest1
{
    private WebDriver _webDriver;

    [TestInitialize]
    public void SetUp()
    {
        //ChromeOptions chromeOptions = new ChromeOptions();
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        
        //_webDriver = new ChromeDriver(chromeOptions);
        _webDriver = new FirefoxDriver(firefoxOptions);
        //_webDriver = new RemoteWebDriver(new Uri("http://127.0.0.1:9515"), chromeOptions);
        //_webDriver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444"), firefoxOptions);   
    }

    [TestCleanup]
    public void TearDown()
    {
        _webDriver?.Quit();
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        _webDriver.Navigate().GoToUrl("https://duckduckgo.com");
        Assert.AreEqual("DuckDuckGo - Protection. Privacy. Peace of mind.",  _webDriver.Title);
    }

    [TestMethod]
    public void TestMethod2()
    {
        _webDriver.Navigate().GoToUrl("https://gitlab.neumann-bp.edu.hu/");
        _webDriver.FindElement(By.Id("ldapmain_username")).SendKeys("alma");
        _webDriver.FindElement(By.Id("ldapmain_password")).SendKeys("korte");
        //a videó óta megváltozott a selector, frissítettem a kódot
        //_webDriver.FindElement(By.XPath("//*[@data-qa-selector=\"sign_in_button\"]")).Click();
        _webDriver.FindElement(By.XPath("//*[@data-testid=\"sign-in-button\"]")).Click();
        
        WebDriverWait wait = new WebDriverWait(_webDriver, new  TimeSpan(0, 0, 30));
        
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        wait.PollingInterval = new TimeSpan(0, 0, 0, 0, 100);
        
        try
        {
            //itt is változott a selector, frissítettem a kódot
            //wait.Until(x => x.FindElement(By.CssSelector("div.layout-page")));
            wait.Until(x => x.FindElement(By.XPath("//*[@data-testid=\"flash-container\"]")));
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail("Element not found!");
        }

        try
        {
            Assert.IsNotNull(_webDriver.FindElement(By.XPath("//*[@data-testid=\"flash-container\"]")));
        }
        catch (NoSuchElementException)
        {
            Assert.Fail("Element not found!");
        }
    }
    
    [TestMethod]
    public void TestWindows()
    {
        _webDriver.Navigate().GoToUrl("https://98.js.org/");
        
        //failelni fog, mert nincs rendesen implementálva minden click funkció
        var icon = _webDriver.FindElement(By.XPath("//*[@src=\"https://98.js.org/images/icons/minesweeper-32x32.png\"]/../.."));
        icon.Click();
        icon.Click();
        
        WebDriverWait wait = new WebDriverWait(_webDriver, new  TimeSpan(0, 0, 0, 1));
        wait.PollingInterval = new TimeSpan(0, 0, 0, 0, 100);
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        wait.Until(x => x.FindElement(By.ClassName("window-title")));
        Assert.AreEqual("Minesweeper", _webDriver.FindElement(By.ClassName("window-title")).Text);
        _webDriver.GetScreenshot().SaveAsFile("/home/vb2007/code/sulis-projektek/12-2025-2026/_feladat/teszteles/feladat_2025_09_22_bevezeto/minesweeper.png");
    }
}