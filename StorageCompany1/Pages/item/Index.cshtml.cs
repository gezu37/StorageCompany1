using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StorageCompanyModels.Data;
using StorageCompanyModels.Models;

namespace StorageCompany1.Pages.item
{
    public class IndexModel : PageModel
    {
        private readonly StorageCompanyModels.Data.StorageCompanyContext _context;

        public IndexModel(StorageCompanyModels.Data.StorageCompanyContext context)
        {
            _context = context;
        }

        public IList<StorageCompanyModels.Models.item> item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.items != null)
            {
                item = await _context.items.ToListAsync();
            }
        }
    }
}
