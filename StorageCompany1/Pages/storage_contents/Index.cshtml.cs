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
    public class IndexModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public IndexModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        public IList<storage_content> storage_content { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.storage_contents != null)
            {
                storage_content = await _context.storage_contents
                .Include(s => s.item)
                .Include(s => s.ownerNavigation)
                .Include(s => s.storagehouse).ToListAsync();
            }
        }
    }
}
