using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Allatmenhely.WebApp.Pages;

public class LoginModel : PageModel
{
    private readonly AuthService _authService;

    public LoginModel(AuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public string? ReturnUrl { get; set; }

    public string? ErrorMessage { get; set; }

    public IActionResult OnGet(string? returnUrl = null)
    {
        //ha már be van jelentkezve, átirányítás főoldalra
        if (_authService.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }

        ReturnUrl = returnUrl;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (_authService.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }

        if (string.IsNullOrWhiteSpace(Username))
        {
            ErrorMessage = "Felhasználónév megadása kötelező.";
            return Page();
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Jelszó megadása kötelező.";
            return Page();
        }

        var (success, message, user) = await _authService.LoginAsync(Username, Password);

        if (!success)
        {
            ErrorMessage = message;
            return Page();
        }

        //redirect login után
        if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
        {
            return Redirect(ReturnUrl);
        }

        return RedirectToPage("/Index");
    }
}
