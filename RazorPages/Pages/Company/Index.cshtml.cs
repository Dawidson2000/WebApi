using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using Infrastructure.Data;
using System.Text;
using System.Net.Http.Headers;

namespace RazorPages.Pages.Company
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory, AppDbContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }


        public IList<CompanyEntity> CompanyEntity { get;set; } = new List<CompanyEntity>();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7103/companies");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadFromJsonAsync<IList<CompanyEntity>>();

                CompanyEntity = content;
            }
        }
    }
}
