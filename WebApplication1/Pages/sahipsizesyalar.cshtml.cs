using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class sahipsizesyalarModel : PageModel
    {
        private readonly WebApplication1.Data.EsyaContext _context;

        public sahipsizesyalarModel(WebApplication1.Data.EsyaContext context)
        {
            _context = context;
        }

        public IList<Esya> Esya { get; set; }

        public async Task OnGetAsync()
        {
            Esya = await _context.Esyalar.Where(x => x.ilanDurumu == true).ToListAsync();
        }
    }
}
