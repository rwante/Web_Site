using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Esyalar
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.EsyaContext _context;

        public DetailsModel(WebApplication1.Data.EsyaContext context)
        {
            _context = context;
        }

        public Esya Esya { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Esya = await _context.Esyalar.FirstOrDefaultAsync(m => m.id == id);

            if (Esya == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
