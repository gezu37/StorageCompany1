using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.item
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
            return Page();
        }

        [BindProperty]
        public StorageCompanyModels.Models.item item { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        { 
            _context.items.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
