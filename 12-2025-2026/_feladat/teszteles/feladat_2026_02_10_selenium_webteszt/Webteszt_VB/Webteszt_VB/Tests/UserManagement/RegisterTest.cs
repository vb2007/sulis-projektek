using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.UserManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RegisterTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);

        _browser = new Browser();
        _browser.Init();
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
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user cannot register with an invalid username.")]
    public void RegisterInvalidUsername()
    {
        _browser.WaitUntilPageLoads();
    }

    [Test]
    [Category("UserManagement")]
    [Description("Tests that a user cannot register with an invalid email.")]
    public void RegisterInvalidEmail()
    {
        _browser.WaitUntilPageLoads();
    }
}
