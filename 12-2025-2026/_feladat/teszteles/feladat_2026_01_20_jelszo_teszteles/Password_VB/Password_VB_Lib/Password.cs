using System.Globalization;

namespace Password_VB_Lib;

public class Password
{
    public static bool IsValid(string password)
    {
        if (new StringInfo(password).LengthInTextElements < 6)
            return false;

        bool hasUpper = false, hasLower = false, hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsLower(c)) hasLower = true;
            else if (char.IsDigit(c)) hasDigit = true;
            // else if (!char.IsLetterOrDigit(c)) hasSpecial = true;
        }

        return hasUpper && hasLower && hasDigit;
    }
}