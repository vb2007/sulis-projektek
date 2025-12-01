using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject3;

[TestClass]
public class UnitTest1
{
    WebDriver _driver;
    [TestInitialize]
    public void Setup()
    {
        FirefoxOptions options = new FirefoxOptions();
        options.AddArgument("--headless");
        FirefoxDriver foxDriver = new FirefoxDriver(options);
        _driver = foxDriver;
        _driver.Navigate().GoToUrl("https://books.toscrape.com/index.html");
    }

    [TestCleanup]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [TestMethod]
    public void FindFantasy()
    {
        var fantasy = _driver.FindElement(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li[18]/a"));
        fantasy.Click();
        var find = _driver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/h1")).Text;
        Assert.AreEqual("Fantasy",  find);
    }

    [TestMethod]
    public void SumBookPrices()
    {
        var fantasy = _driver.FindElement(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li[18]/a"));
        fantasy.Click();
        var books = _driver.FindElements(By.CssSelector(".price_color"));
        double sum = 0;
        foreach (var book in books)
        {
            string bookpricestring = book.Text;
            double bookprice = Convert.ToDouble(bookpricestring.Replace("£", ""));
            sum += bookprice;
        }
        Assert.AreEqual(793.0799999999999, sum);
        //793.0799999999999
    }
}