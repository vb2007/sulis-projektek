using DemoBlaze.Helpers;
using OpenQA.Selenium;

namespace DemoBlaze.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UserTest
{
    private static Browser _browser;
    private static WebDriver WebDriver => _browser.WebDriver;

    private By LoginNavButtonSelector => By.Id("login2");
    private IWebElement LoginNavButtonElement => WebDriver.FindElement(LoginNavButtonSelector);
    private By RegisterNavButtonSelector => By.Id("signin2");
    private IWebElement RegisterNavButtonElement => WebDriver.FindElement(RegisterNavButtonSelector);
    private IWebElement LoggedInUserNavElement => WebDriver.FindElement(By.Id("nameofuser"));

    private By LoginUsernameInputSelector => By.Id("loginusername");
    private IWebElement LoginUsernameInputElement => WebDriver.FindElement(LoginUsernameInputSelector);
    private IWebElement LoginPasswordInputElement => WebDriver.FindElement(By.Id("loginpassword"));
    private IWebElement LoginButtonElement => WebDriver.FindElement(By.CssSelector("button[onclick=\"logIn()\"]"));

    private By RegisterUsernameInputSelector => By.Id("sign-username");
    private IWebElement RegisterUsernameInputElement => WebDriver.FindElement(RegisterUsernameInputSelector);
    private IWebElement RegisterPasswordInputElement => WebDriver.FindElement(By.Id("sign-password"));
    private IWebElement RegisterButtonElement => WebDriver.FindElement(By.CssSelector("button[onclick=\"register()\"]"));
    
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
        _browser.WaitUntilPageLoads();
        
        _browser.WaitUntilElementIsPresent(LoginNavButtonSelector);
        LoginNavButtonElement.Click();
        
        _browser.WaitUntilElementIsPresent(LoginUsernameInputSelector);
        _browser.WaitForMillSec(1000); //until the login modal drops down
        LoginUsernameInputElement.Click();
        LoginUsernameInputElement.Clear();
        LoginUsernameInputElement.SendKeys(TestData.UserData.Username);
        LoginPasswordInputElement.Click();
        LoginPasswordInputElement.Clear();
        LoginPasswordInputElement.SendKeys(TestData.UserData.Password);
        LoginButtonElement.Click();
        
        _browser.WaitUntilPageLoads();
        _browser.WaitForMillSec(2000); //navbar data refreshed dynamically, login state only changes after some time
        Assert.That(LoggedInUserNavElement.Text, Is.EqualTo(TestData.LoggedInUserText), "The user isn't logged in according to the navbar.");
    }

    [Test]
    [Description("Should register a new user successfully.")]
    [Ignore("Since the site actually stores user data permanently without an option for account deletion, this test's ignored to avoid spam.")]
    public void Register()
    {
        _browser.WaitUntilPageLoads();
        
        _browser.WaitUntilElementIsPresent(RegisterNavButtonSelector);
        RegisterNavButtonElement.Click();

        //no need to get hard on the random generation, since we can't delete it in the teardown anyways
        string randomUsername = Random.Shared.Next(100, 900).ToString();
        
        _browser.WaitUntilElementIsPresent(RegisterUsernameInputSelector);
        _browser.WaitForMillSec(1000); //until the register modal drops down
        RegisterUsernameInputElement.Click();
        RegisterUsernameInputElement.Clear();
        RegisterUsernameInputElement.SendKeys(randomUsername);
        RegisterPasswordInputElement.Click();
        RegisterPasswordInputElement.Clear();
        RegisterPasswordInputElement.SendKeys(TestData.UserData.Password);
        RegisterButtonElement.Click();
        
        //assertion & other checks would go here if I had the power to implement the case correctly
    }

    [Test]
    [Description("Should throw a relevant error when an invalid password is provided for an existing user.")]
    public void LoginErrorHandling()
    {
        _browser.WaitUntilPageLoads();
        
        _browser.WaitUntilElementIsPresent(LoginNavButtonSelector);
        LoginNavButtonElement.Click();
        
        _browser.WaitUntilElementIsPresent(LoginUsernameInputSelector);
        _browser.WaitForMillSec(1000); //until the login modal drops down
        LoginUsernameInputElement.Click();
        LoginUsernameInputElement.Clear();
        LoginUsernameInputElement.SendKeys(TestData.UserData.Username);
        LoginPasswordInputElement.Click();
        LoginPasswordInputElement.Clear();
        LoginPasswordInputElement.SendKeys(TestData.UserData.InvalidPassword);
        LoginButtonElement.Click();
        
        _browser.WaitForMillSec(1000); //waits until the alert pops up
        _browser.CheckAlertMessage("Wrong password.");
    }
}