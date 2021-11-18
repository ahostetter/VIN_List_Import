using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newmar.Data;
using Newmar.Models;

namespace Newmar.Pages.InventoryPage
{
    public class DetailsModel : PageModel
    {
        private readonly Newmar.Data.NewmarContext _context;

        public DetailsModel(Newmar.Data.NewmarContext context)
        {
            _context = context;
        }

        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inventory = await _context.Inventory.FirstOrDefaultAsync(m => m.ID == id);

            if (Inventory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
