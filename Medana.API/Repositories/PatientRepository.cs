using Medana.API.Entities;

namespace Medana.API.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PatientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IEnumerable<Patient> GetAllPatients()
    {
        return _dbContext.Patients.ToList();
    }


    public Patient GetPatientById(int id)
    {
        return _dbContext.Patients.FirstOrDefault(p => p.Id == id);
    }


    public bool AddPatient(Patient patient)
    {
        _dbContext.Patients.Add(patient);
        _dbContext.SaveChanges();
        return true;
    }
}
