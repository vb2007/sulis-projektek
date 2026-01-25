using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Appointments;

public class ManageModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public ManageModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public Animal? Animal { get; set; }
    public int AnimalId { get; set; }
    public List<UserAppointmentGroup> AppointmentGroups { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int animalId)
    {
        if (!_authService.IsAuthenticated() || !_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Index");
        }

        AnimalId = animalId;

        Animal = await _context.Animals
            .Include(a => a.Species)
            .Include(a => a.Breed)
            .FirstOrDefaultAsync(a => a.Id == animalId);

        if (Animal == null)
        {
            return NotFound();
        }

        await LoadAppointmentsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid appointmentId, int animalId)
    {
        if (!_authService.IsAuthenticated() || !_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Index");
        }

        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == appointmentId && a.ReservedTo == animalId);

        if (appointment == null)
        {
            TempData["ErrorMessage"] = "Az időpont nem található.";
            return RedirectToPage(new { animalId });
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Időpont sikeresen törölve!";
        return RedirectToPage(new { animalId });
    }

    public async Task<IActionResult> OnPostDeleteAllAsync(int animalId)
    {
        if (!_authService.IsAuthenticated() || !_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Index");
        }

        var appointments = await _context.Appointments
            .Where(a => a.ReservedTo == animalId)
            .ToListAsync();

        if (!appointments.Any())
        {
            TempData["ErrorMessage"] = "Nincs törlendő időpont.";
            return RedirectToPage(new { animalId });
        }

        _context.Appointments.RemoveRange(appointments);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"{appointments.Count} időpont sikeresen törölve!";
        return RedirectToPage(new { animalId });
    }

    private async Task LoadAppointmentsAsync()
    {
        var appointments = await _context.Appointments
            .Include(a => a.ReservedByNavigation)
            .Where(a => a.ReservedTo == AnimalId)
            .OrderBy(a => a.AppointmentAt)
            .ToListAsync();

        AppointmentGroups = appointments
            .GroupBy(a => a.ReservedByNavigation)
            .Select(g => new UserAppointmentGroup
            {
                UserId = g.Key.Id,
                Username = g.Key.Username,
                UserEmail = g.Key.Email,
                Appointments = g.Select(a => new AppointmentViewModel
                {
                    Id = a.Id,
                    AppointmentAt = a.AppointmentAt,
                    CreatedOn = a.CreatedOn,
                    IsPast = a.AppointmentAt < DateTime.Now
                }).OrderBy(a => a.AppointmentAt).ToList()
            })
            .OrderBy(g => g.Username)
            .ToList();
    }

    public class UserAppointmentGroup
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public List<AppointmentViewModel> Appointments { get; set; } = new();
    }

    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public DateTime AppointmentAt { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPast { get; set; }
    }
}
