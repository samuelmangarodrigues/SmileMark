using Microsoft.EntityFrameworkCore;
using SmileMarks.Models;

namespace SmileMarks.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Dentist> Dentist { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Schedule> Schedule { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dentist>()
            .HasIndex(d => d.Email)
            .IsUnique();

        modelBuilder.Entity<Dentist>()
            .HasIndex(d => d.Cro)
            .IsUnique();

        modelBuilder.Entity<Patient>()
            .HasIndex(d => d.Email)
            .IsUnique();
    }
}