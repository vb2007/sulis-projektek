using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Allatmenhely.WebApp.Pages;

public class RegisterModel : PageModel
{
    private readonly AuthService _authService;

    public RegisterModel(AuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public string ConfirmPassword { get; set; } = string.Empty;

    [BindProperty]
    public string? FirstName { get; set; }

    [BindProperty]
    public string? LastName { get; set; }

    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public IActionResult OnGet()
    {
        //bejelentkezett állapot esetén átirányítás főoldalra
        if (_authService.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (_authService.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }

        // Basic validation
        if (string.IsNullOrWhiteSpace(Username))
        {
            ErrorMessage = "Username is required.";
            return Page();
        }

        if (!_authService.IsValidUsername(Username))
        {
            ErrorMessage = "Username must be 3-100 characters and contain only letters, numbers, underscores, or hyphens.";
            return Page();
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            ErrorMessage = "Adj meg egy e-mail címet.";
            return Page();
        }

        if (!_authService.IsValidEmail(Email))
        {
            ErrorMessage = "Adj meg egy érvényes e-mail címet.";
            return Page();
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "A jelszó megadása kötelező.";
            return Page();
        }

        if (Password.Length < 6)
        {
            ErrorMessage = "A jelszónak minimum 6 karakter hosszúnak kell lennie.";
            return Page();
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "A jelszavak nem egyeznek.";
            return Page();
        }

        var (success, message, user) = await _authService.RegisterUserAsync(
            Username,
            Email,
            Password,
            FirstName,
            LastName
        );

        if (!success)
        {
            ErrorMessage = message;
            return Page();
        }

        //auto-login
        await _authService.LoginAsync(Username, Password);

        return RedirectToPage("/Index");
    }
}
