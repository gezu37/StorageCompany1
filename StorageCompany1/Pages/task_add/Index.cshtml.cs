using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.task_add
{
    public class IndexModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public IndexModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        public IList<StorageCompanyModels.Models.task_add> task_add { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.task_adds != null)
            {
                task_add = await _context.task_adds
                .Include(t => t.contact)
                .Include(t => t.item)
                .Include(t => t.storagehouse).ToListAsync();
            }
        }
    }
}
