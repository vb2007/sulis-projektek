using DemoBlaze.Helpers;
using OpenQA.Selenium;

namespace DemoBlaze.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UserTest
{
    private static Browser _browser;
    private static WebDriver WebDriver => _browser.WebDriver;

    private IWebElement LoginNavButtonElement = WebDriver.FindElement(By.Id("login2"));
    private IWebElement RegisterNavButtonElement = WebDriver.FindElement(By.Id("signin2"));
    private IWebElement LoginUsernameInputElement = WebDriver.FindElement(By.Id("loginusername"));
    private IWebElement LoginPasswordInputElement = WebDriver.FindElement(By.Id("loginpassword"));
    private IWebElement LoginButtonElement = WebDriver.FindElement(By.CssSelector("button[onclick=\"logIn()\"]"));
    
    [SetUp]
    public void Setup()
    {
        _browser = new Browser();
        _browser.Init();
    }

    [TearDown]
    public void TearDown()
    {
        _browser?.Teardown();
    }

    [Test]
    [Description("Should log in an existing user successfully")]
    public void Login()
    {
        
    }

    [Test]
    [Description("Should register a new user successfully.")]
    [Ignore("Since the site actually stores user data permanently without an option for account deletion, this test's ignored to avoid spam.")]
    public void Register()
    {
        
    }

    [Test]
    [Description("Should throw a relevant error when an invalid password is provided for an existing user.")]
    public void LoginErrorHandling()
    {
        
    }
}