using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using System.Net.Http.Headers;

namespace RazorPages.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public UserEntity UserEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? email)
        {
            if (email == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7103/account/{email}");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            var user = await response.Content.ReadFromJsonAsync<UserEntity>();

            if (user == null)
            {
                return NotFound();
            }

            UserEntity = user;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? email)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7103/account/{email}");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await client.SendAsync(request);

            return RedirectToPage("./Index");
        }
    }
}
