using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Appointments;

public class EditModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public EditModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public Appointment? Appointment { get; set; }
    public Animal? Animal { get; set; }
    public DateTime StartDate { get; set; }
    public List<AppointmentSlot> AvailableSlots { get; set; } = new();

    [BindProperty]
    public DateTime SelectedDateTime { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id, DateTime? date)
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

        Appointment = await _context.Appointments
            .Include(a => a.ReservedToNavigation)
                .ThenInclude(animal => animal.Species)
            .Include(a => a.ReservedToNavigation)
                .ThenInclude(animal => animal.Breed)
            .FirstOrDefaultAsync(a => a.Id == id && a.ReservedBy == userId.Value);

        if (Appointment == null)
        {
            return NotFound();
        }

        if (Appointment.AppointmentAt < DateTime.Now)
        {
            TempData["ErrorMessage"] = "Múltbeli időpontot nem lehet módosítani.";
            return RedirectToPage("/Appointments/MyBookings");
        }

        Animal = Appointment.ReservedToNavigation;
        StartDate = date ?? DateTime.Today;

        if (StartDate < DateTime.Today)
        {
            StartDate = DateTime.Today;
        }

        await LoadAvailableSlotsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
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

        Appointment = await _context.Appointments
            .Include(a => a.ReservedToNavigation)
                .ThenInclude(animal => animal.Species)
            .Include(a => a.ReservedToNavigation)
                .ThenInclude(animal => animal.Breed)
            .FirstOrDefaultAsync(a => a.Id == id && a.ReservedBy == userId.Value);

        if (Appointment == null)
        {
            return NotFound();
        }

        Animal = Appointment.ReservedToNavigation;

        if (SelectedDateTime < DateTime.Now)
        {
            ModelState.AddModelError("", "Múltbeli időpontra nem lehet módosítani.");
            await LoadAvailableSlotsAsync();
            return Page();
        }

        if (SelectedDateTime == Appointment.AppointmentAt)
        {
            ModelState.AddModelError("", "Az új időpont megegyezik a régivel.");
            await LoadAvailableSlotsAsync();
            return Page();
        }

        var existingAppointment = await _context.Appointments
            .AnyAsync(a => a.ReservedTo == Appointment.ReservedTo && a.AppointmentAt == SelectedDateTime && a.Id != id);

        if (existingAppointment)
        {
            ModelState.AddModelError("", "Ez az időpont már foglalt.");
            await LoadAvailableSlotsAsync();
            return Page();
        }

        Appointment.AppointmentAt = SelectedDateTime;
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Időpont sikeresen módosítva!";
        return RedirectToPage("/Appointments/MyBookings");
    }

    private async Task LoadAvailableSlotsAsync()
    {
        AvailableSlots = new List<AppointmentSlot>();

        if (Appointment == null)
        {
            return;
        }

        var animalId = Appointment.ReservedTo;

        var bookedAppointments = await _context.Appointments
            .Where(a => a.ReservedTo == animalId && 
                        a.AppointmentAt >= StartDate && 
                        a.AppointmentAt < StartDate.AddDays(7) &&
                        a.Id != Appointment.Id)
            .Select(a => a.AppointmentAt)
            .ToListAsync();

        for (int day = 0; day < 7; day++)
        {
            var currentDate = StartDate.AddDays(day);

            for (int hour = 0; hour < 24; hour++)
            {
                var slotDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, hour, 0, 0);

                bool isBooked = bookedAppointments.Contains(slotDateTime);
                bool isPast = slotDateTime < DateTime.Now;
                bool isCurrent = Appointment != null && slotDateTime == Appointment.AppointmentAt;

                AvailableSlots.Add(new AppointmentSlot
                {
                    DateTime = slotDateTime,
                    IsBooked = isBooked,
                    IsAvailable = !isBooked && !isPast,
                    IsCurrent = isCurrent
                });
            }
        }
    }

    public class AppointmentSlot
    {
        public DateTime DateTime { get; set; }
        public bool IsBooked { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsCurrent { get; set; }
    }
}
