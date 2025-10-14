using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumBevezetes;

[TestFixture]
//[Parallelizable(ParallelScope.All)] //egyszerre futna le mindegyik teszt, de ahhoz más setup & teardown logika kell
public class Tests
{
    private WebDriver _webDriver;
    private readonly string _baseUrl = "https://books.toscrape.com/";

    [SetUp]
    public void Setup()
    {
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        _webDriver = new FirefoxDriver(firefoxOptions);
        _webDriver.Navigate().GoToUrl(_baseUrl);
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver?.Quit();
        _webDriver?.Dispose();
    }

    [Test]
    [Description("Checks the page's title.")]
    public void CheckTitle()
    {
        Assert.That("All products | Books to Scrape - Sandbox", Is.EqualTo(_webDriver.Title));
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
        
    }
}
