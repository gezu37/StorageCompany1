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

namespace StorageCompany1.Pages.task_add
{
    public class EditModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public EditModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StorageCompanyModels.Models.task_add task_add { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.task_adds == null)
            {
                return NotFound();
            }

            var task_add_ =  await _context.task_adds.FirstOrDefaultAsync(m => m.task_id == id);
            if (task_add_ == null)
            {
                return NotFound();
            }
            task_add = task_add_;
           ViewData["contact_id"] = new SelectList(_context.contacts, "contact_id", "contact_name");
           ViewData["item_id"] = new SelectList(_context.items, "item_id", "item_name");
           ViewData["storagehouse_id"] = new SelectList(_context.storagehouses, "storagehouse_id", "storagehouse_address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(task_add).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!task_addExists(task_add.task_id))
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

        private bool task_addExists(int id)
        {
          return _context.task_adds.Any(e => e.task_id == id);
        }
    }
}
