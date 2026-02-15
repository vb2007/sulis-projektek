using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.UserManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LoginTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    private IWebElement UsernameInputElement => _webDriver.FindElement(By.Id("Username"));
    private IWebElement PasswordInputElement => _webDriver.FindElement(By.Id("Password"));
    private IWebElement LoginButtonElement => _webDriver.FindElement(By.CssSelector("button.btn.btn-primary"));

    private IWebElement ErrorMessageContainerElement => _webDriver.FindElement(By.CssSelector("div.alert.alert-danger")); //on login page
    private IWebElement SuccessLoginMessageContainerElement => _webDriver.FindElement(By.CssSelector("div.alert.alert-success")); //on homepage after redirect

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);

        _browser = new Browser();
        _browser.Init();
        _webDriver.Navigate().GoToUrl(TestData._loginUrl);
    }

    [TearDown]
    public void TearDown()
    {
        _browser?.Teardown();

        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user can successfully log in with valid credentials.")]
    public void LoginSuccess()
    {
        _browser.WaitUntilPageLoads();

        UsernameInputElement.SendKeys(TestData.UserData.ValidUsername);
        PasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        LoginButtonElement.Click();

        _browser.WaitUntilPageLoads();

        bool isSuccessMessageDisplayed = SuccessLoginMessageContainerElement.Displayed;
        string actualSuccessMessage = SuccessLoginMessageContainerElement.GetDomProperty("innerText")!;

        Assert.That(isSuccessMessageDisplayed, Is.True, "Success login message is not displayed.");
        Assert.That(actualSuccessMessage, Is.EqualTo(TestData.HomepageData.SuccessLoginMessageContainer), "Success login message text is incorrect.");
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user cannot log in with an invalid username.")]
    public void LoginInvalidUsername()
    {
        _browser.WaitUntilPageLoads();

        UsernameInputElement.SendKeys(TestData.UserData.InvalidUsername);
        PasswordInputElement.SendKeys(TestData.UserData.ValidPassword);
        LoginButtonElement.Click();

        _browser.WaitUntilPageLoads();

        string actualErrorMessage = ErrorMessageContainerElement.Text;
        Assert.That(actualErrorMessage, Is.EqualTo(TestData.LoginPageData.InvalidCredentialsErrorMessage), "Error message text is incorrect.");
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user cannot log in with an invalid password.")]
    public void LoginInvalidPassword()
    {
        _browser.WaitUntilPageLoads();

        UsernameInputElement.SendKeys(TestData.UserData.ValidUsername);
        PasswordInputElement.SendKeys(TestData.UserData.InvalidPassword);
        LoginButtonElement.Click();

        _browser.WaitUntilPageLoads();

        string actualErrorMessage = ErrorMessageContainerElement.Text;
        Assert.That(actualErrorMessage, Is.EqualTo(TestData.LoginPageData.InvalidPasswordErrorMessage), "Error message text is incorrect.");
    }
}
