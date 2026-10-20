using AktivaloKod_VB_Lib;
using AktivaloKod_VB_Lib.Data;

namespace AktivaloKod_VB_UnitTests
{
    [TestFixture]
    internal class CodeValidatorTest
    {
        [Test]
        public void CheckIfReturnsValid_KGCW5321JUAH()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.valid1), Is.True);
        }

        [Test]
        public void CheckIfReturnsValid_AAAABBBBJCG1()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.valid2), Is.True);
        }

        [Test]
        public void CheckIfReturnsValid_CAJAVALA78G()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.valid3), Is.True);
        }

        [Test]
        public void CheckIfReturnsInvalid_MissingRequiredCharacters()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidMissingChars), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_MisplacedDashes()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidDashPlacement), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooManyJ()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidTooManyJ), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooManyDashes()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidTooManyDashes), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooShort()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidTooShort), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_TooLong()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidTooLong), Is.False);
        }

        [Test]
        public void CheckIfReturnsInvalid_BadSplit()
        {
            Assert.That(CodeValidator.CheckCodeValidity(SampleCodes.invalidBadSplit), Is.False);
        }
    }
}
