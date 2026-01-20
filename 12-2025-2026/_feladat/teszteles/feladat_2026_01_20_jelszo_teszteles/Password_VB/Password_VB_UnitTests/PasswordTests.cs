using Password_VB_Lib;

namespace Password_VB_UnitTests;

[TestFixture]
public class Tests
{
    [Test]
    public void ValidPassword()
    {
        bool isValid = Password.IsValid("aBc123");
        
        Assert.That(isValid, Is.True, "The password should be valid.");
    }

    [Test]
    public void SpecialLowercaseCharactersOnly()
    {
        
    }
}