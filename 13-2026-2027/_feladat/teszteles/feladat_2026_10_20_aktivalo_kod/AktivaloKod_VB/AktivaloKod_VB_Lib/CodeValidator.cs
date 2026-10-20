using System.Text.RegularExpressions;

namespace AktivaloKod_VB_Lib
{
    public class CodeValidator
    {
        private static readonly Regex FormatPattern =
            new Regex(@"^(?:[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}|[A-Za-z0-9]{12})$");

        public static bool CheckCodeValidity(string code)
        {
            if (!HasValidFormat(code))
            {
                return false;
            }

            string normalized = code.Replace("-", "").ToUpperInvariant();

            return HasRequiredLetters(normalized) && HasDigit(normalized);
        }

        private static bool HasValidFormat(string code)
        {
            return code != null && FormatPattern.IsMatch(code);
        }

        private static bool HasRequiredLetters(string normalizedCode)
        {
            return normalizedCode.Contains('G')
                && normalizedCode.Contains('C')
                && normalizedCode.Count(c => c == 'J') == 1;
        }

        private static bool HasDigit(string normalizedCode)
        {
            return normalizedCode.Any(c => c >= '0' && c <= '9');
        }
    }
}
