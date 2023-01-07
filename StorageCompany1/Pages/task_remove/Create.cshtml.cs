using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.task_remove
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
        ViewData["contact_id"] = new SelectList(_context.contacts, "contact_id", "contact_name");
        ViewData["item_id"] = new SelectList(_context.items, "item_id", "item_name");
        ViewData["storagehouse_id"] = new SelectList(_context.storagehouses, "storagehouse_id", "storagehouse_address");
            return Page();
        }

        [BindProperty]
        public StorageCompanyModels.Models.task_remove task_remove { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            _context.task_removes.Add(task_remove);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
