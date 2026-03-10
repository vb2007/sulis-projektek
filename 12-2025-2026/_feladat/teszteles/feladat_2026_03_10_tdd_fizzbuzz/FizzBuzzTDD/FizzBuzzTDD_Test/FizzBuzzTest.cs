using FizzBuzzTDD_Lib;

namespace FizzBuzzTDD_Test;

public class FizzBuzzTest
{
    [Test]
    public void DivideBy3()
    {
        string result = FizzBuzz.FizzBuzzCheck(3);
        Assert.That(result, Is.EqualTo("Fizz"), "When the number 3 is used, it should return 'Fizz'.");
    }
    
    [Test]
    public void DivideBy2()
    {
        string result = FizzBuzz.FizzBuzzCheck(2);
        Assert.That(result, Is.EqualTo("2"), "When the number 2 is used, it should return '2' as a string.");
    }
    
    [Test]
    public void DivideBy5()
    {
        string result = FizzBuzz.FizzBuzzCheck(5);
        Assert.That(result, Is.EqualTo("Buzz"), "When the number 5 is used, it should return 'Fizz'.");
    }
    
    [Test]
    public void DivideByBoth()
    {
        string result = FizzBuzz.FizzBuzzCheck(15);
        Assert.That(result, Is.EqualTo("FizzBuzz"), "When the number 15 is used, it should return 'FizzBuzz'.");
    }
}