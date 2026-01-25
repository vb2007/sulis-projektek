using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Species;

public class IndexModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public IndexModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public List<AnimalsSpecy> SpeciesList { get; set; } = new();

    [BindProperty]
    public string? NewSpeciesName { get; set; }

    [BindProperty]
    public int? EditId { get; set; }

    [BindProperty]
    public string? EditName { get; set; }

    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int? editId, string? editName)
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        EditId = editId;
        EditName = editName;

        await LoadSpeciesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        if (string.IsNullOrWhiteSpace(NewSpeciesName))
        {
            ErrorMessage = "A név megadása kötelező.";
            await LoadSpeciesAsync();
            return Page();
        }

        var exists = await _context.AnimalsSpecies
            .AnyAsync(s => s.Name == NewSpeciesName);

        if (exists)
        {
            ErrorMessage = "A species with this name already exists.";
            await LoadSpeciesAsync();
            return Page();
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        var species = new AnimalsSpecy
        {
            Name = NewSpeciesName,
            CreatedOn = DateTime.Now,
            CreatedBy = userId.Value
        };

        try
        {
            _context.AnimalsSpecies.Add(species);
            await _context.SaveChangesAsync();
            SuccessMessage = "Faj sikeresen létrehozva!";
            NewSpeciesName = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
        }

        await LoadSpeciesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostUpdateAsync()
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        if (EditId == null || string.IsNullOrWhiteSpace(EditName))
        {
            ErrorMessage = "Érvénytelen adat(ok).";
            await LoadSpeciesAsync();
            return Page();
        }

        var species = await _context.AnimalsSpecies
            .Where(s => s.Id == EditId.Value)
            .FirstOrDefaultAsync();

        if (species == null)
        {
            ErrorMessage = "A faj nem található.";
            await LoadSpeciesAsync();
            return Page();
        }

        var exists = await _context.AnimalsSpecies
            .AnyAsync(s => s.Name == EditName && s.Id != EditId.Value);

        if (exists)
        {
            ErrorMessage = "Már létezik faj az alábbi névvel.";
            await LoadSpeciesAsync();
            return Page();
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        species.Name = EditName;
        species.ModifiedOn = DateTime.Now;
        species.ModifiedBy = userId.Value;

        try
        {
            await _context.SaveChangesAsync();
            SuccessMessage = "Faj sikeresen frissítve!";
            EditId = null;
            EditName = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
        }

        await LoadSpeciesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        var species = await _context.AnimalsSpecies
            .Include(s => s.Animals)
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();

        if (species == null)
        {
            ErrorMessage = "A faj nem található.";
            await LoadSpeciesAsync();
            return Page();
        }

        if (species.Animals.Any())
        {
            ErrorMessage = "Nem törölhetsz olyan fajt, amely állatokhoz van rendelve.";
            await LoadSpeciesAsync();
            return Page();
        }

        try
        {
            _context.AnimalsSpecies.Remove(species);
            await _context.SaveChangesAsync();
            SuccessMessage = "Faj sikeresen törölve!";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
        }

        await LoadSpeciesAsync();
        return Page();
    }

    private async Task LoadSpeciesAsync()
    {
        SpeciesList = await _context.AnimalsSpecies
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
