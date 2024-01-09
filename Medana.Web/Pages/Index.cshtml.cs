using Medana.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medana.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IList<Patient> Patients { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Patients = GetDummyPatients();
    }

    public static List<Patient> GetDummyPatients()
    {
        var dummyPatients = new List<Patient>();

        var patient1 = new Patient
        {
            Id = 1,
            PersonalInformation = new PersonalInformation
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(2024, 1, 3),
                Sex = "Male",
                Address = "123 Main St, Cityville",
                CNP = "6240103078645",
                PhoneNumber = "555-1234",
                Occupation = "Software Engineer",
                Email = "john.doe@example.com"
            },
            MedicalHistory = new MedicalHistory
            {
                MedicalConditions = new List<string> { "Hypertension", "Allergies" },
                MedicationAndDosages = new List<Medication>
                    {
                        new Medication { MedicationName = "Aspirin", Dosage = "100mg", Frequency = "Once daily" }
                    },
                Allergies = new List<string> { "Penicillin" },
                SurgicalHistory = new List<string> { "Appendectomy" },
                ImmunizationHistory = new List<string> { "Flu shot 2021" },
                FamilyMedicalHistory = "Heart disease"
            },
            InsuranceInformation = new InsuranceInformation
            {
                InsuranceProvider = "HealthGuard",
                InsurancePolicyNumber = "HG123456"
            }
        };

        dummyPatients.Add(patient1);

        // Dummy Patient 2
        var patient2 = new Patient
        {
            Id = 2,
            PersonalInformation = new PersonalInformation
            {
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(2009, 1, 17),
                Sex = "Female",
                Address = "456 Oak St, Townsville",
                CNP = "6090117078076", // Replace with a valid CNP
                PhoneNumber = "555-5678",
                Occupation = "Teacher",
                Email = "jane.smith@example.com"
            },
            MedicalHistory = new MedicalHistory
            {
                MedicalConditions = new List<string> { "Asthma" },
                MedicationAndDosages = new List<Medication>
                    {
                        new Medication { MedicationName = "Ventolin", Dosage = "90mcg", Frequency = "As needed" }
                    },
                Allergies = new List<string> { "Pollen" },
                SurgicalHistory = new List<string>(),
                ImmunizationHistory = new List<string> { "Tetanus shot 2020" },
                FamilyMedicalHistory = "Diabetes"
            },
            InsuranceInformation = new InsuranceInformation
            {
                InsuranceProvider = "SafeCare",
                InsurancePolicyNumber = "SC789012"
            }
        };

        dummyPatients.Add(patient2);

        // Add more dummy patients as needed

        return dummyPatients;
    }
}