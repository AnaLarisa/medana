using Medana.API.Entities.DTOs;
using Medana.API.Helpers;
using Medana.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medana.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;
    private readonly IPatientService _patientService;

    public PatientController(ILogger<PatientController> logger, IPatientService patientService )
    {
        _logger = logger;
        _patientService = patientService;
    }

    [HttpGet]
    [Route("all")]
    public IActionResult GetAllPatients()
    {
        try 
        {
            var patients = _patientService.GetAllPatientsWithDetails();
            return Ok(patients);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to retrieve all patients.");
            return NotFound(ex.Message);
        }

    }

    [HttpGet]
    [Route("{cnp}")]
    public IActionResult GetPatientById(string cnp)
    {
        try
        {
            var patient = _patientService.GetPatientById(cnp);

            return Ok(patient);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while trying to retrieve patient with CNP {cnp}.");
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddPatient(PatientDTO patientDto)
    {
        return BadRequest("Failed to add patient.");
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = DTOHelper.PatientDTOToPatient(patientDto);

            if (_patientService.AddPatient(patient))
            {
                return Ok($"The patient with CNP {patient.CNP} has been successfully added to the database."); // Assuming success
            }
            else
            {
                return BadRequest("Failed to add patient.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the patient: {ex.Message}");
            return StatusCode(500, $"An error occurred while processing your request:{ex.Message}");
        }
    }


    [HttpDelete]
    [Route("delete/{cnp}")]
    public async Task<IActionResult> DeletePatientAsync(string cnp) 
    {
        var result = await _patientService.DeletePatientAsync(cnp);
        return result 
            ? Ok($"Patient with CNP {cnp} has been successfully deleted from the database.") 
            : StatusCode(StatusCodes.Status500InternalServerError, $"Deletion of patient with CNP {cnp} failed");

    }


    [HttpPatch]
    [Route("edit/personalInformation/{cnp}")]
    public IActionResult UpdatePersonalInformation(string cnp, PersonalInformationDTO personalInformationDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_patientService.UpdatePersonalInformation(personalInformationDTO))
            {
                return NotFound();
            }

            return Ok($"Person with CNP {cnp} has been updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating personal information: {ex.Message}");
            return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
        }
    }


    [HttpPatch]
    [Route("edit/medicalHistory/{cnp}")]
    public IActionResult UpdateMedicalHistory(string cnp, MedicalHistoryDTO medicalHistoryDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_patientService.UpdateMedicalHistory(medicalHistoryDTO, cnp))
            {
                return NotFound();
            }

            return Ok($"Person with CNP {cnp} has been updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating medical history: {ex.Message}");
            return StatusCode(500, $"An error occurred while processing your request: :{ex.Message}");
        }
    }

    [HttpPatch]
    [Route("edit/insuranceInformation/{cnp}")]
    public IActionResult UpdateInsuranceInformation(string cnp, InsuranceInformationDTO insuranceInformationDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_patientService.UpdateInsuranceInformation(insuranceInformationDTO, cnp))
            {
                return NotFound();
            }

            return Ok($"Person with CNP {cnp} has been updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating insurance information: {ex.Message}");
            return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
        }
    }



}