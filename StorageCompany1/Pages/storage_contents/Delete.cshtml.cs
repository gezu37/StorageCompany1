using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.storage_contents
{
    public class DeleteModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public DeleteModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public storage_content storage_content { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.storage_contents == null)
            {
                return NotFound();
            }

            var storage_content_ = await _context.storage_contents.FirstOrDefaultAsync(m => m.id == id);

            if (storage_content_ == null)
            {
                return NotFound();
            }
            else 
            {
                storage_content = storage_content_;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.storage_contents == null)
            {
                return NotFound();
            }
            var storage_content_ = await _context.storage_contents.FindAsync(id);

            if (storage_content_ != null)
            {
                storage_content = storage_content_;
                _context.storage_contents.Remove(storage_content);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
