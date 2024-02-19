using Medana.API.Entities.DTOs;
using Medana.Web.Client;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PuppeteerSharp;

namespace Medana.Web.Pages;

public class PatientDetailsModel : PageModel
{
    private readonly IClient _client;
    public PatientDTO Patient { get; set; }

    public PatientDetailsModel(IClient client)
    {
        _client = client;
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
        var url = Request.GetEncodedUrl();

        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });

        var page = await browser.NewPageAsync();
        await page.GoToAsync(url);

        // Execută JavaScript pentru a ascunde butoanele
        await page.EvaluateExpressionAsync(@"
        document.querySelectorAll('button').forEach(function(button) {
            button.style.display = 'none';
        });
    ");

        var fileName = "medical_record.pdf";
        var outputPath = Path.Combine(Path.GetTempPath(), fileName);

        await page.PdfAsync(outputPath);

        var fileBytes = await System.IO.File.ReadAllBytesAsync(outputPath);
        System.IO.File.Delete(outputPath);

        return File(fileBytes, "application/pdf", fileName);
    }
}
