using System;
using System.Collections.Generic;

namespace Allatmenhely.WebApp.Models;

public partial class Animal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SpeciesId { get; set; }

    public int BreedId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual AnimalsBreed Breed { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual AnimalsSpecy Species { get; set; } = null!;
}
