using System;
using System.Collections.Generic;

namespace Allatmenhely.WebApp.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool IsAdmin { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Animal> AnimalCreatedByNavigations { get; set; } = new List<Animal>();

    public virtual ICollection<Animal> AnimalModifiedByNavigations { get; set; } = new List<Animal>();

    public virtual ICollection<AnimalsBreed> AnimalsBreedCreatedByNavigations { get; set; } = new List<AnimalsBreed>();

    public virtual ICollection<AnimalsBreed> AnimalsBreedModifiedByNavigations { get; set; } = new List<AnimalsBreed>();

    public virtual ICollection<AnimalsSpecy> AnimalsSpecyCreatedByNavigations { get; set; } = new List<AnimalsSpecy>();

    public virtual ICollection<AnimalsSpecy> AnimalsSpecyModifiedByNavigations { get; set; } = new List<AnimalsSpecy>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
