using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;
using Application.Models.User;
using System.Net.Http;
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


        public IList<CompanyEntity> CompanyEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7103/companies");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            var content = await response.Content.ReadFromJsonAsync<IList<CompanyEntity>>();

            CompanyEntity = content;
        }
    }
}
