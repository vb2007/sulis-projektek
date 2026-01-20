using Password_VB_Lib;

namespace Password_VB_UnitTests;

[TestFixture]
public class Tests
{
    [Test]
    public void ValidPassword()
    {
        string password = "aBc123";
        bool isValid = Password.IsValid(password);
        
        Assert.That(isValid, Is.True, $"The password should be valid: {password}");
    }

    [Test]
    public void SpecialLowercaseCharactersOnly()
    {
        string password = "A1áéűúüóöí";
        bool isValid = Password.IsValid(password);
        
        Assert.That(isValid, Is.True, $"The password should be valid: {password}");
    }
}