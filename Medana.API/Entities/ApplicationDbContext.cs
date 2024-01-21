using Microsoft.EntityFrameworkCore;

namespace Medana.API.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<PersonalInformation> PersonalInformation { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<MedicalHistory> MedicalHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>();
        modelBuilder.Entity<PersonalInformation>();
        modelBuilder.Entity<Consultation>();
        modelBuilder.Entity<MedicalHistory>();
    }
}
