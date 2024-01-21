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
        var patients = _dbContext.Patients.ToList();
        return patients;
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

    public bool IsCNPUnique(string CNP)
    {
        return _dbContext.Patients.Any(p => p.PersonalInformation.CNP == CNP);
    }

    public bool DeletePatient(int id) 
    { 
        var patient = _dbContext.Patients.FirstOrDefault(p => p.Id == id);
        var personalInformation = _dbContext.PersonalInformation.FirstOrDefault(p => p.Id == patient.PersonalInformation.Id);
        var medicalHistory = _dbContext.MedicalHistory.FirstOrDefault(m => m.Id == patient.MedicalHistory.Id);
        
        if (patient == null || personalInformation == null || medicalHistory == null)
        {
            return false;
        }


        _dbContext.Patients.Remove(patient);
        _dbContext.PersonalInformation.Remove(personalInformation);
        _dbContext.MedicalHistory.Remove(medicalHistory);
        _dbContext.SaveChanges();
        return true;
    }


}
