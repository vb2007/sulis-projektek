namespace DemoBlaze;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        InitTestFixture();
    }

    [TearDown]
    public void TearDown()
    {
        TeardownTestFixture();
    }
}