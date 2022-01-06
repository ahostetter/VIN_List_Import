using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newmar.Data;
using Newmar.Models;

namespace Newmar.Pages.InventoryPage
{
    [Authorize(Roles = @"AdamsDesktop\achos")]
    public class IndexModel : PageModel
    {
        private readonly Newmar.Data.NewmarContext _context;

        public IndexModel(Newmar.Data.NewmarContext context)
        {
            _context = context;
        }

        public IList<Inventory> Inventory { get;set; }

        public async Task OnGetAsync()
        {
            Inventory = await _context.Inventory.ToListAsync();
        }
    }
}
