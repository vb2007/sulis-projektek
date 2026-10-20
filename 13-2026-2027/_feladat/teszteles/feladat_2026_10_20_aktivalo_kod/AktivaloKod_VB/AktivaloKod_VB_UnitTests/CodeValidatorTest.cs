using AktivaloKod_VB_Lib;

namespace AktivaloKod_VB_UnitTests
{
    [TestFixture]
    internal class CodeValidatorTest
    {
        string valid1 = "KGCW-5321-JUAH";
        string valid2 = "AAAA-BBBB-JCG1";
        string valid3 = "CAJAVALA78G";
        string invalidMissingChars = "AAAA-BBBB-CCCC";
        string invalidDashPlacement = "--GGJJCCCC1234";
        string invalidTooManyJ = "ggjj-cccc-1234";
        string invalidTooManyDashes = "AA-AA-GC-GG-5J-T0";
        string invalidTooShort = "CAJAVA78G";
        string invalidTooLong = "JACA-UU1G-1MOP1";
        string invalidBadSplit = "JACA-UU1G1MOP1";

        [Test]
        public void CheckIfReturnsValid_KGCW5321JUAH()
        {
            Assert.That(CodeValidator.CheckCodeValidity(valid1), Is.True);
        }

        [Test]
        public void CheckIfReturnsValid_AAAABBBBJCG1()
        {
            Assert.That(CodeValidator.CheckCodeValidity(valid2), Is.True);
        }

        [Test]
        public void CheckIfReturnsValid_CAJAVALA78G()
        {
            Assert.That(CodeValidator.CheckCodeValidity(valid3), Is.True);
        }

        [Test]
        public void CheckIfReturnsInvalid_MissingRequiredCharacters()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidMissingChars), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_MisplacedDashes()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidDashPlacement), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooManyJ()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidTooManyJ), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooManyDashes()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidTooManyDashes), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooShort()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidTooShort), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooLong()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidTooLong), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_BadSplit()
        {
            Assert.That(CodeValidator.CheckCodeValidity(invalidBadSplit), Is.False);
        }
    }
}
