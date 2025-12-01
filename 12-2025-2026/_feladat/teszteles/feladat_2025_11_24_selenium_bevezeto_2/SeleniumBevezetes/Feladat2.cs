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
        
    }
}