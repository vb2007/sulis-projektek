using AktivaloKod_VB_Lib;
using AktivaloKod_VB_Lib.Data;

namespace AktivaloKod_VB_UnitTests
{
    [TestFixture]
    internal class CodeValidatorErrorListTest
    {
        [TestCase("KGCW-5321-JUAH")]
        [TestCase("AAAA-BBBB-JCG1")]
        [TestCase("CAJAVALA789G")]
        public void ValidReturnsTrueAndEmptyErrorList(string code)
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(code, out List<string> errors);

            Assert.That(result, Is.True);
            Assert.That(errors, Is.Empty);
        }

        [Test]
        public void NullReturnsNullError()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(null!, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EqualTo(new[] { ErrorMessages.ErrorNull }));
        }

        [Test]
        public void MissingCharsReturnsMissingGCAndJAndDigit()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidMissingChars, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EquivalentTo(new[]
            {
                ErrorMessages.ErrorMissingG,
                ErrorMessages.ErrorJCount,
                ErrorMessages.ErrorMissingDigit,
            }));
        }

        [Test]
        public void WrongDashesReturnsFormatAndJCountErrors()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidDashPlacement, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EquivalentTo(new[]
            {
                ErrorMessages.ErrorFormat,
                ErrorMessages.ErrorJCount,
            }));
        }

        [Test]
        public void ManyJReturnsOnlyJCountError()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidTooManyJ, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EqualTo(new[] { ErrorMessages.ErrorJCount }));
        }

        [Test]
        public void ManyDashesReturnsOnlyFormatError()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidTooManyDashes, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EqualTo(new[] { ErrorMessages.ErrorFormat }));
        }

        [Test]
        public void ShortReturnsOnlyFormatError()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidTooShort, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EqualTo(new[] { ErrorMessages.ErrorFormat }));
        }

        [Test]
        public void LongReturnsOnlyFormatError()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidTooLong, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EqualTo(new[] { ErrorMessages.ErrorFormat }));
        }

        [Test]
        public void WrongSplitReturnsOnlyFormatError()
        {
            bool result = CodeValidator.CheckCodeValidityWithErrorHandling(SampleCodes.invalidBadSplit, out List<string> errors);

            Assert.That(result, Is.False);
            Assert.That(errors, Is.EqualTo(new[] { ErrorMessages.ErrorFormat }));
        }

        [Test]
        public void ErrorListMatchesSample()
        {
            foreach (string code in SampleCodes.sampleCodeList)
            {
                bool withErrors = CodeValidator.CheckCodeValidityWithErrorHandling(code, out List<string> errors);

                Assert.That(withErrors, Is.EqualTo(CodeValidator.CheckCodeValidity(code)), code);
                Assert.That(errors.Count == 0, Is.EqualTo(withErrors), code);
            }
        }
    }
}
