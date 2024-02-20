using Medana.API.Entities.DTOs;
using Medana.Web.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medana.Web.Pages
{
    public class AddConsultationModel : PageModel
    {
        private readonly IClient _client;
        public string ErrorMessage { get; set; } = string.Empty;
        [BindProperty]
        public ConsultationDTO Consultation { get; set; } = new ConsultationDTO();

        public AddConsultationModel(IClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            Consultation = new ConsultationDTO();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Consultation.ConsultationDate = DateTime.Now;
            try
            {
                var result = await _client.AddConsultationAsync(Consultation);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}
