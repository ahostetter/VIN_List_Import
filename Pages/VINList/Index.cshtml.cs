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
    public class IndexModel : PageModel
    {
        private readonly Newmar.Data.NewmarContext _context;

        public IndexModel(Newmar.Data.NewmarContext context)
        {
            _context = context;
        }

        public IList<VIN> VIN { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Codes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string VINCode { get; set; }

        public async Task OnGetAsync()
        {
            var vins = from m in _context.VIN
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                vins = vins.Where(s => s.VNumber.Contains(SearchString));
            }

            VIN = await vins.ToListAsync();
        }

        //public async Task OnGetAsync()
        //{
        //    VIN = await _context.VIN.ToListAsync();
        //}
    }
}
