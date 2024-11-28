using Microsoft.EntityFrameworkCore;
using SmileMarks.Models;

namespace SmileMarks.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Dentist> Dentist { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Schedule> Schedule { get; set; }
}