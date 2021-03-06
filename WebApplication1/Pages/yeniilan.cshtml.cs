using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class yeniilanModel : PageModel
    {
        private readonly WebApplication1.Data.EsyaContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        
        public yeniilanModel(WebApplication1.Data.EsyaContext context, IWebHostEnvironment hostEnvironment)
        {
            
            webHostEnvironment = hostEnvironment;
            _context = context;

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Esya Esya { get; set; }
        public IFormFile resim { get; set; }
        public string[] il = new string[] { "Adana", "Ad?yaman", "Afyon", "A?r?", "Amasya", "Ankara", "Antalya", "Artvin", "Ayd?n", "Bal?kesir", "Bilecik", "Bing?l", "Bitlis", "Bolu", "Burdur", "Bursa", "?anakkale", "?ank?r?", "?orum", "Denizli", "Diyarbak?r", "Edirne", "Elaz??", "Erzincan", "Erzurum", "Eski?ehir", "Gaziantep", "Giresun", "G?m??hane", "Hakkari", "Hatay", "Isparta", "??el", "?stanbul", "?zmir", "Kars", "Kastamonu", "Kayseri", "K?rklareli", "K?r?ehir", "Kocaeli", "Konya", "K?tahya", "Malatya", "Manisa", "K.mara?", "Mardin", "Mu?la", "Mu?", "Nev?ehir", "Ni?de", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirda?", "Tokat", "Trabzon", "Tunceli", "?anl?urfa", "U?ak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "K?r?kkale", " Batman", "??rnak", "Bart?n", "Ardahan", "I?d?r", "Yalova", "Karab?k", "Kilis", "Osmaniye", "D?zce" };
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(resim != null)
            {
                string uniqueFileNmae = null;
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileNmae = Guid.NewGuid().ToString() + "_" + resim.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNmae);
                resim.CopyTo(new FileStream(filePath, FileMode.Create));
                Esya.resim = uniqueFileNmae;
            }
            Esya.sehir = il[(int.Parse(Esya.sehir)) - 1];
            _context.Esyalar.Add(Esya);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
