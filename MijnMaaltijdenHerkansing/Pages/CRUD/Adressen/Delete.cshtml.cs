using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Pages.CRUD.Adressen
{
    public class DeleteModel : PageModel
    {
        private readonly MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext _context;

        public DeleteModel(MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Adres Adres { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Adres = await _context.Adressen.FirstOrDefaultAsync(m => m.AdresId == id);

            if (Adres == null)
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

            Adres = await _context.Adressen.FindAsync(id);

            if (Adres != null)
            {
                _context.Adressen.Remove(Adres);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
