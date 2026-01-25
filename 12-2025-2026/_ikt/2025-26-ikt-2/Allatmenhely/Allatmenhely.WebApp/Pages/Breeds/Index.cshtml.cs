using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Breeds;

public class IndexModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public IndexModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public List<AnimalsBreed> BreedsList { get; set; } = new();

    [BindProperty]
    public string? NewBreedName { get; set; }

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

        await LoadBreedsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        if (string.IsNullOrWhiteSpace(NewBreedName))
        {
            ErrorMessage = "A név megadása kötelező.";
            await LoadBreedsAsync();
            return Page();
        }

        var exists = await _context.AnimalsBreeds
            .AnyAsync(b => b.Name == NewBreedName);

        if (exists)
        {
            ErrorMessage = "Már létezik fajta ezzel a névvel.";
            await LoadBreedsAsync();
            return Page();
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        var breed = new AnimalsBreed
        {
            Name = NewBreedName,
            CreatedOn = DateTime.Now,
            CreatedBy = userId.Value
        };

        try
        {
            _context.AnimalsBreeds.Add(breed);
            await _context.SaveChangesAsync();
            SuccessMessage = "Fajta sikeresen létrehozva!";
            NewBreedName = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
        }

        await LoadBreedsAsync();
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
            await LoadBreedsAsync();
            return Page();
        }

        var breed = await _context.AnimalsBreeds
            .Where(b => b.Id == EditId.Value)
            .FirstOrDefaultAsync();

        if (breed == null)
        {
            ErrorMessage = "A fajta nem található.";
            await LoadBreedsAsync();
            return Page();
        }

        var exists = await _context.AnimalsBreeds
            .AnyAsync(b => b.Name == EditName && b.Id != EditId.Value);

        if (exists)
        {
            ErrorMessage = "Már létezik fajta ezzel a névvel.";
            await LoadBreedsAsync();
            return Page();
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        breed.Name = EditName;
        breed.ModifiedOn = DateTime.Now;
        breed.ModifiedBy = userId.Value;

        try
        {
            await _context.SaveChangesAsync();
            SuccessMessage = "Fajok sikeresen frissítve!";
            EditId = null;
            EditName = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
        }

        await LoadBreedsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

        var breed = await _context.AnimalsBreeds
            .Include(b => b.Animals)
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();

        if (breed == null)
        {
            ErrorMessage = "A fajta nem található.";
            await LoadBreedsAsync();
            return Page();
        }

        if (breed.Animals.Any())
        {
            ErrorMessage = "Nem törölhetsz olyan fajtát, ami már állatokhoz van rendelve.";
            await LoadBreedsAsync();
            return Page();
        }

        try
        {
            _context.AnimalsBreeds.Remove(breed);
            await _context.SaveChangesAsync();
            SuccessMessage = "Fajta sikeresen törölve!";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
        }

        await LoadBreedsAsync();
        return Page();
    }

    private async Task LoadBreedsAsync()
    {
        BreedsList = await _context.AnimalsBreeds
            .OrderBy(b => b.Name)
            .ToListAsync();
    }
}
