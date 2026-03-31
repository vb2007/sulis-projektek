using LeapYearTDD_VB_Library;

namespace LeapYearTDD_VB_Test;

[TestFixture]
public class LeapYearTest
{
    [Test]
    public void Year2021()
    {
        int year = 2021;
        Assert.That(LeapYear.IsLeapYear(year), Is.False, $"Ha az év {year}, a várható eredmény False, de a teszt True-t adott vissza.");
    }

    
}