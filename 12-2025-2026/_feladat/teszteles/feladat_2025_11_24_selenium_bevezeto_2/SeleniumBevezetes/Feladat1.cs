using OpenQA.Selenium;

namespace SeleniumBevezetes;

[TestFixture]
//[Parallelizable(ParallelScope.All)] //egyszerre futna le mindegyik teszt, de ahhoz más setup & teardown logika kell
public class Tests : BrowserSiteHelper
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
    [Description("Checks the page's title.")]
    public void CheckTitle()
    {
        string expectedTitle = "All products | Books to Scrape - Sandbox";
        //tibro videójában "hiba" volt:
        //Assert.That(1, 2)-nél 1 az actual, 2 az expected
        Assert.That(_webDriver.Title, Is.EqualTo(expectedTitle));
    }

    [Test]
    [Description("Checks if all book type labels are present in the sidebar list.")]
    public void CheckLabels()
    {
        IEnumerable<string> expectedLabels = new List<string>
        { 
            "Travel", "Mystery", "Historical Fiction", "Sequential Art", 
            "Classics", "Philosophy", "Romance", "Womens Fiction", 
            "Fiction", "Childrens", "Religion", "Nonfiction", 
            "Music", "Default", "Science Fiction", "Sports and Games", 
            "Add a comment", "Fantasy", "New Adult", "Young Adult", 
            "Science", "Poetry", "Paranormal", "Art", "Psychology", 
            "Autobiography", "Parenting", "Adult Fiction", "Humor", 
            "Horror", "History", "Food and Drink", "Christian Fiction", 
            "Business", "Biography", "Thriller", "Contemporary", 
            "Spirituality", "Academic", "Self Help", "Historical", 
            "Christian", "Suspense", "Short Stories", "Novels", "Health", 
            "Politics", "Cultural", "Erotica", "Crime"
        };

        IWebElement listContainer = _webDriver.FindElement(By.CssSelector("div.side_categories ul.nav.nav-list li ul"));
        IEnumerable<IWebElement> labelContainers = listContainer.FindElements(By.CssSelector("li > a"));
        IEnumerable<string> actualLabels = labelContainers.Select(x => x.Text.Trim()).ToList();
        
        foreach (string expectedLabel in expectedLabels)
        {
            Assert.That(actualLabels, Contains.Item(expectedLabel), $"Expected category '{expectedLabel}' was not found in the list");
        }
    }

    [Test]
    [Description("Checks the 'A Light in the Attic' book's price.")]
    public void CheckPrice()
    {
        string expectedTitle = "A Light in the Attic";
        string expectedPrice = "£51.77";
        
        //a könyv elementeken nincsen semmilyen unique id, class, stb., csak a bennük lévő "a" elementeken egy "title="
        //így sajnos nem lehet szimpla select methodot használni, xpath-el kell kiválasztani a parent elementet a title alapján
        IWebElement bookContainerElement = _webDriver.FindElement(By.XPath($"//li[.//a[@title='{expectedTitle}']]"));
        IWebElement bookPriceElement = bookContainerElement.FindElement(By.CssSelector("div.product_price p.price_color"));
        string actualBookPrice = bookPriceElement.Text.Trim();
        
        Assert.That(actualBookPrice, Is.EqualTo(expectedPrice));
    }
}
