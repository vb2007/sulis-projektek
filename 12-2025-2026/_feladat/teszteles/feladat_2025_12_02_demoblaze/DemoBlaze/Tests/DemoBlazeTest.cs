using DemoBlaze.Helpers;
using OpenQA.Selenium;

namespace DemoBlaze.Tests;

[TestFixture]
public class Tests
{
    private WebDriver _webDriver = Browser._webDriver;
    
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
}