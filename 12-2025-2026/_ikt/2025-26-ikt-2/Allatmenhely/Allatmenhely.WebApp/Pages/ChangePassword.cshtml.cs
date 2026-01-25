using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages;

public class ChangePasswordModel : PageModel
{
    private readonly AuthService _authService;
    private readonly AnimalShelterContext _context;
    private readonly PasswordHasher _passwordHasher;

    public ChangePasswordModel(
        AuthService authService,
        AnimalShelterContext context,
        PasswordHasher passwordHasher)
    {
        _authService = authService;
        _context = context;
        _passwordHasher = passwordHasher;
    }

    [BindProperty]
    public string CurrentPassword { get; set; } = string.Empty;

    [BindProperty]
    public string NewPassword { get; set; } = string.Empty;

    [BindProperty]
    public string ConfirmNewPassword { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public IActionResult OnGet()
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login", new { returnUrl = "/ChangePassword" });
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login", new { returnUrl = "/ChangePassword" });
        }

        if (string.IsNullOrWhiteSpace(CurrentPassword))
        {
            ErrorMessage = "Jelenlegi jelszó megadása kötelező.";
            return Page();
        }

        if (string.IsNullOrWhiteSpace(NewPassword))
        {
            ErrorMessage = "Új jelszó megadása kötelező..";
            return Page();
        }

        if (NewPassword.Length < 6)
        {
            ErrorMessage = "Az új jelszónak minimum 6 karakter hosszúnak kell lennie.";
            return Page();
        }

        if (NewPassword != ConfirmNewPassword)
        {
            ErrorMessage = "Az új jelszavak nem egyeznek.";
            return Page();
        }

        if (CurrentPassword == NewPassword)
        {
            ErrorMessage = "Az új jelszónak különböznie kell a jelenlegi jelszótól.";
            return Page();
        }

        Guid? userId = _authService.GetCurrentUserId();
        var user = await _context.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            _authService.Logout();
            return RedirectToPage("/Login");
        }

        if (!_passwordHasher.VerifyPassword(CurrentPassword, user.PasswordHash))
        {
            ErrorMessage = "A jelenlegi jelszó helytelen.";
            return Page();
        }

        user.PasswordHash = _passwordHasher.HashPassword(NewPassword);
        user.ModifiedOn = DateTime.Now;

        try
        {
            await _context.SaveChangesAsync();
            SuccessMessage = "Jelszó sikeresen frissítve!";

            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmNewPassword = string.Empty;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba történt a jeszó megváltoztatása közben: {ex.Message}";
        }

        return Page();
    }
}
