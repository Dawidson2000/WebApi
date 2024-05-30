using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;

namespace RazorPages.Pages.Company
{
    public class EditModel : PageModel
    {
        private readonly Infrastructure.Data.AppDbContext _context;

        public EditModel(Infrastructure.Data.AppDbContext context)
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

            var companyentity =  await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);
            if (companyentity == null)
            {
                return NotFound();
            }
            CompanyEntity = companyentity;
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

            _context.Attach(CompanyEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyEntityExists(CompanyEntity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompanyEntityExists(Guid id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
