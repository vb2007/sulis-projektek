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
        Assert.AreEqual("DuckDuckGo - Privacy, simplified.",  _webDriver.Title);
    }

    [TestMethod]
    public void TestMethod2()
    {
        _webDriver.Navigate().GoToUrl("https://gitlab.neumann-bp.edu.hu/");
        _webDriver.FindElement(By.Id("ldapmain_username")).SendKeys("alma");
        _webDriver.FindElement(By.Id("ldapmain_password")).SendKeys("korte");
        _webDriver.FindElement(By.XPath("//*[@data-qa-selector=\"sign_in_button\"]")).Click();
        
        WebDriverWait wait = new WebDriverWait(_webDriver, new  TimeSpan(0, 0, 30));
        
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        wait.PollingInterval = new TimeSpan(0, 0, 0, 0, 100);
        
        try
        {
            wait.Until(x => x.FindElement(By.CssSelector("div.layout-page")));
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail("Element not found!");
        }

        try
        {
            Assert.IsNotNull(_webDriver.FindElement(By.CssSelector("div.layout-page")));
        }
        catch (NoSuchElementException)
        {
            Assert.Fail("Element not found!");
        }
    }
}