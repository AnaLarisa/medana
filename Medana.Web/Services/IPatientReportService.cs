using Medana.API.Entities.DTOs;

namespace Medana.Web.Services
{
    public interface IPatientReportService
    {
        byte[] GeneratePatientReport(PatientDTO patient);
    }
}