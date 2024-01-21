using Medana.API.Entities;
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
    public IEnumerable<PatientDTO> GetAllPatients()
    {
        return _patientService.GetAllPatientsWithDetails();
    }

    [HttpGet]
    [Route("{id}")]
    public Patient GetPatientById(int id)
    {
        return _patientService.GetPatientById(id);
    }

    [HttpPost]
    [Route("add")]
    public bool AddPatient(PatientDTO patientDto)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var patient = DTOHelper.PatientDTOToPatient(patientDto);

        return _patientService.AddPatient(patient);
    }


    [HttpDelete]
    [Route("delete")]
    public IActionResult DeletePatient(int id) 
    {
        try
        {
            var patientToBeDeleted = _patientService.GetPatientById(id);

            if (patientToBeDeleted == null)
            {
                return NotFound($"Patient with Id = {id} not found");
            }

            return await _patientsService.DeletePatient(patientToBeDeleted);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Deletion of patient with ID {id} failed.");
        }

    }

}