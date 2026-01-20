using Password_VB_Lib;

namespace Password_VB_UnitTests;

[TestFixture]
public class PasswordTests
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
    
    [Test]
    public void SpecialUppercaseCharactersOnly()
    {
        string password = "a1ÁÉŰÚÜÓÖÍ";
        bool isValid = Password.IsValid(password);
        
        Assert.That(isValid, Is.True, $"The password should be valid: {password}");
    }
    
    [Test]
    public void UnicodeLengthCheck()
    {
        string password = "aA1😊😊";
        bool isValid = Password.IsValid(password);
        
        Assert.That(isValid, Is.False, $"The password shouldn't be valid: {password}");
    }
}