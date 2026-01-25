using System.Security.Cryptography;
using System.Text;

namespace Allatmenhely.WebApp.Services;

public class PasswordHasher
{
    private const int SaltSize = 16; //128 bit
    private const int KeySize = 32; //256 bit
    private const int Iterations = 100000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be empty", nameof(password));
        }

        //generate random salt
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        //hash the password
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithm,
            KeySize
        );

        //salt + hash combination
        var hashBytes = new byte[SaltSize + KeySize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

        //=> base64
        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(hashedPassword))
        {
            return false;
        }

        try
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithm,
                KeySize
            );

            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}
