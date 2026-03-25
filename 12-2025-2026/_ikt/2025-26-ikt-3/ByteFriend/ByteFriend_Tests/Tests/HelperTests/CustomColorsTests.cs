using ByteFriend_Lib.Helpers;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.HelperTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CustomColorsTests
{
    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);
    }

    [TearDown]
    public void TearDown()
    {
        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that a valid hex color string with a hash does not throw.")]
    public void Constructor_ValidHexWithHash_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            CustomColors customColors = new CustomColors("#FF0000");
        });
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that a valid hex color string without a hash does not throw.")]
    public void Constructor_ValidHexWithoutHash_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            CustomColors customColors = new CustomColors("00FF00");
        });
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that an invalid hex color string throws an ArgumentException.")]
    public void Constructor_InvalidHex_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            CustomColors customColors = new CustomColors("ZZZZZZ");
        });
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that an empty string throws an ArgumentException.")]
    public void Constructor_EmptyString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            CustomColors customColors = new CustomColors("");
        });
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that a short hex string throws an ArgumentException.")]
    public void Constructor_TooShortHex_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            CustomColors customColors = new CustomColors("#FFF");
        });
    }

    [Test]
    [Category("Helpers")]
    [Description("Checks if Colorize returns the original text within the output.")]
    public void Colorize_ContainsOriginalText()
    {
        CustomColors color = new CustomColors("#FF0000");
        string result = color.Colorize("Hello");
        Assert.That(result, Does.Contain("Hello"));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that the colorized output contains ANSI escape sequences.")]
    public void Colorize_ContainsAnsiEscapeCodes()
    {
        CustomColors color = new CustomColors("#FF0000");
        string result = color.Colorize("Test");
        Assert.That(result, Does.Contain("\x1b[38;2;255;0;0m"));
        Assert.That(result, Does.Contain("\x1b[0m"));
    }

    [Test]
    [Category("Helpers")]
    [Description("Checks if ToString returns the correctly formatted hex and RGB values.")]
    public void ToString_ContainsHexAndRgbValues()
    {
        CustomColors color = new CustomColors("#0A1B2C");
        string result = color.ToString();
        Assert.That(result, Does.Contain("#0A1B2C"));
        Assert.That(result, Does.Contain("R:10"));
        Assert.That(result, Does.Contain("G:27"));
        Assert.That(result, Does.Contain("B:44"));
    }

    [Test]
    [Category("Helpers")]
    [Description("Checks if Colorize works correctly with an empty string input.")]
    public void Colorize_EmptyString_ReturnsAnsiCodesOnly()
    {
        CustomColors color = new CustomColors("#000000");
        string result = color.Colorize("");
        Assert.That(result, Does.Contain("\x1b[38;2;0;0;0m"));
        Assert.That(result, Does.Contain("\x1b[0m"));
    }
}
