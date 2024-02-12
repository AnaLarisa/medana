using Medana.API.Entities;
using Medana.API.Entities.DTOs;
using Medana.Web.Client;
using Medana.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medana.Web.Pages;

public class PatientDetailsModel : PageModel
{
    private readonly IClient _client;
    private readonly IPatientReportService _reportService;
    public PatientDTO Patient { get; set; }

    public PatientDetailsModel(IClient client, IPatientReportService reportService)
    {
        _client = client;
        _reportService = reportService;
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        Patient = await _client.GetPatientByIdAsync(id);

        if (Patient == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string deleteButton)
    {
        var url = Request.Path.Value;
        var CNP = url.Split("/").Last();

        if (deleteButton == "delete")
        {
            var deletionResult = await _client.DeletePatientAsync(CNP);
            if (deletionResult)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the patient. Please try again.");
            }
        }
        return Page();
    }

    public async Task<IActionResult> OnPostDownloadReport()
    {
        var url = Request.Path.Value;
        var CNP = url.Split("/").Last();
        PatientDTO patient = await _client.GetPatientByIdAsync(CNP);

        byte[] reportData = _reportService.GeneratePatientReport(patient);

        return File(reportData, "application/pdf", "PatientReport.pdf");
    }
}
