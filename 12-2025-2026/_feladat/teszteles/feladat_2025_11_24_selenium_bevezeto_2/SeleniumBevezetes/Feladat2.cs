using OpenQA.Selenium;

namespace SeleniumBevezetes;

[TestFixture]
public class Feladat2 : BrowserSiteHelper
{
    private IWebElement FantasyCategoryBtn => _webDriver.FindElement(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li[18]/a"));
    
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
        FantasyCategoryBtn.Click();
        
        string foundText = _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/h1")).Text;
        Assert.That(foundText, Is.EqualTo("Fantasy"));
    }
    
    [Test]
    public void SumBookPrices()
    {
        FantasyCategoryBtn.Click();
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

    [Test]
    public void SumBookPricesOnAllPages()
    {
        FantasyCategoryBtn.Click();
        
        double sum = 0;
        bool hasNextPage = true;
        while (hasNextPage)
        {
            IEnumerable<IWebElement> booksList = _webDriver.FindElements(By.CssSelector(".price_color"));
            foreach (IWebElement book in booksList)
            {
                string bookpricestring = book.Text;
                double bookprice = Convert.ToDouble(bookpricestring.Replace("£", ""));
                sum += bookprice;
            }
        
            IEnumerable<IWebElement> nextButton = _webDriver.FindElements(By.CssSelector(".pager .next a"));
            if (nextButton.Any())
            {
                nextButton.First().Click();
                Thread.Sleep(500);
            }
            else
            {
                hasNextPage = false;
            }
        }
    
        Assert.That(sum, Is.GreaterThan(0));
        Console.WriteLine($"Total sum of all book prices across all pages: £{sum}");
    }
    
    [Test]
    public void SumBookPricesOnAllPagesWithStock()
    {
        
    }
}