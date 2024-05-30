using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using System.Net.Http.Headers;
using System.Text;

namespace RazorPages.Pages.Company
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public CompanyEntity CompanyEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7103/companies/{id}");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            var company = await response.Content.ReadFromJsonAsync<CompanyEntity>();

            if (company == null)
            {
                return NotFound();
            }

            CompanyEntity = company;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7103/companies/{id}");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await client.SendAsync(request);

            return RedirectToPage("./Index");
        }
    }
}
