using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Services;

public class AuthService
{
    private readonly AnimalShelterContext _context;
    private readonly PasswordHasher _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private const string UserIdSessionKey = "UserId";
    private const string UsernameSessionKey = "Username";
    private const string IsAdminSessionKey = "IsAdmin";

    public AuthService(
        AnimalShelterContext context,
        PasswordHasher passwordHasher,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<(bool Success, string Message, User? User)> RegisterUserAsync(
        string username,
        string email,
        string password,
        string? firstName = null,
        string? lastName = null)
    {
        if (string.IsNullOrWhiteSpace(username))
            return (false, "Felhasználónév megadása kötelező.", null);

        if (string.IsNullOrWhiteSpace(email))
            return (false, "E-mail cím megadása kötelező.", null);

        if (string.IsNullOrWhiteSpace(password))
            return (false, "Jelszó megadása kötelező.", null);

        if (password.Length < 6)
            return (false, "A jelszónak minimum 6 karakternek kell lennie.", null);

        User? existingUser = await _context.Users
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync();

        if (existingUser != null)
            return (false, "Ez a felhasználónév már használatban van.", null);

        User? existingEmail = await _context.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();

        if (existingEmail != null)
            return (false, "Az az e-mail cím már használatban van.", null);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            PasswordHash = _passwordHasher.HashPassword(password),
            FirstName = firstName,
            LastName = lastName,
            CreatedOn = DateTime.Now,
            IsAdmin = false, //db-ből állítjuk manuálisan
            ProfilePictureUrl = null,
            ModifiedOn = null
        };

        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return (true, "Sikeres regisztráció!", user);
        }
        catch (Exception ex)
        {
            return (false, $"Hiba történt a regisztráció közben: {ex.Message}", null);
        }
    }

    public async Task<(bool Success, string Message, User? User)> LoginAsync(
        string username,
        string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            return (false, "Felhasználónév megadása kötelező.", null);

        if (string.IsNullOrWhiteSpace(password))
            return (false, "Jelszó megadása kötelező.", null);

        var user = await _context.Users
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync();

        if (user == null)
            return (false, "Érvénytelen felhasználónév vagy jelszó.", null);

        if (!_passwordHasher.VerifyPassword(password, user.PasswordHash))
            return (false, "Érvénytelen jelszó.", null);

        var session = _httpContextAccessor.HttpContext?.Session;
        if (session != null)
        {
            session.SetString(UserIdSessionKey, user.Id.ToString());
            session.SetString(UsernameSessionKey, user.Username);
            session.SetString(IsAdminSessionKey, user.IsAdmin.ToString());
        }

        return (true, "Sikeres bejelentkezés!", user);
    }

    public void Logout()
    {
        _httpContextAccessor.HttpContext?.Session.Clear();
    }

    public Guid? GetCurrentUserId()
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        var userIdString = session?.GetString(UserIdSessionKey);

        if (Guid.TryParse(userIdString, out var userId))
            return userId;

        return null;
    }

    public string? GetCurrentUsername()
    {
        return _httpContextAccessor.HttpContext?.Session.GetString(UsernameSessionKey);
    }

    public bool IsCurrentUserAdmin()
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        var isAdminString = session?.GetString(IsAdminSessionKey);

        if (bool.TryParse(isAdminString, out var isAdmin))
            return isAdmin;

        return false;
    }

    public bool IsAuthenticated()
    {
        return GetCurrentUserId() != null;
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        var userId = GetCurrentUserId();
        if (userId == null)
            return null;

        return await _context.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();
    }

    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public bool IsValidUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        if (username.Length < 3 || username.Length > 100)
            return false;

        //should only contain letters, numbers, underscores, hyphens
        return username.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-');
    }
}
