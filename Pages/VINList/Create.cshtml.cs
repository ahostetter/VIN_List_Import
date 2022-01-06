using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newmar.Data;
using Newmar.Models;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace Newmar.Pages.VINList
{
    public class CreateModel : PageModel
    {
        private readonly Newmar.Data.NewmarContext _context;

        public CreateModel(Newmar.Data.NewmarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IFormFile VINFile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (VINFile.FileName.EndsWith(".csv"))
            {
                //Entity Framework way to clear VIN Table before Loading new VINS
                _context.VIN.RemoveRange(_context.VIN);
                // Creates the config used by csvHelper CsvReader method. Needed to add HeaderValidated and MissingFieldFound in order to ignore ID field
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null,
                };

                using var stream = VINFile.OpenReadStream();
                using var reader = new StreamReader(stream);
                using var csv = new CsvReader(reader, config);
                csv.Read();
                csv.ReadHeader();
                // Gets single record and commits the record to the database. Keeps reading records until reaches the last record.
                while (csv.Read())
                {
                    var record = csv.GetRecord<VIN>();
                    _context.VIN.Add(record);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
