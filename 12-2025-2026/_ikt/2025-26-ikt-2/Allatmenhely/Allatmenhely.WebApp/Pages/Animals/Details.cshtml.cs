using Allatmenhely.WebApp.Data;
using Allatmenhely.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Pages.Animals;

public class DetailsModel : PageModel
{
    private readonly AnimalShelterContext _context;

    public DetailsModel(AnimalShelterContext context)
    {
        _context = context;
    }

    public Animal? Animal { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Animal = await _context.Animals
            .Include(a => a.Species)
            .Include(a => a.Breed)
            .Include(a => a.CreatedByNavigation)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (Animal == null)
        {
            return NotFound();
        }

        return Page();
    }
}
