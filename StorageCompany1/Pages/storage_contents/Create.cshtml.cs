using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.storage_contents
{
    public class CreateModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public CreateModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["item_id"] = new SelectList(_context.items, "item_id", "item_name");
        ViewData["owner"] = new SelectList(_context.clients, "company_id", "company_name");
        ViewData["storagehouse_id"] = new SelectList(_context.storagehouses, "storagehouse_id", "storagehouse_address");
            return Page();
        }

        [BindProperty]
        public storage_content storage_content { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           _context.storage_contents.Add(storage_content);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
