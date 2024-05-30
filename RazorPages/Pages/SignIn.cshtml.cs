using Application.Abstractions.Services;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace RazorPages.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignInModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public RegisterUser RegisterUser { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonContent = JsonSerializer.Serialize(RegisterUser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7103/account/register", content, cancellationToken);

            if (response.IsSuccessStatusCode) 
            {
                return RedirectToPage("Login");
            }

            return Page();
        }
    }
}
