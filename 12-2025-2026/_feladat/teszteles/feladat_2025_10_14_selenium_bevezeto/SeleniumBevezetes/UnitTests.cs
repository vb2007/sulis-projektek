namespace SeleniumBevezetes;

public class Tests
{
    private readonly string baseUrl = "https://books.toscrape.com/";
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}