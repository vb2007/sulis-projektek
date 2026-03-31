using LeapYearTDD_VB_Library;

namespace LeapYearTDD_VB_Test;

[TestFixture]
public class LeapYearTest
{
    private string ErrorMessage(int year, bool expected, bool actual) => $"Ha az év {year}, a várható eredmény {expected}, de a teszt {actual}-t adott vissza.";
    
    [Test]
    public void Year2021()
    {
        int year = 2021;
        Assert.That(LeapYear.IsLeapYear(year), Is.False, ErrorMessage(year, false, true));
    }

    [Test]
    public void Year2024()
    {
        int year = 2024;
        Assert.That(LeapYear.IsLeapYear(year), Is.True, $"Ha az év {year}, a várható eredmény True, de a teszt False-t adott vissza.");
    }
}