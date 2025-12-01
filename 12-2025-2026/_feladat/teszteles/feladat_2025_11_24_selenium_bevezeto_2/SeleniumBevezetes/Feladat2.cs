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
    [Description("Checks the sum of all books' prices on the current (first) page in a specified category.")]
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
    [Description("Checks the sum of all books' prices on all pages in a specified category.")]
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
                WaitForMillSec(500);
            }
            else
            {
                hasNextPage = false;
            }
        }
    
        Assert.That(sum, Is.EqualTo(1900.51));
    }
    
    [Test]
    [Description("Checks the sum of all books' prices (counting available stock) on all pages in a specified category.")]
    public void SumBookPricesOnAllPagesWithStock()
    {
        FantasyCategoryBtn.Click();
        
        double totalValue = 0;
        bool hasNextPage = true;
        while (hasNextPage)
        {
            IEnumerable<IWebElement> bookLinks = _webDriver.FindElements(By.CssSelector("article.product_pod h3 a"));
            int bookCount = bookLinks.Count();
            
            for (int i = 0; i < bookCount; i++)
            {
                bookLinks = _webDriver.FindElements(By.CssSelector("article.product_pod h3 a"));
                
                bookLinks.ElementAt(i).Click();
                WaitForMillSec(300);
                
                string priceText = _webDriver.FindElement(By.CssSelector(".product_main .price_color")).Text;
                double price = Convert.ToDouble(priceText.Replace("£", ""));
                
                //kiszedi a html-ből, hogy mennyi van leltáron
                string stockText = _webDriver.FindElement(By.CssSelector(".product_main .instock.availability")).Text;
                int stockAmount = 0;
                if (stockText.Contains('(') && stockText.Contains("available"))
                {
                    string stockNumberStr = stockText.Split('(')[1].Split(' ')[0];
                    stockAmount = Convert.ToInt32(stockNumberStr);
                }
                
                double bookValue = price * stockAmount;
                totalValue += bookValue;
                
                _webDriver.Navigate().Back();
                WaitForMillSec(300);
            }
            
            IEnumerable<IWebElement> nextButton = _webDriver.FindElements(By.CssSelector(".pager .next a"));
            if (nextButton.Any())
            {
                nextButton.First().Click();
                WaitForMillSec(500);
            }
            else
            {
                hasNextPage = false;
            }
        }
        
        Assert.That(totalValue, Is.EqualTo(14591.769999999997));
    }
}