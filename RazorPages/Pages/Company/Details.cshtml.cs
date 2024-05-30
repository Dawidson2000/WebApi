using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;

namespace RazorPages.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private readonly Infrastructure.Data.AppDbContext _context;

        public DetailsModel(Infrastructure.Data.AppDbContext context)
        {
            _context = context;
        }

        public CompanyEntity CompanyEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyentity = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);
            if (companyentity == null)
            {
                return NotFound();
            }
            else
            {
                CompanyEntity = companyentity;
            }
            return Page();
        }
    }
}
