using Medana.API.Entities.DTOs;
using Medana.Web.Client;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PuppeteerSharp;

namespace Medana.Web.Pages
{
    public class ReportsModel : PageModel
    {
        private IClient client;
        public IList<ConsultationDTO> Consultations { get; set; }

        public ReportsModel(IClient client)
        {
            this.client = client;
        }
        public async Task OnGetAsync()
        {
            Consultations = await GetAllConsultations();
        }

        public async Task<List<ConsultationDTO>> GetAllConsultations()
        {
            var consultations = await client.GetAllConsultationsAsync();
            return consultations.ToList();
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

            await page.EvaluateExpressionAsync(@"
        document.querySelectorAll('input[type=text]').forEach(function(input) {
            input.style.display = 'none';
        });
        document.querySelectorAll('button').forEach(function(button) {
            button.style.display = 'none';
        });
        document.querySelectorAll('label').forEach(function(label) {
            label.style.display = 'none';
        });
    ");

            var fileName = "consultations _report.pdf";
            var outputPath = Path.Combine(Path.GetTempPath(), fileName);

            await page.PdfAsync(outputPath);

            var fileBytes = await System.IO.File.ReadAllBytesAsync(outputPath);
            System.IO.File.Delete(outputPath);

            return File(fileBytes, "application/pdf", fileName);
        }

    }
}
