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
    public DbSet<Medication> Medications { get; set; }
    public DbSet<MedicalHistory> MedicalHistory { get; set; }
    public DbSet<InsuranceInformation> InsuranceInformation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>();
        modelBuilder.Entity<Consultation>();
        modelBuilder.Entity<Medication>();
        modelBuilder.Entity<MedicalHistory>()
            .HasOne(m => m.Patient)
            .WithOne(p => p.MedicalHistory)
            .HasForeignKey<MedicalHistory>(m => m.CNP)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<InsuranceInformation>()
            .HasOne(i => i.Patient)
            .WithOne(p => p.InsuranceInformation)
            .HasForeignKey<InsuranceInformation>(i => i.CNP)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PersonalInformation>()
            .HasOne(pi => pi.Patient)
            .WithOne(p => p.PersonalInformation)
            .HasForeignKey<PersonalInformation>(pi => pi.CNP)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
