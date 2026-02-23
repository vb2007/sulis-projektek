using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.UserManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RegisterTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    private IWebElement UsernameInputElement => _webDriver.FindElement(By.Id("Username"));
    private IWebElement EmailInputElement => _webDriver.FindElement(By.Id("Email"));
    private IWebElement PasswordInputElement => _webDriver.FindElement(By.Id("Password"));
    private IWebElement ConfirmPasswordInputElement => _webDriver.FindElement(By.Id("ConfirmPassword"));

    private IWebElement RegisterButton => _webDriver.FindElement(By.CssSelector("button[type='submit']"));

    private IWebElement ErrorMessageContainerElement => _webDriver.FindElement(By.CssSelector("div.alert.alert-danger"));
    private IWebElement SuccessMessageContainerElement => _webDriver.FindElement(By.CssSelector("div.alert.alert-success"));

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);

        _browser = new Browser();
        _browser.Init();
        _webDriver.Navigate().GoToUrl(TestData._registerUrl);
    }

    [TearDown]
    public void TearDown()
    {
        _browser?.Teardown();

        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user can successfully register with valid credentials.")]
    public void RegisterSuccess()
    {
        _browser.WaitUntilPageLoads();

        string randomUsername = TestData.UserData.NewUsername + DateTime.Now.Ticks;
        string randomEmail = $"user{DateTime.Now.Ticks}@test.com";

        UsernameInputElement.SendKeys(randomUsername);
        EmailInputElement.SendKeys(randomEmail);
        PasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        ConfirmPasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        RegisterButton.Click();

        _browser.WaitUntilPageLoads();

        bool isSuccessMessageDisplayed = SuccessMessageContainerElement.Displayed;
        string actualSuccessMessage = SuccessMessageContainerElement.Text;

        Assert.That(isSuccessMessageDisplayed, Is.True, "Success message is not displayed.");
        Assert.That(actualSuccessMessage, Is.EqualTo(TestData.HomepageData.SuccessLoginMessageContainer), "Success message text is incorrect.");
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user cannot register with an existing username.")]
    public void RegisterUsernameAlreadyExists()
    {
        _browser.WaitUntilPageLoads();

        UsernameInputElement.SendKeys(TestData.UserData.ValidUsername); //valid username already in db
        EmailInputElement.SendKeys(TestData.UserData.ValidRegisteredEmail); //should be randomized
        PasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        ConfirmPasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        RegisterButton.Click();

        _browser.WaitUntilPageLoads();

        bool isErrorMessageDisplayed = ErrorMessageContainerElement.Displayed;
        string actualErrorMessage = ErrorMessageContainerElement.Text;

        Assert.That(isErrorMessageDisplayed, Is.True, "Error message is not displayed.");
        Assert.That(actualErrorMessage, Is.EqualTo(TestData.RegisterPageData.UsernameAlreadyExistsErrorMessage), "Error message text is incorrect.");
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user cannot register with an email that already exists.")]
    public void RegisterEmailAlreadyExists()
    {
        _browser.WaitUntilPageLoads();

        string randomUsername = TestData.UserData.NewUsername + DateTime.Now.Ticks;

        UsernameInputElement.SendKeys(randomUsername);
        EmailInputElement.SendKeys(TestData.UserData.ValidRegisteredEmail);
        PasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        ConfirmPasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        RegisterButton.Click();

        _browser.WaitUntilPageLoads();

        bool isErrorMessageDisplayed = ErrorMessageContainerElement.Displayed;
        string actualErrorMessage = ErrorMessageContainerElement.Text;

        Assert.That(isErrorMessageDisplayed, Is.True, "Error message is not displayed.");
        Assert.That(actualErrorMessage, Is.EqualTo(TestData.RegisterPageData.EmailAlreadyExistsErrorMessage), "Error message text is incorrect.");
    }
}
