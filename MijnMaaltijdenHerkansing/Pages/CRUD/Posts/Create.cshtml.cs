using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Pages.CRUD.Posts
{
    public class CreateModel : PageModel
    {
        private readonly MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext _context;

        public CreateModel(MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id");
        ViewData["MaaltijdId"] = new SelectList(_context.Maaltijden, "MaaltijdId", "Beschrijving");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
