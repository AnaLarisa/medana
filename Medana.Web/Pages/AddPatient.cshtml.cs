using System.Threading.Tasks;
using Medana.API.Entities.DTOs;
using Medana.Web.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medana.Web.Pages;

public class AddPatientModel : PageModel
{
    private readonly IClient _client;

    [BindProperty]
    public PatientDTO PatientDTO { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;

    public AddPatientModel(IClient client)
    {
        _client = client;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        PatientDTO.CNP = PatientDTO.PersonalInformation.CNP;
        try 
        { 
            var patient = await _client.AddPatientAsync(PatientDTO);
            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            return Page();
        }
    }
}
