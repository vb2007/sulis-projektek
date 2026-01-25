using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Appointments;

public class BookingModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public BookingModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public Animal? Animal { get; set; }
    public int AnimalId { get; set; }
    public DateTime StartDate { get; set; }
    public List<AppointmentSlot> AvailableSlots { get; set; } = new();

    [BindProperty]
    public DateTime SelectedDateTime { get; set; }

    public async Task<IActionResult> OnGetAsync(int animalId, DateTime? date)
    {
        if (!_authService.IsAuthenticated())
        {
            return RedirectToPage("/Login");
        }

        AnimalId = animalId;
        StartDate = date ?? DateTime.Today;

        if (StartDate < DateTime.Today)
        {
            StartDate = DateTime.Today;
        }

        Animal = await _context.Animals
            .Include(a => a.Species)
            .Include(a => a.Breed)
            .FirstOrDefaultAsync(a => a.Id == animalId);

        if (Animal == null)
        {
            return NotFound();
        }

        await LoadAvailableSlotsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int animalId)
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

        AnimalId = animalId;
        Animal = await _context.Animals
            .Include(a => a.Species)
            .Include(a => a.Breed)
            .FirstOrDefaultAsync(a => a.Id == animalId);

        if (Animal == null)
        {
            return NotFound();
        }

        if (SelectedDateTime < DateTime.Now)
        {
            ModelState.AddModelError("", "Múltbeli időpontra nem lehet foglalni.");
            await LoadAvailableSlotsAsync();
            return Page();
        }

        var existingAppointment = await _context.Appointments
            .AnyAsync(a => a.ReservedTo == animalId && a.AppointmentAt == SelectedDateTime);

        if (existingAppointment)
        {
            ModelState.AddModelError("", "Ez az időpont már foglalt.");
            await LoadAvailableSlotsAsync();
            return Page();
        }

        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            AppointmentAt = SelectedDateTime,
            ReservedTo = animalId,
            ReservedBy = userId.Value,
            CreatedOn = DateTime.Now
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Időpont sikeresen lefoglalva!";
        return RedirectToPage("/Appointments/MyBookings");
    }

    private async Task LoadAvailableSlotsAsync()
    {
        AvailableSlots = new List<AppointmentSlot>();

        var bookedAppointments = await _context.Appointments
            .Where(a => a.ReservedTo == AnimalId && a.AppointmentAt >= StartDate && a.AppointmentAt < StartDate.AddDays(7))
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

                AvailableSlots.Add(new AppointmentSlot
                {
                    DateTime = slotDateTime,
                    IsBooked = isBooked,
                    IsAvailable = !isBooked && !isPast
                });
            }
        }
    }

    public class AppointmentSlot
    {
        public DateTime DateTime { get; set; }
        public bool IsBooked { get; set; }
        public bool IsAvailable { get; set; }
    }
}
