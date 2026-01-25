using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Appointments;

public class MyBookingsModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public MyBookingsModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public List<AppointmentViewModel> Appointments { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login");
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        await LoadAppointmentsAsync(userId.Value);

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid appointmentId)
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login");
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == appointmentId && a.ReservedBy == userId.Value);

        if (appointment == null)
        {
            TempData["ErrorMessage"] = "Az időpont nem található vagy nincs jogosultságod törölni.";
            return RedirectToPage();
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Időpont sikeresen törölve!";
        return RedirectToPage();
    }

    private async Task LoadAppointmentsAsync(Guid userId)
    {
        var appointments = await _context.Appointments
            .Include(a => a.ReservedToNavigation)
                .ThenInclude(animal => animal.Species)
            .Include(a => a.ReservedToNavigation)
                .ThenInclude(animal => animal.Breed)
            .Where(a => a.ReservedBy == userId)
            .OrderBy(a => a.AppointmentAt)
            .ToListAsync();

        Appointments = appointments.Select(a => new AppointmentViewModel
        {
            Id = a.Id,
            AppointmentAt = a.AppointmentAt,
            AnimalId = a.ReservedTo,
            AnimalName = a.ReservedToNavigation?.Name ?? "Ismeretlen",
            AnimalSpecies = a.ReservedToNavigation?.Species?.Name ?? "Ismeretlen",
            AnimalBreed = a.ReservedToNavigation?.Breed?.Name ?? "Ismeretlen",
            AnimalImageUrl = a.ReservedToNavigation?.ImageUrl,
            CreatedOn = a.CreatedOn,
            IsPast = a.AppointmentAt < DateTime.Now
        }).ToList();
    }

    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public DateTime AppointmentAt { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; } = string.Empty;
        public string AnimalSpecies { get; set; } = string.Empty;
        public string AnimalBreed { get; set; } = string.Empty;
        public string? AnimalImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPast { get; set; }
    }
}
