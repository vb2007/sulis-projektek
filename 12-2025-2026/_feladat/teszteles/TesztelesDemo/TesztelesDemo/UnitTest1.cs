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
        
    }
}