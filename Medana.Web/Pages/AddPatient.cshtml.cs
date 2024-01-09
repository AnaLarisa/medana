using Medana.API.Entities.DTOs;
using Medana.API.Helpers;
using Medana.API.Services;
using Medana.Web.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medana.Web.Pages
{
    public class AddPatientModel : PageModel
    {
        private readonly IClient _client;

        [BindProperty]
        public PatientDTO PatientDTO { get; set; }

        public AddPatientModel(IClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await _client.AddPatientAsync(PatientDTO))
            {
                return RedirectToPage("SuccessPage");
            }

            return Page();
        }
    }
}

