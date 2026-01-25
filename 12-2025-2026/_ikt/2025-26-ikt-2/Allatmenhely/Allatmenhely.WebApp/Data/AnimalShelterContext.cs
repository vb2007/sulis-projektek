using System;
using System.Collections.Generic;
using Allatmenhely.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Allatmenhely.WebApp.Data;

public partial class AnimalShelterContext : DbContext
{
    public AnimalShelterContext()
    {
    }

    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalsBreed> AnimalsBreeds { get; set; }

    public virtual DbSet<AnimalsSpecy> AnimalsSpecies { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //conn string configured in Program.cs
        if (!optionsBuilder.IsConfigured)
        {
            //will only be used if no configuration was provided
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Animals_PK");

            entity.Property(e => e.CreatedOn)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ImageURL");
            entity.Property(e => e.ModifiedBy).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ModifiedOn)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Name).HasMaxLength(120);

            entity.HasOne(d => d.Breed).WithMany(p => p.Animals)
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animals_Animals_Breeds_FK");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AnimalCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animals_Users_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AnimalModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Animals_Users_FK_1");

            entity.HasOne(d => d.Species).WithMany(p => p.Animals)
                .HasForeignKey(d => d.SpeciesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animals_Animals_Species_FK");
        });

        modelBuilder.Entity<AnimalsBreed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Animals_Breeds_PK");

            entity.ToTable("Animals.Breeds");

            entity.HasIndex(e => e.Name, "Animals_Breeds_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedBy).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ModifiedOn)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AnimalsBreedCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animals_Breeds_Users_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AnimalsBreedModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Animals_Breeds_Users_FK_1");
        });

        modelBuilder.Entity<AnimalsSpecy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AnimalSpecies_PK");

            entity.ToTable("Animals.Species");

            entity.HasIndex(e => e.Name, "AnimalSpecies_UNIQUE").IsUnique();

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedBy).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ModifiedOn)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AnimalsSpecyCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Animals_Species_Users_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AnimalsSpecyModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Animals_Species_Users_FK_1");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Appointments_PK");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ReservedByNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ReservedBy)
                .HasConstraintName("Appointments_Users_FK");

            entity.HasOne(d => d.ReservedToNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ReservedTo)
                .HasConstraintName("Appointments_Animals_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_PK");

            entity.HasIndex(e => e.Username, "Users_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.ProfilePictureUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ProfilePictureURL");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
