using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class MaaltijdModel : PageModel
    {

        public readonly MijnMaaltijdenHerkansingContext _context;

        [BindProperty]
        public int? _id { get; set; }

        [BindProperty]
        public Post post { get; set; }

        public Maaltijd maaltijd { get; set; }

        public Gebruiker gebruiker { get; set; }

        public MaaltijdModel(MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _id = id;

            if(id == null)
            {
                return NotFound();
            }

            post = _context.Posts.Find(id);

            if(post == null)
            {
                return NotFound();
            }
            else
            {
                maaltijd = _context.Maaltijden.Find(post.MaaltijdId);
                gebruiker = _context.Gebruikers.Find(post.GebruikerId);
            }

            return Page();
        }
    }
}
