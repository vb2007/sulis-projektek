using DemoBlaze.Helpers;
using OpenQA.Selenium;

namespace DemoBlaze.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UserTest
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
    [Description("Should log in an existing user successfully")]
    public void Login()
    {
        
    }

    [Test]
    [Description("Should register a new user successfully.")]
    [Ignore(
        "Since the site actually stores user data permanently without an option for account deletion, this test's ignored to avoid spam.")]
    public void Register()
    {
        
    }

    [Test]
    [Description("Should throw a relevant error when an invalid password is provided for an existing user.")]
    public void LoginErrorHandling()
    {
        
    }
}