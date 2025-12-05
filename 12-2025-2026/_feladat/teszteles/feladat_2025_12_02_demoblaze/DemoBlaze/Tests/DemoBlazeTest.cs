using DemoBlaze.Helpers;

namespace DemoBlaze.Tests;

[TestFixture]
public class Tests
{
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