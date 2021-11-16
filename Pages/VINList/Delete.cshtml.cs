using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newmar.Data;
using Newmar.Models;

namespace Newmar.Pages.VINList
{
    public class DeleteModel : PageModel
    {
        private readonly Newmar.Data.NewmarContext _context;

        public DeleteModel(Newmar.Data.NewmarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VIN VIN { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VIN = await _context.VIN.FirstOrDefaultAsync(m => m.ID == id);

            if (VIN == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VIN = await _context.VIN.FindAsync(id);

            if (VIN != null)
            {
                _context.VIN.Remove(VIN);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
