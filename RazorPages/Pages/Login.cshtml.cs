using Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public LoginUser LoginUser { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonContent = JsonSerializer.Serialize(LoginUser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7103/account/login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                HttpContext.Session.SetString("jwtToken", token);
                
                return RedirectToPage("Company/Index");
            }

            return Page();
        }
    }
}
