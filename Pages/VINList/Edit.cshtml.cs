using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newmar.Data;
using Newmar.Models;

namespace Newmar.Pages.VINList
{
    public class EditModel : PageModel
    {
        private readonly Newmar.Data.NewmarContext _context;

        public EditModel(Newmar.Data.NewmarContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VIN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VINExists(VIN.ID))
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

        private bool VINExists(int id)
        {
            return _context.VIN.Any(e => e.ID == id);
        }
    }
}
