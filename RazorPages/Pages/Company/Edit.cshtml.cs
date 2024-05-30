using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace RazorPages.Pages.Company
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient();

            var jsonContent = JsonSerializer.Serialize(CompanyEntity);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7103/companies")
            {
                Content = content
            };

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await client.SendAsync(request);

            return RedirectToPage("./Index");
        }
    }
}
