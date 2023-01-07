using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.storage_contents
{
    public class EditModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public EditModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public storage_content storage_content { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.storage_contents == null)
            {
                return NotFound();
            }

            var storage_content_ =  await _context.storage_contents.FirstOrDefaultAsync(m => m.id == id);
            if (storage_content_ == null)
            {
                return NotFound();
            }
            storage_content = storage_content_;
           ViewData["item_id"] = new SelectList(_context.items, "item_id", "item_name");
           ViewData["owner"] = new SelectList(_context.clients, "company_id", "company_name");
           ViewData["storagehouse_id"] = new SelectList(_context.storagehouses, "storagehouse_id", "storagehouse_address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(storage_content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!storage_contentExists(storage_content.id))
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

        private bool storage_contentExists(int id)
        {
          return _context.storage_contents.Any(e => e.id == id);
        }
    }
}
