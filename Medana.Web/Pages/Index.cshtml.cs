using Medana.API.Entities.DTOs;
using Medana.Web.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medana.Pages;

public class IndexModel : PageModel
{
    private ILogger<IndexModel> _logger;
    private IClient _client;

    public IList<PatientDTO> Patients { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task OnGetAsync()
    {
        Patients = await GetAllPatients();
    }

    public async Task<List<PatientDTO>> GetAllPatients()
    {
        var patients  = await _client.GetAllPatientsAsync();
        return patients.ToList();
    }
}