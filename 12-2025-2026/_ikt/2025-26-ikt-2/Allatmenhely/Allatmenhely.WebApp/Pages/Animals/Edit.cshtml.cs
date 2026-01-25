using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Animals;

public class EditModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public EditModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public string Name { get; set; } = string.Empty;

    [BindProperty]
    public string? Description { get; set; }

    [BindProperty]
    public string? ImageUrl { get; set; }

    [BindProperty]
    public int SpeciesId { get; set; }

    [BindProperty]
    public int BreedId { get; set; }

    public List<SelectListItem> SpeciesList { get; set; } = new();
    public List<SelectListItem> BreedsList { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        var animal = await _context.Animals
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (animal == null)
        {
            return NotFound();
        }

        Id = animal.Id;
        Name = animal.Name;
        Description = animal.Description;
        ImageUrl = animal.ImageUrl;
        SpeciesId = animal.SpeciesId;
        BreedId = animal.BreedId;

        await LoadSelectListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        if (string.IsNullOrWhiteSpace(Name))
        {
            ErrorMessage = "A név megadása kötelező.";
            await LoadSelectListsAsync();
            return Page();
        }

        if (SpeciesId <= 0)
        {
            ErrorMessage = "A faj kiválasztása kötelező.";
            await LoadSelectListsAsync();
            return Page();
        }

        if (BreedId <= 0)
        {
            ErrorMessage = "A fajta kiválasztása kötelező.";
            await LoadSelectListsAsync();
            return Page();
        }

        var animal = await _context.Animals
            .Where(a => a.Id == Id)
            .FirstOrDefaultAsync();

        if (animal == null)
        {
            return NotFound();
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        animal.Name = Name;
        animal.Description = Description;
        animal.ImageUrl = ImageUrl;
        animal.SpeciesId = SpeciesId;
        animal.BreedId = BreedId;
        animal.ModifiedOn = DateTime.Now;
        animal.ModifiedBy = userId.Value;

        try
        {
            await _context.SaveChangesAsync();
            SuccessMessage = "Állat adatai sikeresen frissítve!";
            await LoadSelectListsAsync();
            return Page();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
            await LoadSelectListsAsync();
            return Page();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        var animal = await _context.Animals
            .Include(a => a.Appointments)
            .Where(a => a.Id == Id)
            .FirstOrDefaultAsync();

        if (animal == null)
        {
            return NotFound();
        }

        try
        {
            //időpontok kitörlése
            if (animal.Appointments.Any())
            {
                _context.Appointments.RemoveRange(animal.Appointments);
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Animals/Index");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel a törlés közben: {ex.Message}";
            await LoadSelectListsAsync();
            return Page();
        }
    }

    private async Task LoadSelectListsAsync()
    {
        SpeciesList = await _context.AnimalsSpecies
            .OrderBy(s => s.Name)
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
            .ToListAsync();

        BreedsList = await _context.AnimalsBreeds
            .OrderBy(b => b.Name)
            .Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            })
            .ToListAsync();
    }
}
