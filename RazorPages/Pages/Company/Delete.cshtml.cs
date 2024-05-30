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
    public class DeleteModel : PageModel
    {
        private readonly Infrastructure.Data.AppDbContext _context;

        public DeleteModel(Infrastructure.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyentity = await _context.Companies.FindAsync(id);
            if (companyentity != null)
            {
                CompanyEntity = companyentity;
                _context.Companies.Remove(CompanyEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
