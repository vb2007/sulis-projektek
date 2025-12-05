using DemoBlaze.Helpers;
using OpenQA.Selenium;

namespace DemoBlaze.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StaticTextTest
{
    private readonly WebDriver _webDriver = Browser._webDriver;
    
    [SetUp]
    public void Setup()
    {
        Browser.InitTestFixture();
    }

    [TearDown]
    public void TearDown()
    {
        Browser.TeardownTestFixture();
    }

    [Test]
    [Description("Check the page's title (same across all pages).")]
    public void CheckTitle()
    {
        string actualTitle = _webDriver.Title;
        Assert.That(actualTitle, Is.EqualTo(TestData.Title), "The title is incorrect.");
    }

    [Test]
    [Description("Checks each footer section's title.")]
    public void CheckFooterTitles()
    {
        
    }

    [Test]
    [Description("Checks each footer section's content.")]
    public void CheckFooterContent()
    {
        
    }
}