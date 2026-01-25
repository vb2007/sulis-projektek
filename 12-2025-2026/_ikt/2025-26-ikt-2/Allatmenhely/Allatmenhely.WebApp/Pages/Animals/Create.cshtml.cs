using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Animals;

public class CreateModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public CreateModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

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

    public async Task<IActionResult> OnGetAsync()
    {
        if (!_authService.IsCurrentUserAdmin())
        {
            return RedirectToPage("/Animals/Index");
        }

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
            ErrorMessage = "Faj választása kötelező.";
            await LoadSelectListsAsync();
            return Page();
        }

        if (BreedId <= 0)
        {
            ErrorMessage = "Fajta választása kötelező.";
            await LoadSelectListsAsync();
            return Page();
        }

        var userId = _authService.GetCurrentUserId();
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        var animal = new Animal
        {
            Name = Name,
            Description = Description,
            ImageUrl = ImageUrl,
            SpeciesId = SpeciesId,
            BreedId = BreedId,
            CreatedOn = DateTime.Now,
            CreatedBy = userId.Value,
            ModifiedOn = null,
            ModifiedBy = null
        };

        try
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Animals/Index");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Hiba lépett fel: {ex.Message}";
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
