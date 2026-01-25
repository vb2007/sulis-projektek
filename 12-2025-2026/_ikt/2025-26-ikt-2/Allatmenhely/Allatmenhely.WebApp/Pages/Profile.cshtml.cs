using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages;

public class AccountModel : PageModel
{
    private readonly AuthService _authService;
    private readonly AnimalShelterContext _context;

    public AccountModel(AuthService authService, AnimalShelterContext context)
    {
        _authService = authService;
        _context = context;
    }

    public User? CurrentUser { get; set; }

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public string? FirstName { get; set; }

    [BindProperty]
    public string? LastName { get; set; }

    [BindProperty]
    public string? ProfilePictureUrl { get; set; }

    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login", new { returnUrl = "/Profile" });
        }

        Guid? userId = _authService.GetCurrentUserId();
        CurrentUser = await _context.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (CurrentUser == null)
        {
            _authService.Logout();
            return RedirectToPage("/Login");
        }

        Email = CurrentUser.Email;
        FirstName = CurrentUser.FirstName;
        LastName = CurrentUser.LastName;
        ProfilePictureUrl = CurrentUser.ProfilePictureUrl;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login", new { returnUrl = "/Profile" });
        }

        var userId = _authService.GetCurrentUserId();
        CurrentUser = await _context.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (CurrentUser == null)
        {
            _authService.Logout();
            return RedirectToPage("/Login");
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            ErrorMessage = "Email is required.";
            return Page();
        }

        if (!_authService.IsValidEmail(Email))
        {
            ErrorMessage = "Please enter a valid email address.";
            return Page();
        }

        if (Email != CurrentUser.Email)
        {
            var existingEmail = await _context.Users
                .Where(u => u.Email == Email && u.Id != userId)
                .FirstOrDefaultAsync();

            if (existingEmail != null)
            {
                ErrorMessage = "Email is already taken by another user.";
                return Page();
            }
        }

        CurrentUser.Email = Email;
        CurrentUser.FirstName = FirstName;
        CurrentUser.LastName = LastName;
        CurrentUser.ProfilePictureUrl = ProfilePictureUrl;
        CurrentUser.ModifiedOn = DateTime.Now;

        try
        {
            await _context.SaveChangesAsync();
            SuccessMessage = "Profile updated successfully!";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"An error occurred while updating profile: {ex.Message}";
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAccountAsync()
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login");
        }

        var userId = _authService.GetCurrentUserId();
        CurrentUser = await _context.Users
            .Include(u => u.Appointments)
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (CurrentUser == null)
        {
            _authService.Logout();
            return RedirectToPage("/Login");
        }

        try
        {
            if (CurrentUser.Appointments.Any())
            {
                _context.Appointments.RemoveRange(CurrentUser.Appointments);
            }

            _context.Users.Remove(CurrentUser);
            await _context.SaveChangesAsync();

            _authService.Logout();

            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"An error occurred while deleting account: {ex.Message}";
            return Page();
        }
    }
}
