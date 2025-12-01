using OpenQA.Selenium;

namespace SeleniumBevezetes;

[TestFixture]
public class Feladat2 : BrowserSiteHelper
{
    [SetUp]
    public void Setup()
    {
        InitTestFixture();
    }

    [TearDown]
    public void TearDown()
    {
        TeardownTestFixture();
    }

    [Test]
    [Description("Navigates to the 'Fantasy' category.")]
    public void NavigateToFantasy()
    {
        IWebElement fantasyButton = _webDriver.FindElement(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li[18]/a"));
        fantasyButton.Click();
        string foundText = _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/h1")).Text;
        Assert.That(foundText, Is.EqualTo("Fantasy"));
    }
    
    [Test]
    public void SumBookPrices()
    {
        IWebElement fantasyButton = _webDriver.FindElement(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li[18]/a"));
        fantasyButton.Click();
        IEnumerable<IWebElement> booksList = _webDriver.FindElements(By.CssSelector(".price_color"));
        
        double sum = 0;
        foreach (IWebElement book in booksList)
        {
            string bookpricestring = book.Text;
            double bookprice = Convert.ToDouble(bookpricestring.Replace("£", ""));
            sum += bookprice;
        }
        
        Assert.That(sum, Is.EqualTo(793.0799999999999));
    }
}