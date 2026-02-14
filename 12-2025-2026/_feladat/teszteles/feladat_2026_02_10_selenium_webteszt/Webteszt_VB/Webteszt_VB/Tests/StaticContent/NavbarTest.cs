using Webteszt_VB.Helpers;
using OpenQA.Selenium;

namespace Webteszt_VB.Tests.StaticContent;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class NavbarTest
{
    private static Browser _browser;
    private static WebDriver _webDriver => _browser.WebDriver;

    public IWebElement TitleElement => _webDriver.FindElement(By.CssSelector("nav div a.navbar-brand"));
    public IWebElement HomepageLinkElement => _webDriver.FindElement(By.CssSelector("ul.navbar-nav li:nth-of-type(1)"));
    public IWebElement AnimalsLinkElement => _webDriver.FindElement(By.CssSelector("ul.navbar-nav li:nth-of-type(2)"));
    public IWebElement LoginButtonElement => _webDriver.FindElement(By.CssSelector("ul.navbar-nav:nth-of-type(2) li:nth-of-type(1) a"));
    public IWebElement RegisterButtonElement => _webDriver.FindElement(By.CssSelector("ul.navbar-nav:nth-of-type(2) li:nth-of-type(2) a"));

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
    [Category("StaticContent")]
    [Description("Checks the navbar's title.")]
    public void CheckNavbarTitle()
    {
        string actualTitle = TitleElement.Text;
        Assert.That(actualTitle, Is.EqualTo(TestData.NavbarData.NavbarTitle), "The navbar title is incorrect.");
    }

    [Test]
    [Category("StaticContent")]
    [Description("Checks the page links on the navbar.")]
    public void CheckNavbarLinks()
    {
        string actualHomepageLinkText = HomepageLinkElement.Text;
        string actualAnimalsLinkText = AnimalsLinkElement.Text;

        Assert.That(actualHomepageLinkText, Is.EqualTo(TestData.NavbarData.HomepageLinkText), "The homepage link text is incorrect.");
        Assert.That(actualAnimalsLinkText, Is.EqualTo(TestData.NavbarData.AnimalsLinkText), "The animals link text is incorrect.");
    }

    [Test]
    [Category("StaticContent")]
    [Description("Checks the user management buttons on the navbar.")]
    public void CheckUserManagementButtons()
    {
        string actualLoginButtonText = LoginButtonElement.Text;
        string actualRegisterButtonText = RegisterButtonElement.Text;

        Assert.That(actualLoginButtonText, Is.EqualTo(TestData.NavbarData.LoginButtonText), "The login button text is incorrect.");
        Assert.That(actualRegisterButtonText, Is.EqualTo(TestData.NavbarData.RegisterButtonText), "The register button text is incorrect.");
    }
}
