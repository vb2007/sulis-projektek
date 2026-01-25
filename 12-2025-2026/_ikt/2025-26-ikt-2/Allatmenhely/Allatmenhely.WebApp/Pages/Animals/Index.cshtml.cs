using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Allatmenhely.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Animals;

public class IndexModel : PageModel
{
    private readonly AnimalShelterContext _context;
    private readonly AuthService _authService;

    public IndexModel(AnimalShelterContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public List<Animal> Animals { get; set; } = new();
    public bool IsAdmin { get; set; }

    public async Task OnGetAsync()
    {
        IsAdmin = _authService.IsCurrentUserAdmin();

        Animals = await _context.Animals
            .Include(a => a.Species)
            .Include(a => a.Breed)
            .OrderBy(a => a.Name)
            .ToListAsync();
    }
}
