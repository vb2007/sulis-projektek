using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Allatmenhely.WebApp.Pages;

public class LogoutModel : PageModel
{
    private readonly AuthService _authService;

    public LogoutModel(AuthService authService)
    {
        _authService = authService;
    }

    public IActionResult OnGet()
    {
        _authService.Logout();
        return RedirectToPage("/Index");
    }

    public IActionResult OnPost()
    {
        _authService.Logout();
        return RedirectToPage("/Index");
    }
}
